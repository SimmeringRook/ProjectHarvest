using System.Collections.Generic;
using System.Windows.Forms;
using Client_Desktop.Helpers;
using Core;
using System.Linq;
using Core.MeasurementConversions;
using Core.DatabaseUtilities.Queries;
using System.IO;
using System.Diagnostics;
using Core.MealPlanning;

namespace Client_Desktop
{
    public partial class GroceryList : Form
    {
        private PlannedWeek plannedWeek;
        private List<Inventory> _itemInDB = new List<Inventory>();

        private int numberOfRows;

        public GroceryList(PlannedWeek mealsForTheWeek)
        {
            this.plannedWeek = mealsForTheWeek;

            InitializeComponent();

            numberOfRows = groceryTableLayout.RowCount - 1;
            foreach (RecipeIngredient ri in plannedWeek.GetAllIngredientsForWeek())
                buildRow(ri);
        }

        private void buildRow(RecipeIngredient ri)
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

        private void createFile(string name, string qty, string measurement)
        {
            string lines = "";
            int i;
            string path = @"..\Documents\test.txt";

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

        private void button1_Click(object sender, System.EventArgs e)
        {
            Process.Start(@"G:");
        } 
    } 
}

