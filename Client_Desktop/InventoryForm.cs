using Core;
using Core.DatabaseUtilities;
using Core.DatabaseUtilities.BindingListQueries;
using Core.DatabaseUtilities.Queries;
using Core.ModelExtensions;
using Core.ValidationUtilities;
using System;
using System.ComponentModel;
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
                using (HarvestBindingListUtility harvestBindingList = new HarvestBindingListUtility(new IngredientCategoryBindingListQuery()))
                {
                    foodCategoryCombo.DataSource = harvestBindingList.GetBindingList() as BindingList<IngredientCategory>;

                    harvestBindingList.HarvestBindingList = new MetricBindingListQuery();
                    measurementCombo.DataSource = harvestBindingList.GetBindingList() as BindingList<Metric>;
                }

                if (itemToModify != null)
                {
                    itemToModify.PopulateGUIProperties();
                    itemNameTextbox.Text = itemToModify.IngredientName;
                    amountTextbox.Text = itemToModify.Amount.ToString();
                    foodCategoryCombo.SelectedValue = itemToModify.FoodCategory;
                    measurementCombo.SelectedValue = itemToModify.Measurement;
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            
            if (HarvestValidator.Validate(itemNameTextbox, HarvestRegex.Name, InventoryError) == false
                || HarvestValidator.Validate(amountTextbox, HarvestRegex.Amount, InventoryError) == false)
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            using (HarvestUtility harvestDatabase = new HarvestUtility(new InventoryQuery()))
            {
                Inventory newItem = HarvestEntityFactory.CreateInventory(
                    itemNameTextbox.Text,
                    float.Parse(amountTextbox.Text),
                    measurementCombo.SelectedValue.ToString(),
                    foodCategoryCombo.SelectedValue.ToString(),
                        (itemToModify != null)
                        ? itemToModify.InventoryID
                        : 0
                    );
                if (itemToModify != null)
                    harvestDatabase.Update(newItem);
                else
                    harvestDatabase.Insert(newItem);
            }
            itemToModify = null;
            this.DialogResult = DialogResult.OK;
        }

        #region Input Validation
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