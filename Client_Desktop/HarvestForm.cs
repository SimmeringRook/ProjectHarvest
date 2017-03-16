using Client_Desktop.Helpers;
using Core;
using Core.DatabaseUtilities;
using Core.DatabaseUtilities.BindingListQueries;
using Core.DatabaseUtilities.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            try
            {
                HarvestFormUtility.RefreshCurrentTab(pantryTabControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pantryTabControl_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                HarvestFormUtility.RefreshCurrentTab(pantryTabControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Meal Tab

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<PlannedMealDay> plannedMealsForTheWeek = new List<PlannedMealDay>();

            for (int i = 0; i < weekTableLayout.ColumnCount; i++)
                plannedMealsForTheWeek.Add(new PlannedMealDay(DateTime.Today.AddDays(i)));

            foreach (Control flowControl in weekTableLayout.Controls)
            {
                int mealTime = weekTableLayout.GetRow(flowControl);
                List<string> recipeNames = new List<string>();

                foreach (Control plannedMeal in flowControl.Controls)
                    if (plannedMeal.Tag.Equals("Recipe"))
                        recipeNames.Add(plannedMeal.Text);

                plannedMealsForTheWeek[weekTableLayout.GetColumn(flowControl)].ConvertRecipeNamesIntoRecipes(mealTime, recipeNames);
            }


            // --Note-- This code only exists to verify that the objects are being created correctly
            // Replace this bit with something to the effect of:

            // using (GroceryListForm groceryList = new GroceryListForm(plannedMealsForTheWeek))

            foreach (var plan in plannedMealsForTheWeek)
            {
                string recipeNames = plan.Day.ToString() + "\n";
                foreach (KeyValuePair<MealTime, List<Recipe>> keyValuePair in plan.MealsPlanned)
                    foreach (Recipe recipe in keyValuePair.Value)
                        recipeNames += recipe.RecipeName + "\n";

                if (!recipeNames.Equals(plan.Day.ToString() + "\n"))
                    MessageBox.Show(recipeNames);
            }

        }

        #endregion

        #region Inventory Tab
        /// <summary>
        /// Translate MetricID and FoodTypeID into respective strings; assign the text value to the modify button
        /// </summary>
        private void InventoryGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                using (HarvestUtility harvest = new HarvestUtility(new MetricQuery()))
                {
                    Inventory item = (Inventory)InventoryGridView.Rows[e.RowIndex].DataBoundItem;
                    if (InventoryGridView.Columns[e.ColumnIndex].Name == "Measurement")
                        e.Value = (harvest.Get(item.InventoryID) as Metric).Measurement;

                    harvest.HarvestQuery = new IngredientCategoryQuery() as IHarvestQuery;
                    if (InventoryGridView.Columns[e.ColumnIndex].Name == "FoodCategory")
                        e.Value = (harvest.Get(item.InventoryID) as IngredientCategory).Category;

                    if (InventoryGridView.Columns[e.ColumnIndex].Name == "ModifyInventory")
                        e.Value = "...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    HarvestFormUtility.RefreshCurrentTab(pantryTabControl);
        }
        
        private void RemoveInventoryButton_Click(object sender, EventArgs e)
        {
            if (inventoryItemsToRemove.Count < 1)
                return;

            //Make sure user wants to delete the selected recipes
            string warningMessage = "Are you sure you want to delete the selected items?";

            if (MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                using(HarvestUtility harvest = new HarvestUtility(new InventoryQuery()))
                {
                    foreach (Inventory itemToRemove in inventoryItemsToRemove)
                    {
                        //TODO handle bound to recipe
                        harvest.Remove(itemToRemove);
                    }
                }

                HarvestFormUtility.RefreshCurrentTab(pantryTabControl);
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
                        throw new NotImplementedException();
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
                    HarvestFormUtility.RefreshCurrentTab(pantryTabControl);
            }
                
           
        }

        private void RecipeAddNewRecipeButton_Click(object sender, EventArgs e)
        {
            AddOrModifiyRecipeItem(null);
        }




        #endregion
    }
}
