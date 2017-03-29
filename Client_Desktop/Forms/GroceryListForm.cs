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
        private List<IngredientInformation> _ingreInfo = new List<IngredientInformation>();
        private int _numberOfRows;
        private string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Harvest Grocery Lists");

        public GroceryListForm(PlannedWeek mealsForTheWeek)
        {
            this._plannedWeek = mealsForTheWeek;
            _ingredients = new List<string>();
            InitializeComponent();

            _numberOfRows = groceryTableLayout.RowCount - 1;
            foreach (RecipeIngredient ri in _plannedWeek.GetAllIngredientsForWeek())
                buildRow(ri);

            try
            {
                if (_ingredients.Count > 0)
                    createFile(directoryPath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buildRow(RecipeIngredient ri)
        {
            using (HarvestTableUtility harvest = new HarvestTableUtility(new InventoryQuery()))
            {
                Inventory itemInDB = harvest.Get(ri.InventoryID) as Inventory;
                if (ri.Amount - itemInDB.Amount <= 0)
                    return;

                IngredientInformation rowToBeAdded = new IngredientInformation();
                groceryTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                groceryTableLayout.Controls.Add(rowToBeAdded.NameLabel, 0, _numberOfRows);
                groceryTableLayout.Controls.Add(rowToBeAdded.Quantity, 1, _numberOfRows);
                groceryTableLayout.Controls.Add(rowToBeAdded.Unit, 2, _numberOfRows);
                groceryTableLayout.Controls.Add(rowToBeAdded.Selected, 3, _numberOfRows);

                rowToBeAdded.NameLabel.Text = itemInDB.IngredientName;
                rowToBeAdded.Quantity.Text = (ri.Amount - itemInDB.Amount).ToString();
                rowToBeAdded.Unit.Text = ri.Measurement.ToString();

                _ingredients.Add(rowToBeAdded.NameLabel.Text.PadRight(25) + rowToBeAdded.Quantity.Text.PadRight(5) + rowToBeAdded.Unit.Text.PadRight(25));
                _ingreInfo.Add(rowToBeAdded);
                _numberOfRows++;
            }
        }

        private void createFile(string directory)
        {
            string filename = _plannedWeek.StartOfWeek.Date.ToString("MM_dd_yyyy") + ".txt";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Create a file to write to.
            using (StreamWriter writer = new StreamWriter(Path.Combine(directory, filename), false))
                foreach (string line in _ingredients)
                    writer.WriteLine(line);
        }

        private void printableButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                Process.Start(directoryPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            List<Inventory> pantry = new List<Inventory>();
            List<IngredientInformation> Checked = new List<IngredientInformation>();

            using (HarvestTableUtility harvest = new HarvestTableUtility(new InventoryQuery()))
            {
                var allItems = harvest.Get(-1) as List<Inventory>;

                _plannedWeek.GetAllIngredientsForWeek().ForEach(ri =>
                    allItems.ForEach(invItem =>
                        {
                            if (invItem.InventoryID == ri.InventoryID)
                                pantry.Add(invItem);
                        }
                       )
                      );

                _ingreInfo.ForEach(row => {
                    if (row.Selected.Checked)
                        Checked.Add(row);
                }
                );

                foreach (Inventory item in pantry)
                {
                    foreach (var ingredient in Checked)
                    {
                        if (item.IngredientName.Equals(ingredient.NameLabel.Text))
                        {
                            item.Amount += double.Parse(ingredient.Quantity.Text);
                            harvest.Update(item);
                        }
                    }
                }
            } 

            this.DialogResult = DialogResult.OK;
        }
    } 
}

