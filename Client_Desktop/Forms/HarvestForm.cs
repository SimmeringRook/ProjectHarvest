using Client_Desktop.Extensions;
using Core.Adapters;
using Core.Adapters.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Client_Desktop
{
    public partial class HarvestForm : Form
    {
        private List<Inventory> inventoryItemsToRemove = new List<Inventory>();
        private PlannedWeek currentWeek;
        public HarvestForm()
        {
            InitializeComponent();

            try
            {
                //using (HarvestTableUtility harvestTables = new HarvestTableUtility(new LastLaunchedQuery()))
                //{
                //    if ((harvestTables.Get(null) as List<LastLaunched>).Count < 1)
                //    {
                //        currentWeek = new PlannedWeek(DateTime.Today.Date, DateTime.Today.AddDays(6).Date);
                //        LastLaunched today = new LastLaunched();
                //        today.Date = DateTime.Today.Date;
                //        harvestTables.Insert(today);
                //    }
                //    else
                //    {
                //        DateTime firstLaunched = new DateTime();
                //        firstLaunched = (harvestTables.Get(-1) as List<LastLaunched>).First().Date;
                //        currentWeek = new PlannedWeek(firstLaunched, firstLaunched.AddDays(6));
                //    }
                //}

                RefreshCurrentTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (ex.InnerException != null)
                {
                    using (StreamWriter writer = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "errorLog.txt")))
                    {
                        string lines = ex.Message;
                        if (ex.InnerException != null)
                        {
                            lines += "\n" + ex.InnerException.Message;
                            if (ex.InnerException.InnerException != null)
                                lines += "\n" + ex.InnerException.InnerException.Message;
                        }
                        writer.WriteLine(lines);
                    }
                }
                
            }
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
            try
            {
                RefreshCurrentTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Loads the relevant table for the current TabPage, and rebinds the table to the datagridview
        /// </summary>
        public void RefreshCurrentTab()
        {
            DataGridView gridOnTab = GetDataGridForTabPage(pantryTabControl.SelectedTab);
            switch (pantryTabControl.SelectedIndex)
            {
                case 0:
                    LoadWeek();
                    break;
                case 1:
                    gridOnTab.DataSource = HarvestAdapter.InventoryItems;
                    break;
                case 2:
                    gridOnTab.DataSource = HarvestAdapter.InventoryItems;
                    break;
            }
            pantryTabControl.SelectedTab.Refresh();
        }

        private static DataGridView GetDataGridForTabPage(TabPage selectedTab)
        {
            foreach (Control control in selectedTab.Controls)
                if (control is TableLayoutPanel)
                    foreach (Control ctrl in control.Controls)
                        if (ctrl is DataGridView)
                            return ctrl as DataGridView;
            return null;
        }

        private void LoadWeek()
        {
            ClearControls();

            foreach (Control flowLayout in weekTableLayout.Controls)
            {
                flowLayout.Controls.Add(new PlanButton(this));

                int currentDay = weekTableLayout.GetColumn(flowLayout);
                string mealTime = HarvestAdapter.MealTimes[weekTableLayout.GetRow(flowLayout)];

                if (currentWeek.DaysOfWeek[currentDay].MealsForDay[mealTime].Count > 0)
                    foreach (Recipe plannedRecipe in currentWeek.DaysOfWeek[currentDay].MealsForDay[mealTime])
                        flowLayout.Controls.Add(new PlannedRecipeControl(this, plannedRecipe, currentWeek.DaysOfWeek[currentDay].Day, mealTime));
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

        #endregion

        #region Meal Tab

        public void AddRecipeToThisWeek(PlannedRecipeControl recipePrefab)
        {
            int dayOfWeek = weekTableLayout.GetColumn(recipePrefab.Parent);
            string mealTime = HarvestAdapter.MealTimes[weekTableLayout.GetRow(recipePrefab.Parent)];
                if (currentWeek.DaysOfWeek[dayOfWeek].MealsForDay[mealTime].Contains(recipePrefab.RecipeButton.Recipe) == false)
                    currentWeek.DaysOfWeek[dayOfWeek].MealsForDay[mealTime].Add(recipePrefab.RecipeButton.Recipe);
        }

        public void RemoveRecipeFromThisWeek(PlannedRecipeControl recipePrefab)
        {
            int dayOfWeek = weekTableLayout.GetColumn(recipePrefab.Parent);
            string mealTime = HarvestAdapter.MealTimes[weekTableLayout.GetRow(recipePrefab.Parent)];

            currentWeek.DaysOfWeek[dayOfWeek].MealsForDay[mealTime].Remove(recipePrefab.RecipeButton.Recipe);
            
            recipePrefab = null;
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control flowControl in weekTableLayout.Controls)
                foreach (Control control in flowControl.Controls)
                    if (control is PlannedRecipeControl)
                    {
                        RecipeButton button = (control as PlannedRecipeControl).RecipeButton;
                        int dayIndex = weekTableLayout.GetColumn(flowControl);
                        string mealTime = HarvestAdapter.MealTimes[weekTableLayout.GetRow(flowControl)];

                        if (currentWeek.DaysOfWeek[dayIndex].MealsForDay[mealTime].Any(r => r.ID == button.Recipe.ID) == false)
                            currentWeek.DaysOfWeek[dayIndex].MealsForDay[mealTime].Add(button.Recipe);
                    }

            using (GroceryListForm groceryList = new GroceryListForm(currentWeek))
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
            Inventory item = (Inventory)InventoryGridView.Rows[e.RowIndex].DataBoundItem;
            if (InventoryGridView.Columns[e.ColumnIndex].Name == "Measurement")
                e.Value = item.Measurement;

            if (InventoryGridView.Columns[e.ColumnIndex].Name == "FoodCategory")
                e.Value = item.Category;

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
                    if (Core.Adapters.HarvestAdapter.Recipes.Any(r => r.AssociatedIngredients.Any(ri => ri.Inventory.ID == inventory.ID)) == false)
                    {
                        Core.Adapters.HarvestAdapter.InventoryItems.Remove(inventory);
                    }    
                    else
                    {
                        string recipeBoundItemErrorMessage = ", because it is required for at least one recipe. It must be removed from the recipe before it can be deleted from the Inventory.";
                        MessageBox.Show("Unable to delete " + inventory.Name + recipeBoundItemErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });

                RefreshCurrentTab();
            }
            inventoryItemsToRemove.Clear();
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
                DisplayRecipeForm((Recipe)RecipeGridView.Rows[e.RowIndex].DataBoundItem);
            }

            //Remove checkbox
            else if (recipeGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                Recipe recipeToRemove = (Recipe)RecipeGridView.Rows[e.RowIndex].DataBoundItem;

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
                        Core.Adapters.HarvestAdapter.Remove_Recipe(recipe);
                    
                    RefreshCurrentTab();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void DisplayRecipeForm(Recipe recipeToModify)
        {
            // Display the Add Recipe form
            using (RecipeForm addRecipe = new RecipeForm(recipeToModify))
            {
                if (addRecipe.ShowDialog() == DialogResult.OK)
                    RefreshCurrentTab();
            }
        }

        private void RecipeAddNewRecipeButton_Click(object sender, EventArgs e)
        {
            DisplayRecipeForm(null);
        }
        #endregion
    }
}
