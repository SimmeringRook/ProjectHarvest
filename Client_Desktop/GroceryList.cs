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
            string line = "";
            int i;
            string path = @"G:\test.txt";

                // Create a file to write to.
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    line = name.PadRight(25) + qty.PadRight(5) + measurement.PadRight(25);
                writer.WriteLine(line);
                   
                }
            }
            
        }

        private void printableButton_Click(object sender, System.EventArgs e)
        {
            Process.Start(@"G:");
        }
    } 
}

