using Core;
using Core.EntityFramework_Utils;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Client_Desktop
{
    public partial class InventoryForm : Form
    {
        private Inventory itemToModify = null;

        public InventoryForm(Inventory itemToModify)
        {
            if (itemToModify != null)
                this.itemToModify = itemToModify;
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the controls with Data from the Database or from the Item to be modified
        /// </summary>
        private void InventoryForm_Load(object sender, EventArgs e)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                //Load the food categories
                context.IngredientCategory.Load();
                foodCategoryCombo.DataSource = context.IngredientCategory.Local.ToList();

                //Load the metrics
                context.Metric.Load();
                measurementCombo.DataSource = context.Metric.Local.ToList();
            }

            //If we're modifying an item, populate the controls with information
            if (itemToModify != null)
            {
                itemNameTextbox.Text = itemToModify.IngredientName;
                amountTextbox.Text = itemToModify.Amount.ToString();
                // TO DO FIX
                //foodCategoryCombo.SelectedIndex = InventoryTranslator.GetFoodCategoryIndexByItemFoodTypeID(itemToModify.TypeID.Value);
                measurementCombo.SelectedIndex = InventoryTranslator.GetMeasurementIndexByItemMetricName(itemToModify.Measurement);
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            //Ensure validation was attempted before processing the button event
            if (!ValidateItemName() || !ValidateAmount())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            CreateNewItem();
            InventoryTranslator.UpdateItemInDatabaseByItem(CreateNewItem());
            itemToModify = null; //We don't need a reference to the object that no longer exists in the database
            this.DialogResult = DialogResult.OK;
        }

        private Inventory CreateNewItem()
        {
            Inventory ItemCreated = new Inventory();
            ItemCreated.IngredientName = itemNameTextbox.Text;
            ItemCreated.Amount = float.Parse(amountTextbox.Text);
            // TO DO Look at the combobox
            ItemCreated.Measurement = measurementCombo.SelectedValue.ToString();
            ItemCreated.Category = foodCategoryCombo.SelectedValue.ToString();
            return ItemCreated;
        }

        #region Input Validation
        /// <summary>
        /// When the control looses focus, check for any invalid characters (or null/white space)
        /// and trigger the ErrorProvider if any errors are discovered.
        /// </summary>
        private void itemNameTextbox_Validating(object sender, CancelEventArgs e)
        {
            ValidateItemName();
        }

        private bool ValidateItemName()
        {
            if (string.IsNullOrWhiteSpace(itemNameTextbox.Text))
            {
                InventoryError.SetError(itemNameTextbox, "You must enter a name");
                return false;
            }

            foreach (char c in itemNameTextbox.Text)
            {
                if (char.IsLetterOrDigit(c) == false && c.Equals(' ') == false)
                {
                    InventoryError.SetError(itemNameTextbox, "Only A-Z and 0-9 are permitted values.");
                    return false;
                }
            }

            InventoryError.SetError(itemNameTextbox, "");
            return true;
        }

        private void amountTextbox_Validating(object sender, CancelEventArgs e)
        {
            ValidateAmount();
        }

        private bool ValidateAmount()
        {
            if (string.IsNullOrWhiteSpace(amountTextbox.Text))
            {
                InventoryError.SetError(amountTextbox, "You must enter a value.");
                return false;
            }

            float parseTest;
            if (float.TryParse(amountTextbox.Text, out parseTest))
            {
                InventoryError.SetError(amountTextbox, "");
                return true;
            }
            else
            {
                InventoryError.SetError(amountTextbox, "Only 0-9 and '.' are permitted values.");
                return false;
            }
        }
        #endregion


    }
}
