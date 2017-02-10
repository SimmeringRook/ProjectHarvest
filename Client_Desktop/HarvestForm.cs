using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client_Desktop
{
    public partial class HarvestForm : Form
    {
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
            TabControl selected = (TabControl)sender;

            switch (selected.SelectedIndex)
            {
                case 0:
                    InitializeMealTab();
                    break;
                case 1:
                    InitializeInventoryTab();
                    break;
                case 2:
                    InitializeRecipeTab();
                    break;
                default:
                    break;
            }
        }

        #region Meal Tab
        private void InitializeMealTab()
        {

        }
        #endregion

        #region Inventory Tab
        private void InitializeInventoryTab()
        {

        }
        
        private void AddInventoryButton_Click(object sender, EventArgs e)
        {
            //Display the Inventory form
            //InventoryForm inventoryManagement = new InventoryForm();
            //if (inventoryManagement.ShowDialog() == DialogResult.Ok)
            //{
            //  Core.Inventory itemToAdd = inventoryManagement.GetCreatedItem();
            //}
        }

        private List<Core.Inventory> inventoryItemsToRemove = new List<Core.Inventory>();
        private void RemoveInventoryButton_Click(object sender, EventArgs e)
        {
            //Make sure user wants to delete the selected recipes
            string warningMessage = "Are you sure you want to delete the selected items?";

            if (MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (Core.Inventory item in inventoryItemsToRemove)
                {
                    //This is probably where we need to check if the item is relevant to another recipe
                    //and inform the user, and prevent this item from being deleted


                    //delete item
                }
                inventoryItemsToRemove = new List<Core.Inventory>();
            }
        }

        /// <summary>
        /// This is where we make changes to the Inventory DataGridView for displaying at run time.
        /// ie, any formatting after the data has been loaded into the DataGridView.
        /// </summary>
        private void InventoryGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
        /// This is the event handler for modifing or selecting an inventory item to remove.
        /// </summary>
        private void InventoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView inventoryGrid = (DataGridView)sender;

            //Modify Button
            if (inventoryGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //We need to reference the recipe that was clicked
                //and pass that to the form that will handle the modifications
                //for the recipe

                Core.Inventory itemToModify = (Core.Inventory)InventoryGridView.Rows[e.RowIndex].DataBoundItem;

                //If form.ShowDialog() == DialogResult.OK
                //{
                ////Do Update code here
                //}
            }
            //Remove checkbox
            else if (inventoryGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                Core.Inventory itemToModify = (Core.Inventory)InventoryGridView.Rows[e.RowIndex].DataBoundItem;

                ////Prevent awkward duplication of trying to remove the same item more than once
                if (inventoryItemsToRemove.Contains(itemToModify) == false)
                    inventoryItemsToRemove.Add(itemToModify);
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
