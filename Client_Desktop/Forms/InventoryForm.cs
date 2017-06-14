using Core.Adapters;
using Core.Adapters.Objects;
using Core.Utilities.UnitConversions;
using Core.Utilities.Validation;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Client_Desktop
{
    public partial class InventoryForm : Form
    {
        private Inventory _inventoryItem = null;

        public InventoryForm(Inventory itemToModify)
        {
            InitializeComponent();
            _inventoryItem = itemToModify;

            try
            {
                foodCategoryCombo.DataSource = HarvestAdapter.IngredientCategories.ToList();
                measurementCombo.DataSource = HarvestAdapter.Measurements.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to retrieve information from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Core.Utilities.Logging.Logger.Log(ex);
            }
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            if (_inventoryItem != null)
            {
                itemNameTextbox.Text = _inventoryItem.Name;
                amountTextbox.Text = _inventoryItem.Amount.ToString();
                foodCategoryCombo.SelectedIndex = foodCategoryCombo.Items.IndexOf(_inventoryItem.Category);
                measurementCombo.SelectedIndex = measurementCombo.Items.IndexOf(_inventoryItem.Measurement);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (IsValid() == false)
                return;
            try
            {
                Inventory exisitingInventory = HarvestAdapter.InventoryItems.SingleOrDefault(
                    item => 
                    item.Name.Equals(itemNameTextbox.Text) &&
                    item.Category.Equals(foodCategoryCombo.SelectedValue.ToString()));
                if (exisitingInventory != null)
                    CheckForChanges();
                else
                    HarvestAdapter.InventoryItems.Add(CreateInventoryFromControls());
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to retrieve information from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Core.Utilities.Logging.Logger.Log(ex);
            }
            this.DialogResult = DialogResult.OK;
        }

        #region Create New Object Or Update Existing
        private Inventory CreateInventoryFromControls()
        {
            Inventory temp = new Inventory();
            temp.Name = itemNameTextbox.Text;
            temp.Amount = double.Parse(amountTextbox.Text);
            temp.Measurement = (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), measurementCombo.SelectedValue.ToString());
            temp.Category = foodCategoryCombo.SelectedValue.ToString();
            return temp;
        }

        private void CheckForChanges()
        {
            string name = itemNameTextbox.Text;
            if (_inventoryItem.Name.Equals(name) == false) _inventoryItem.Name = name;

            double amount = double.Parse(amountTextbox.Text);
            if (_inventoryItem.Amount.Equals(amount) == false) _inventoryItem.Amount = amount;

            MeasurementUnit unit = (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), measurementCombo.SelectedValue.ToString());
            if (_inventoryItem.Measurement.Equals(unit) == false) _inventoryItem.Measurement = unit;

            string category = foodCategoryCombo.SelectedValue.ToString();
            if (_inventoryItem.Category.Equals(category) == false) _inventoryItem.Category = category;
        }
        #endregion

        #region Input Validation

        private bool IsValid()
        {
            bool noErrors = true;

            if (HarvestValidator.Validate(itemNameTextbox, HarvestRegex.Name, InventoryError) == false)
                noErrors = false;

            if (HarvestValidator.Validate(amountTextbox, HarvestRegex.Amount, InventoryError) == false)
                noErrors = false;

            return noErrors;
        }
        private void itemNameTextbox_Validating(object sender, CancelEventArgs e)
        {
            HarvestValidator.Validate((sender as TextBox), HarvestRegex.Name, InventoryError);
        }

        private void amountTextbox_Validating(object sender, CancelEventArgs e)
        {
            HarvestValidator.Validate((sender as TextBox), HarvestRegex.Amount, InventoryError);
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
            }

            _inventoryItem = null;

            base.Dispose(disposing);
        }
        #endregion
    }
}