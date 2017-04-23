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
        private List<string> _groceryListIngredients = new List<string>();
        private List<IngredientInformation> _ingredientRows = new List<IngredientInformation>();
        private int _numberOfRows;
        private string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Harvest Grocery Lists");

        public GroceryListForm()
        {
            InitializeComponent();
            _numberOfRows = groceryTableLayout.RowCount - 1;

            foreach (KeyValuePair<RecipeIngredient, double> itemToPurchase in HarvestAdapter.CurrentWeek.GetAllItemsToPurchase())
                BuildRow(itemToPurchase);
        }

        private void GroceryListForm_Load(object sender, EventArgs e)
        {
            if (_ingredientRows.Count < 1)
            {
                MessageBox.Show("No items need to be purchased for the meals you currently have planned.", "Empty Grocery List", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BuildRow(KeyValuePair<RecipeIngredient, double> itemToPurchase)
        {
            Inventory inventory = HarvestAdapter.InventoryItems.Single(item => item.Equals(itemToPurchase.Key.Inventory));
            if (inventory.Amount - itemToPurchase.Value >= 0)
                return;

            IngredientInformation rowToBeAdded = new IngredientInformation(false, null);
            groceryTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            for (int column = 0; column < rowToBeAdded.Controls.Count; column++)
                groceryTableLayout.Controls.Add(rowToBeAdded.Controls[column], column, _numberOfRows);

            rowToBeAdded.NameLabel.Text = itemToPurchase.Key.Inventory.Name;
            rowToBeAdded.Quantity.Text = (itemToPurchase.Value - inventory.Amount).ToString();
            rowToBeAdded.Unit.Text = itemToPurchase.Key.Measurement.ToString();

            _groceryListIngredients.Add(rowToBeAdded.ToString());
            _ingredientRows.Add(rowToBeAdded);
            _numberOfRows++;
        }

        #region Print
        private void printableButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (_groceryListIngredients.Count > 0)
                    CreateFile(directoryPath);

                Process.Start(directoryPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void CreateFile(string directory)
        {
            string filename = HarvestAdapter.CurrentWeek.StartOfWeek.Date.ToString("MM_dd_yyyy") + ".txt";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Create a file to write to.
            using (StreamWriter writer = new StreamWriter(Path.Combine(directory, filename), false))
                foreach (string line in _groceryListIngredients)
                    writer.WriteLine(line);
        }
        #endregion

        #region Submit
        private void submitButton_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<RecipeIngredient, double> purchasedItem in HarvestAdapter.CurrentWeek.GetAllItemsToPurchase())
            {
                IngredientInformation currentRow = _ingredientRows.Single(row => row.NameLabel.Text.Equals(purchasedItem.Key.Inventory.Name));
                if (currentRow.Selected.Checked)
                    HarvestAdapter.InventoryItems.Single(item => item.Equals(purchasedItem.Key.Inventory)).Amount += double.Parse(currentRow.Quantity.Text);
            }
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                _groceryListIngredients = null;
                _ingredientRows = null;
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}