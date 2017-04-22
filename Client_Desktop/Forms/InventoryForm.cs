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
        private Inventory itemToModify = null;

        public InventoryForm(Inventory itemToModify)
        {
            InitializeComponent();
            if (itemToModify != null)
                this.itemToModify = itemToModify;

            try
            {
                foodCategoryCombo.DataSource = HarvestAdapter.IngredientCategories.ToList();
                measurementCombo.DataSource = HarvestAdapter.Measurements.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            if (itemToModify != null)
            {
                itemNameTextbox.Text = itemToModify.Name;
                amountTextbox.Text = itemToModify.Amount.ToString();
                foodCategoryCombo.SelectedIndex = foodCategoryCombo.Items.IndexOf(itemToModify.Category);
                measurementCombo.SelectedIndex = measurementCombo.Items.IndexOf(itemToModify.Measurement);
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (IsValid() == false)
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            if (itemToModify != null)
                CheckForChanges();
            else
                HarvestAdapter.InventoryItems.Add(CreateInventoryFromControls());

            this.DialogResult = DialogResult.OK;
        }

        private Inventory CreateInventoryFromControls()
        {
            Inventory temp = new Inventory()
            {
                ID = 0,
                Name = itemNameTextbox.Text,
                Amount = float.Parse(amountTextbox.Text),
                Measurement = (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), measurementCombo.SelectedValue.ToString()),
                Category = foodCategoryCombo.SelectedValue.ToString()
            };
            return temp;
        }

        private void CheckForChanges()
        {
            string name = itemNameTextbox.Text;
            if (itemToModify.Name.Equals(name) == false) itemToModify.Name = name;

            double amount = double.Parse(amountTextbox.Text);
            if (itemToModify.Amount.Equals(amount) == false) itemToModify.Amount = amount;

            MeasurementUnit unit = (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), measurementCombo.SelectedValue.ToString());
            if (itemToModify.Measurement.Equals(unit) == false) itemToModify.Measurement = unit;

            string category = foodCategoryCombo.SelectedValue.ToString();
            if (itemToModify.Category.Equals(category) == false) itemToModify.Category = category;
        }

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
    }
}