using Core;
using Core.Utilities.Database.Queries.BindingLists;
using Core.Utilities.Database.Queries.Tables;
using Core.Utilities.Validation;
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
                this.itemToModify = itemToModify.Clone() as Inventory;
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

            using (HarvestTableUtility harvestDatabase = new HarvestTableUtility(new InventoryQuery()))
            {
                //Inventory newItem = 
                Inventory item = CreateInventoryFromControls();
                if (itemToModify != null)
                    harvestDatabase.Update(item);
                else
                    harvestDatabase.Insert(item);
            }
            itemToModify = null;
            this.DialogResult = DialogResult.OK;
        }

        private Inventory CreateInventoryFromControls()
        {
            Inventory temp = Core.Utilities.General.HarvestEntityFactory.CreateInventory(
                    itemNameTextbox.Text,
                    float.Parse(amountTextbox.Text),
                    measurementCombo.SelectedValue.ToString(),
                    foodCategoryCombo.SelectedValue.ToString()
                    );
            temp.InventoryID = (itemToModify != null)
                        ? itemToModify.InventoryID
                        : 0;
            return temp;
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