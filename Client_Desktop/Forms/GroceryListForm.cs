using System.Windows.Forms;
using Core;
using System.IO;
using System.Diagnostics;
using Core.MealPlanning;
using System.Collections.Generic;
using System;
using Core.Utilities.General;
using Core.Utilities.Database.Queries.Tables;

namespace Client_Desktop
{
    public partial class GroceryListForm : Form
    {
        private PlannedWeek _plannedWeek;
        private List<string> _ingredients;
        private int _numberOfRows;

        public GroceryListForm(PlannedWeek mealsForTheWeek)
        {
            this._plannedWeek = mealsForTheWeek;
            _ingredients = new List<string>();
            InitializeComponent();

            _numberOfRows = groceryTableLayout.RowCount - 1;
            foreach (RecipeIngredient ri in _plannedWeek.GetAllIngredientsForWeek())
                buildRow(ri);
        }

        private void buildRow(RecipeIngredient ri)
        {

            IngredientInformation rowToBeAdded = new IngredientInformation();
            groceryTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            groceryTableLayout.Controls.Add(rowToBeAdded.NameLabel, 0, _numberOfRows);
            groceryTableLayout.Controls.Add(rowToBeAdded.Quantity, 1, _numberOfRows);
            groceryTableLayout.Controls.Add(rowToBeAdded.Unit, 2, _numberOfRows);
            groceryTableLayout.Controls.Add(rowToBeAdded.Selected, 3, _numberOfRows);

            using (HarvestTableUtility harvest = new HarvestTableUtility(new InventoryQuery()))
            {
                Inventory itemInDB = harvest.Get(ri.InventoryID) as Inventory;
                rowToBeAdded.NameLabel.Text = itemInDB.IngredientName;
                rowToBeAdded.NameLabel.Text = itemInDB.IngredientName;
                rowToBeAdded.Quantity.Text = (ri.Amount - itemInDB.Amount).ToString();
                rowToBeAdded.Unit.Text = ri.Measurement.ToString();
            }

            _ingredients.Add(rowToBeAdded.NameLabel.Text.PadRight(25) + rowToBeAdded.Quantity.Text.PadRight(5) + rowToBeAdded.Unit.Text.PadRight(25));
            _numberOfRows++;
        }

        private void createFile(string directory)
        {
            string filename = "test.txt";

            // Create a file to write to.
            using (StreamWriter writer = new StreamWriter(string.Concat(directory, filename), false))
                foreach (string line in _ingredients)
                    writer.WriteLine(line);
        }

        private void printableButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                string directoryPath = @"C:\Users\Odin\Desktop\Grocery Lists\";
                createFile(directoryPath);
                Process.Start(directoryPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    } 
}

