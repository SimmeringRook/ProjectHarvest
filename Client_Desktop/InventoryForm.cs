using Core;
using Core.DatabaseUtilities;
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
            try
            {
                //Databind the ComboBoxes
                using (HarvestEntities harvestDatabase = new HarvestEntities())
                {
                    harvestDatabase.IngredientCategory.Load();
                    foodCategoryCombo.DataSource = harvestDatabase.IngredientCategory.Local.ToList();

                    harvestDatabase.Metric.Load();
                    measurementCombo.DataSource = harvestDatabase.Metric.Local.ToList();
                }

                //If we're modifying an item, populate the controls with information
                if (itemToModify != null)
                {
                    itemNameTextbox.Text = itemToModify.IngredientName;
                    amountTextbox.Text = itemToModify.Amount.ToString();

                    using (HarvestUtility harvest = new HarvestUtility(new IngredientCategoryQuery()))
                    {
                        foodCategoryCombo.SelectedValue = (harvest.Get(itemToModify.InventoryID) as IngredientCategory).Category;

                        harvest.HarvestQuery = new MetricQuery();
                        measurementCombo.SelectedValue = (harvest.Get(itemToModify.InventoryID) as Metric).Measurement;
                    }
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            using (HarvestUtility harvestDatabase = new HarvestUtility(new InventoryQuery()))
            {
                Inventory newItem = CreateNewItem();
                if (itemToModify != null)
                {
                    newItem.InventoryID = itemToModify.InventoryID;
                    harvestDatabase.Update(newItem);
                    itemToModify = null;
                }
                else
                {
                    harvestDatabase.Insert(newItem);
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private Inventory CreateNewItem()
        {
            Inventory ItemCreated = new Inventory();
            ItemCreated.IngredientName = itemNameTextbox.Text;
            ItemCreated.Amount = float.Parse(amountTextbox.Text);
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
