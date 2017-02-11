using Core;
using Core.EntityFramework_Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Desktop
{
    public partial class InventoryForm : Form
    {
        private Inventory ItemCreated = null;
        private Inventory itemToModify = null;

        public InventoryForm()
        {
            InitializeComponent();
        }

        public InventoryForm(Inventory itemToModify)
        {
            this.itemToModify = itemToModify;
            InitializeComponent();
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                //Load the food categories
                context.FoodType.Load();
                foodCategoryCombo.DataSource = context.FoodType.Local.ToList();

                //Load the metrics
                context.Metric.Load();
                measurementCombo.DataSource = context.Metric.Local.ToList();

                //If we're modifying an item, populate the controls with information
                if (itemToModify != null)
                {
                    itemNameTextbox.Text = itemToModify.Name;
                    amountTextbox.Text = itemToModify.Amount.ToString();

                    foodCategoryCombo.SelectedIndex = InventoryTranslator.GetFoodCategoryIndexByItemFoodTypeID(itemToModify.TypeID.Value);
                    measurementCombo.SelectedIndex = InventoryTranslator.GetMeasurementIndexByItemMetricID(itemToModify.MetricID.Value);
                }
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

            if (itemToModify != null)
                UpdateItemWithNewData();
            else
                CreateNewItem();
            this.DialogResult = DialogResult.OK;
        }

        private void CreateNewItem()
        {
            ItemCreated = new Core.Inventory();
            ItemCreated.Name = itemNameTextbox.Text;
            ItemCreated.Amount = float.Parse(amountTextbox.Text);
            ItemCreated.MetricID = (int?)measurementCombo.SelectedValue;
            ItemCreated.TypeID = (int?)foodCategoryCombo.SelectedValue;
        }

        public Core.Inventory GetCreatedItem()
        {
            return ItemCreated;
        }

        private void UpdateItemWithNewData()
        {
            itemToModify.Name = itemNameTextbox.Text;
            itemToModify.Amount = float.Parse(amountTextbox.Text);
            itemToModify.MetricID = (int?)measurementCombo.SelectedValue;
            itemToModify.TypeID = (int?)foodCategoryCombo.SelectedValue;
        }

        public Inventory GetModifiedItem()
        {
            return itemToModify;
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
