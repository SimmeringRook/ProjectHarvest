using Client_Desktop.Extensions;
using Core.Adapters;
using Core.Adapters.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client_Desktop
{

    public partial class HarvestForm : Form
    {
        private List<Inventory> inventoryItemsToRemove = new List<Inventory>();
        private List<Recipe> recipesToRemove = new List<Recipe>();

        public HarvestForm()
        {     
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            RefreshCurrentTab();
        }

        #region Main Form Functionality
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TechHelp contactForm = new TechHelp())
                contactForm.ShowDialog();
        }

        private void pantryTabControl_Selected(object sender, TabControlEventArgs e)
        {
            RefreshCurrentTab();
        }

        public void RefreshCurrentTab()
        {
            try
            {
                switch (pantryTabControl.SelectedIndex)
                {
                    case 0:
                        LoadWeek();
                        break;
                    case 1:
                        InventoryGridView.DataSource = HarvestAdapter.InventoryItems.ToList();
                        break;
                    case 2:
                        RecipeGridView.DataSource = HarvestAdapter.Recipes.ToList();
                        break;
                }
                pantryTabControl.SelectedTab.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to retrieve information from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Core.Utilities.Logging.Logger.Log(ex);
            }
        }
        #endregion

        #region Meal Tab
        private void LoadWeek()
        {
            ClearControls();

            foreach (Control flowLayout in weekTableLayout.Controls)
            {
                int dayIndex = weekTableLayout.GetColumn(flowLayout);
                DateTime currentDay = HarvestAdapter.CurrentWeek.DaysOfWeek[dayIndex].Day;
                string mealTime = HarvestAdapter.MealTimes[weekTableLayout.GetRow(flowLayout)];

                flowLayout.Controls.Add(new PlanButton(currentDay, mealTime));

                if (HarvestAdapter.CurrentWeek.DaysOfWeek[dayIndex].MealsForDay.Count > 0)
                    foreach (PlannedMeal plannedRecipe in HarvestAdapter.CurrentWeek.DaysOfWeek[dayIndex].MealsForDay)
                        if (plannedRecipe.MealTime.Equals(mealTime))
                            flowLayout.Controls.Add(new PlannedRecipeControl(plannedRecipe));
            }
        }

        private void ClearControls()
        {
            foreach (Control flowLayout in weekTableLayout.Controls)
            {
                var buttons = flowLayout.Controls;
                flowLayout.Controls.Clear();
                foreach (Control button in buttons)
                    button.Dispose();
                buttons = null;
            }
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (GroceryListForm groceryList = new GroceryListForm())
            {
                if (groceryList.ShowDialog() == DialogResult.OK)
                    RefreshCurrentTab();
            }
        }
        #endregion

        #region Inventory Tab
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
                    RefreshCurrentTab();
        }
        
        private void RemoveInventoryButton_Click(object sender, EventArgs e)
        {
            if (inventoryItemsToRemove.Count < 1)
                return;

            //Make sure user wants to delete the selected recipes
            string warningMessage = "Are you sure you want to delete the selected items?";
            if (MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                inventoryItemsToRemove.ForEach(inventory =>
                {
                    try
                    {
                        if (HarvestAdapter.Recipes.Any(r => r.AssociatedIngredients.Any(ri => ri.Inventory.ID == inventory.ID)) == false)
                            HarvestAdapter.InventoryItems.Remove(inventory);
                        else
                            MessageBox.Show(
                                "Unable to delete " + inventory.Name + ", because it is required for at least one recipe. " + inventory.Name + " must be removed from the recipe(s) before it can be deleted from the Inventory.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occured while trying to retrieve information from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Core.Utilities.Logging.Logger.Log(ex);
                    }
                });

                RefreshCurrentTab();
            }
            inventoryItemsToRemove.Clear();
        }
        #endregion

        #region Recipe Tab
        private void RecipeGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Set up tooltip and text for the button control in the Modify column
            foreach (DataGridViewRow row in RecipeGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == RecipeGridView.Columns["Modify"].Index)
                    {
                        cell.ToolTipText = "Click to modify this recipe.";
                        cell.Value = "...";
                    }
                }
            }
        }

        /// <summary>
        /// This is the event handler for modifing or selecting a recipe to remove.
        /// </summary>
        private void RecipeGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RecipeGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DisplayRecipeForm((Recipe)RecipeGridView.Rows[e.RowIndex].DataBoundItem);
            }
            else if (RecipeGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                Recipe recipeToRemove = (Recipe)RecipeGridView.Rows[e.RowIndex].DataBoundItem;
                if (recipesToRemove.Contains(recipeToRemove) == false)
                    recipesToRemove.Add(recipeToRemove);
            }
        }

        private void RecipeAddNewRecipeButton_Click(object sender, EventArgs e)
        {
            DisplayRecipeForm(null);
        }

        private void DisplayRecipeForm(Recipe recipeToModify)
        {
            using (RecipeForm addRecipe = new RecipeForm(recipeToModify))
            {
                if (addRecipe.ShowDialog() == DialogResult.OK)
                    RefreshCurrentTab();
            }
        }

        private void RecipeRemoveSelectedButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Recipe recipe in recipesToRemove)
                {
                    if (HarvestAdapter.PlannedMeals.Any(meal => meal.PlannedRecipe.Equals(recipe)))
                        MessageBox.Show("You must removed all planned meals for " + recipe.Name + " before it can be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        if (MessageBox.Show("Are you sure you want to delete the selected recipes?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            HarvestAdapter.Recipes.Remove(recipe);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to retrieve information from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Core.Utilities.Logging.Logger.Log(ex);
            }
            RefreshCurrentTab();
        }
        #endregion
    }
}