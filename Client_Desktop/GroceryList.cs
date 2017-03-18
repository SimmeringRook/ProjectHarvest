using System.Collections.Generic;
using System.Windows.Forms;
using Client_Desktop.Helpers;
using Core;
using System.Linq;
using Core.MeasurementConversions;
using Core.DatabaseUtilities.Queries;
using System.IO;
using System.Diagnostics;

namespace Client_Desktop
{
    public partial class GroceryList : Form
    {
        private List<PlannedMeals> plannedMealsForTheWeek;
        private List<RecipeIngredient> _ingredients = new List<RecipeIngredient>();
        private List<Inventory> _itemInDB = new List<Inventory>();

        private int numberOfRows;

        public GroceryList(List<PlannedMeals> plannedMealsForTheWeek)
        {
            this.plannedMealsForTheWeek = plannedMealsForTheWeek;
            InitializeComponent();
            getIngredients();

        }

        public void getIngredients()
        {
            numberOfRows = groceryTableLayout.RowCount - 1;


            foreach (PlannedMeals plan in plannedMealsForTheWeek)
            {
                foreach (RecipeIngredient recipeIngredient in plan.GetIngredientsForPlannedRecipes())
                {
                    using (HarvestConverter conversion = new HarvestConverter(new VolumeUnitConversion()))
                    {
                        if (_ingredients.Any(ingredient => ingredient.InventoryID == recipeIngredient.InventoryID))
                        {
                            RecipeIngredient ingredientToConvert = _ingredients.Single(ri => ri.InventoryID == recipeIngredient.InventoryID);

                            if (conversion.IsCorrectMeasurementType(ingredientToConvert.GetMeasurementUnit()) == false)
                                conversion.ConversionType = new WeightUnitConversion();
                            ingredientToConvert = conversion.Convert(recipeIngredient, ingredientToConvert.GetMeasurementUnit());

                            _ingredients.Single(i => i.InventoryID == recipeIngredient.InventoryID).Amount += ingredientToConvert.Amount;
                        }
                        else
                        {
                            _ingredients.Add(recipeIngredient);
                        }
                    }
                }
            }

            foreach (RecipeIngredient ri in _ingredients)
            {
                buildRow(ri);
            }
        }

        public void buildRow(RecipeIngredient ri)
        {

            IngredientInformation rowToBeAdded = new IngredientInformation();
            groceryTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            groceryTableLayout.Controls.Add(rowToBeAdded.NameLabel, 0, numberOfRows);
            groceryTableLayout.Controls.Add(rowToBeAdded.Quantity, 1, numberOfRows);
            groceryTableLayout.Controls.Add(rowToBeAdded.Unit, 2, numberOfRows);
            groceryTableLayout.Controls.Add(rowToBeAdded.Selected, 3, numberOfRows);

            using (HarvestUtility harvest = new HarvestUtility(new InventoryQuery()))
            {
                rowToBeAdded.NameLabel.Text = (harvest.Get(ri.InventoryID) as Inventory).IngredientName;
                Inventory itemInDB = harvest.Get(ri.InventoryID) as Inventory;
                _itemInDB.Add(itemInDB);
                rowToBeAdded.NameLabel.Text = itemInDB.IngredientName;
                rowToBeAdded.Quantity.Text = (ri.Amount - itemInDB.Amount).ToString();
                rowToBeAdded.Unit.Text = ri.Measurement.ToString();
            }

            createFile(rowToBeAdded.NameLabel.Text, rowToBeAdded.Quantity.Text, rowToBeAdded.Unit.Text);
            numberOfRows++;
        }

        public void createFile(string name, string qty, string measurement)
        {
            string lines = "";
            int i;
            string path = @"G:\test.txt";

            #region Does not Exists
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    lines = name;

                    if (lines.Length < 25)
                    {
                        i = lines.Length;
                        string space = " ";

                        while (i < 25)
                        {
                            lines += space;
                            i++;
                        }

                        lines += qty;

                        while (i < 30)
                        {
                            lines += space;
                            i++;
                        }

                        lines += measurement;

                        sw.WriteLine(lines);
                        sw.Close();
                    }
                }
            }
            #endregion
            else
            #region Does Exists
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    lines = name;

                    if (lines.Length < 25)
                    {
                        i = lines.Length;
                        string space = " ";

                        while (i < 25)
                        {
                            lines += space;
                            i++;
                        }

                        lines += qty;

                        while (i < 30)
                        {
                            lines += space;
                            i++;
                        }

                        lines += measurement;

                        sw.WriteLine(lines);
                        sw.Close();
                    }
                }                
            }
            #endregion
        }

        public void button1_Click(object sender, System.EventArgs e)
        {
            Process.Start(@"G:");
        } 
    } 
}

