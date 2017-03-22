﻿using Client_Desktop.Extensions;
using Core;
using Core.MealPlanning;
using Core.Utilities.Database.Queries.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //TODO: fix this with information from datetime picker controls on Meal Planning Tab
            DateTime start = DateTime.Today;
            PlannedWeek plannedWeek = new PlannedWeek(start, start.AddDays(6));

            List<MealTime> mealTimes = new List<MealTime>();
            using (HarvestTableUtility harvest = new HarvestTableUtility(new MealTimeQuery()))
                mealTimes = harvest.Get(-1) as List<MealTime>;

            foreach (Control flowControl in weekTableLayout.Controls)
                foreach (Control control in flowControl.Controls)
                    if (control is RecipeButton)
                    {
                        RecipeButton button = control as RecipeButton;
                        int dayIndex = weekTableLayout.GetColumn(flowControl);
                        MealTime mealTime = mealTimes[weekTableLayout.GetRow(flowControl)];
                        plannedWeek.DaysOfWeek[dayIndex].MealsForDay[mealTime].Add(button.Recipe);
                    }

            try
            {
                using (HarvestTableUtility harvest = new HarvestTableUtility(new PlannedMealQuery()))
                {
                    //Restrict list to only planned meals that fall within plannedMeals_Week's dates
                    List<PlannedMeals> plannedMeals_DB = (harvest.Get(-1) as List<PlannedMeals>).Where(
                        p =>
                        p.DatePlanned >= plannedWeek.StartOfWeek.Date &&
                        p.DatePlanned <= plannedWeek.EndOfWeek.Date
                        ).ToList();

                    List<PlannedMeals> plannedMeals_Week = plannedWeek.GetPlannedMeals();
                    List<PlannedMeals> newPlannedMeals = (plannedMeals_DB.Count > 0) ? new List<PlannedMeals>() : plannedMeals_Week;

                    //If there are already existing meals for this week, make sure we're not trying to duplicate recipes for each MealTime
                    foreach (var plan in plannedMeals_Week)
                        foreach (var planned in plannedMeals_DB)
                            if (newPlannedMeals.Contains(plan) == false && plan.Equals(planned) == false)
                                newPlannedMeals.Add(plan);

                    //Add any new planned recipes to the database
                    foreach (var newMeal in newPlannedMeals)
                        harvest.Update(newMeal);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            using (GroceryListForm groceryList = new GroceryListForm(plannedWeek))
            {
                if (groceryList.ShowDialog() == DialogResult.OK)
                    groceryList.Dispose();
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
                using (HarvestTableUtility harvest = new HarvestTableUtility(new MetricQuery()))
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
                using(HarvestTableUtility harvest = new HarvestTableUtility(new InventoryQuery()))
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