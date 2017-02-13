using Core;
using Core.EntityFramework_Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Forms;

namespace Client_Desktop
{
    public partial class HarvestForm : Form
    {
        private List<Inventory> inventoryItemsToRemove = new List<Inventory>();

        public HarvestForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*  TODO:
             *  Any pre-exit operations that need to be conducted should be called either in here,
             *  or overide the Dispose().
             *  
             *  Ex: Ensure all changes to the inventory have been commited to the database before exit;
             *      or prompt user, warning of unsaved changes.
             */ 
            this.Dispose();
        }

        private void pantryTabControl_Selected(object sender, TabControlEventArgs e)
        {
            ForceRefreshOfCurrentView();
        }

        /// <summary>
        /// Loads the relevant table for the current TabPage, and rebinds the table to the datagridview
        /// </summary>
        private void ForceRefreshOfCurrentView()
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                switch (pantryTabControl.SelectedIndex)
                {
                    case 0:
                        //Meal Planning stuff goes here
                        break;
                    case 1:
                        context.Inventory.Load();
                        InventoryGridView.DataSource = context.Inventory.Local.ToBindingList();
                        break;
                    case 2:
                        context.Recipe.Load();
                        RecipeGridView.DataSource = context.Recipe.Local.ToBindingList();
                        break;
                }
            };
            
            pantryTabControl.SelectedTab.Refresh();
        }

        #region Meal Tab
        private void InitializeMealTab()
        {

        }
        #endregion

        #region Inventory Tab
        /// <summary>
        /// Translate MetricID and FoodTypeID into respective strings; assign the text value to the modify button
        /// </summary>
        private void InventoryGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (InventoryGridView.Columns[e.ColumnIndex].Name == "FoodCategory")
                e.Value = InventoryTranslator.GetFoodCategoryByRowPostion(e.RowIndex);

            if (InventoryGridView.Columns[e.ColumnIndex].Name == "Measurement")
                e.Value = InventoryTranslator.GetMeasurementNameByItemID(e.RowIndex);

            if (InventoryGridView.Columns[e.ColumnIndex].Name == "ModifyInventory")
                e.Value = "...";
        }

        /// <summary>
        /// Display an Inventory Item input form that allows the user to create a new Inventory record.
        /// </summary>
        private void AddInventoryButton_Click(object sender, EventArgs e)
        {
            AddOrModifiyInventoryItem(null);
        }

        /// <summary>
        /// This is the event handler for modifing or selecting an inventory item to remove.
        /// </summary>
        private void InventoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Modify Button Clicked
            if (InventoryGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                AddOrModifiyInventoryItem((Inventory)InventoryGridView.Rows[e.RowIndex].DataBoundItem);

            //Remove checkbox Clicked
            if (InventoryGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell removeCheckbox = (DataGridViewCheckBoxCell)InventoryGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                removeCheckbox.Value = (removeCheckbox.Value == null) ? true : !(bool)removeCheckbox.Value;
                InventoryGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = removeCheckbox.Value;

                Inventory itemToRemove = (Inventory)InventoryGridView.Rows[e.RowIndex].DataBoundItem;
                if ((bool)removeCheckbox.Value)
                    inventoryItemsToRemove.Add(itemToRemove);
                else
                    inventoryItemsToRemove.Remove(itemToRemove);
            }
        }

        private void AddOrModifiyInventoryItem(Inventory itemToModify)
        {
            using (InventoryForm inventoryManagement = new InventoryForm(itemToModify))
                if (inventoryManagement.ShowDialog() == DialogResult.OK)
                    ForceRefreshOfCurrentView();
        }
        
        private void RemoveInventoryButton_Click(object sender, EventArgs e)
        {
            if (inventoryItemsToRemove.Count < 1)
                return;

            //Make sure user wants to delete the selected recipes
            string warningMessage = "Are you sure you want to delete the selected items?";

            if (MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                InventoryTranslator.RemoveItemsFromDatabase(ref inventoryItemsToRemove);
                ForceRefreshOfCurrentView();
            }
        }
        #endregion

        #region Recipe Tab
        private void InitializeRecipeTab()
        {

        }

        /// <summary>
        /// This is where we make changes to the Recipe DataGridView for displaying at run time.
        /// ie, any formatting after the data has been loaded into the DataGridView.
        /// </summary>
        private void RecipeGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Set up tooltip and text for the button control in the Modify column
            foreach (DataGridViewRow row in RecipeGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Ensure We're only adding and modifiying the value (text) of the button column
                    if (cell.ColumnIndex == RecipeGridView.Columns["Modify"].Index)
                    {
                        cell.ToolTipText = "Click to modify this recipe.";
                        cell.Value = "...";
                    }
                }
            }
            
            //Tell the columns to fill up the entire size of the DataGridView Control        
            RecipeGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            RecipeGridView.AutoResizeColumns();
        }

        /// <summary>
        /// This is the event handler for modifing or selecting a recipe to remove.
        /// </summary>
        private void RecipeGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView recipeGrid = (DataGridView)sender;

            //Modify Button
            if (recipeGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >=0)
            {
                //We need to reference the recipe that was clicked
                //and pass that to the form that will handle the modifications
                //for the recipe

                Core.Recipe recipeToModify = (Core.Recipe) RecipeGridView.Rows[e.RowIndex].DataBoundItem;

                //If form.ShowDialog() == DialogResult.OK
                //{
                ////Do Update code here
                //}
            }
            //Remove checkbox
            else if (recipeGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                Core.Recipe recipeToRemove = (Core.Recipe)RecipeGridView.Rows[e.RowIndex].DataBoundItem;

                ////Prevent awkward duplication of trying to remove the same recipe more than once
                if (recipesToRemove.Contains(recipeToRemove) == false)
                    recipesToRemove.Add(recipeToRemove);
            }
        }

        private List<Core.Recipe> recipesToRemove = new List<Core.Recipe>();
        private void RecipeRemoveSelectedButton_Click(object sender, EventArgs e)
        {
            //Make sure user wants to delete the selected recipes
            string warningMessage = "Are you sure you want to delete the selected recipes?";

            if (MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (Core.Recipe recipe in recipesToRemove)
                {
                    //delete recipe
                }
                recipesToRemove = new List<Core.Recipe>();
            }
            
        }

        private void RecipeAddNewRecipeButton_Click(object sender, EventArgs e)
        {
            //Display the Add Recipe form
            //AddRecipeForm addRecipe = new AddRecipeForm();
            //if (addRecipe.ShowDialog() == DialogResult.Ok)
            //{
            //  Core.Recipe recipeToAdd = addRecipe.GetCreatedRecipe();
            //}
        }


        #endregion
    }
}
