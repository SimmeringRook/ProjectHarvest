using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using Core.Utilities.General;
using Core.Adapters.Objects;
using Core.Adapters;
using System.Linq;

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

            //Needs testing to see if I can just use the Inventory off of ri instead
            Inventory itemInDB = HarvestAdapter.InventoryItems.Single(item => item.ID == ri.Inventory.ID);
                if (ri.Amount - itemInDB.Amount <= 0)
                    return;

                IngredientInformation rowToBeAdded = new IngredientInformation(false, null);
                groceryTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                groceryTableLayout.Controls.Add(rowToBeAdded.NameLabel, 0, _numberOfRows);
                groceryTableLayout.Controls.Add(rowToBeAdded.Quantity, 1, _numberOfRows);
                groceryTableLayout.Controls.Add(rowToBeAdded.Unit, 2, _numberOfRows);
                groceryTableLayout.Controls.Add(rowToBeAdded.Selected, 3, _numberOfRows);

                rowToBeAdded.NameLabel.Text = itemInDB.Name;
                rowToBeAdded.Quantity.Text = (ri.Amount - itemInDB.Amount).ToString();
                rowToBeAdded.Unit.Text = ri.Measurement.ToString();

                _ingredients.Add(rowToBeAdded.NameLabel.Text.PadRight(25) + rowToBeAdded.Quantity.Text.PadRight(5) + rowToBeAdded.Unit.Text.PadRight(25));
                _ingreInfo.Add(rowToBeAdded);
                _numberOfRows++;
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
            foreach (RecipeIngredient recipeIngredient in _plannedWeek.GetAllIngredientsForWeek())
            {
                if (pantry.Any(item => item.ID == recipeIngredient.Inventory.ID) == false &&
                    _ingreInfo.Any(row => row.NameLabel.Text.Equals(recipeIngredient.Inventory.Name) &&
                    row.Selected.Checked))
                {
                    recipeIngredient.Inventory.Amount += recipeIngredient.Amount;
                    pantry.Add(recipeIngredient.Inventory);
                }
                    
            }
            pantry.Clear();
            this.DialogResult = DialogResult.OK;
        }
    } 
}

