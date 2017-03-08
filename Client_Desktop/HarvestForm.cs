using Core;
using Core.DatabaseUtilities;
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
            ForceRefreshOfCurrentView();
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
            try
            {
                using (HarvestEntities context = new HarvestEntities())
                {
                    switch (pantryTabControl.SelectedIndex)
                    {
                        case 0:
                            //Meal Planning stuff goes here
                            LoadWeek();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Meal Tab

        private void LoadWeek()
        {
            foreach (Control flow in weekTableLayout.Controls)
            {
                if (flow.Controls.Count < 1)
                    flow.Controls.Add(CreatePlanMealButton());
            }

                
        }

        private Button CreateMealButton(Recipe selectedRecipe)
        {
            Button template = new Button();
            template.Anchor = AnchorStyles.Top;
            template.Text = selectedRecipe.RecipeName;
            return template;
        }
        private Button CreatePlanMealButton()
        {
            Button template = new Button();
            template.Anchor = AnchorStyles.Top;
            template.Text = "- Plan -";
            template.Click += new System.EventHandler(this.PlanMealButton_Click);
            return template;
        }
        private void PlanMealButton_Click(object sender, EventArgs e)
        {
            using(RecipePickerForm picker = new RecipePickerForm())
            {
                if (picker.ShowDialog() == DialogResult.OK)
                {
                    Control parentOfClickedButton = ((Button)sender).Parent;
                    parentOfClickedButton.Controls.Remove((Button)sender);
                    parentOfClickedButton.Controls.Add(CreateMealButton(picker.SelectedRecipe));
                    parentOfClickedButton.Controls.Add(CreatePlanMealButton());
                }
            }
        }
        #endregion

        #region Inventory Tab
        /// <summary>
        /// Translate MetricID and FoodTypeID into respective strings; assign the text value to the modify button
        /// </summary>
        private void InventoryGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (InventoryGridView.Columns[e.ColumnIndex].Name == "FoodCategory")
                e.Value = InventoryUtility.GetFoodCategoryByRowPostion(e.RowIndex);

            if (InventoryGridView.Columns[e.ColumnIndex].Name == "Measurement")
                e.Value = InventoryUtility.GetMeasurementNameByItemID(e.RowIndex);

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
                InventoryUtility.RemoveItemsFromDatabase(ref inventoryItemsToRemove);
                ForceRefreshOfCurrentView();
            }
        }
        #endregion

        #region Recipe Tab

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
                AddOrModifiyRecipeItem((Recipe)RecipeGridView.Rows[e.RowIndex].DataBoundItem);
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

        private List<Recipe> recipesToRemove = new List<Recipe>();
        private void RecipeRemoveSelectedButton_Click(object sender, EventArgs e)
        {
            //Make sure user wants to delete the selected recipes
            string warningMessage = "Are you sure you want to delete the selected recipes?";

            if (MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    foreach (Recipe recipe in recipesToRemove)
                        RecipeUtility.RemoveRecipeFromDatabase(recipe);
                    recipesToRemove = new List<Recipe>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void AddOrModifiyRecipeItem(Recipe recipeToModify)
        {
            // Display the Add Recipe form
            using (RecipeForm addRecipe = new RecipeForm(recipeToModify))
            {
                if (addRecipe.ShowDialog() == DialogResult.OK)
                    ForceRefreshOfCurrentView();
            }
                
           
        }

        private void RecipeAddNewRecipeButton_Click(object sender, EventArgs e)
        {
            AddOrModifiyRecipeItem(null);
        }




        #endregion

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
