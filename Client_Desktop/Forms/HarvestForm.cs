using Client_Desktop.Extensions;
using Core;
using Core.MealPlanning;
using Core.Utilities.Database.Queries.BindingLists;
using Core.Utilities.Database.Queries.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                using (HarvestTableUtility harvestTables = new HarvestTableUtility(new LastLaunchedQuery()))
                {
                    if ((harvestTables.Get(null) as List<LastLaunched>).Count < 1)
                    {
                        currentWeek = new PlannedWeek(DateTime.Today.Date, DateTime.Today.AddDays(6).Date);
                        LastLaunched today = new LastLaunched();
                        today.Date = DateTime.Today.Date;
                        harvestTables.Insert(today);
                    }
                    else
                    {
                        DateTime firstLaunched = new DateTime();
                        firstLaunched = (harvestTables.Get(-1) as List<LastLaunched>).First().Date;
                        currentWeek = new PlannedWeek(firstLaunched, firstLaunched.AddDays(6));
                    }
                }

                RefreshCurrentTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    foreach (Control control in pantryTabControl.SelectedTab.Controls)
                        if (control is TableLayoutPanel)
                            foreach (Control cntrl in control.Controls)
                                if (cntrl.Tag.Equals("Week"))
                                    LoadWeek(cntrl as TableLayoutPanel);
                    break;
                case 1:
                    using (HarvestBindingListUtility harvestBindingList = new HarvestBindingListUtility(new InventoryBindingListQuery()))
                        gridOnTab.DataSource = (harvestBindingList.GetBindingList() as BindingList<Inventory>).ToList();
                    break;
                case 2:
                    using (HarvestBindingListUtility harvestBindingList = new HarvestBindingListUtility(new RecipeBindingListQuery()))
                        gridOnTab.DataSource = (harvestBindingList.GetBindingList() as BindingList<Recipe>).ToList();
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

        private void LoadWeek(TableLayoutPanel weekTableLayout)
        {
            ClearControls(weekTableLayout);

            //TODO UpdateWeekDayHeader()
            List<MealTime> mealTimes = new List<MealTime>();
            using (HarvestTableUtility harvest = new HarvestTableUtility(new MealTimeQuery()))
                mealTimes = (harvest.Get(-1) as List<MealTime>).ToList();
            

            foreach (Control flowLayout in weekTableLayout.Controls)
            {
                flowLayout.Controls.Add(new PlanButton(this));

                int currentMealTime = weekTableLayout.GetRow(flowLayout);
                int currentDay = weekTableLayout.GetColumn(flowLayout);
                MealTime mealTime = mealTimes[currentMealTime];

                if (currentWeek.DaysOfWeek[currentDay].MealsForDay[mealTime].Count > 0)
                    foreach (Recipe plannedRecipe in currentWeek.DaysOfWeek[currentDay].MealsForDay[mealTimes[currentMealTime]])
                        flowLayout.Controls.Add(new PlannedRecipeControl(this, plannedRecipe));
                
            }
        }

        private static void ClearControls(TableLayoutPanel weekTableLayout)
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
            int mealTime = weekTableLayout.GetRow(recipePrefab.Parent);

            using (HarvestTableUtility harvest = new HarvestTableUtility(new MealTimeQuery()))
            {
                List<MealTime> mealTimes = (harvest.Get(-1) as List<MealTime>).ToList();

                if (currentWeek.DaysOfWeek[dayOfWeek].MealsForDay[mealTimes[mealTime]].Contains(recipePrefab.RecipeButton.Recipe) == false)
                    currentWeek.DaysOfWeek[dayOfWeek].MealsForDay[mealTimes[mealTime]].Add(recipePrefab.RecipeButton.Recipe);
            }
        }

        public void RemoveRecipeFromThisWeek(PlannedRecipeControl recipePrefab)
        {
            int dayOfWeek = weekTableLayout.GetColumn(recipePrefab.Parent);
            int mealTime = weekTableLayout.GetRow(recipePrefab.Parent);

            using (HarvestTableUtility harvest = new HarvestTableUtility(new MealTimeQuery()))
            {
                List<MealTime> mealTimes = (harvest.Get(-1) as List<MealTime>).ToList();
                currentWeek.DaysOfWeek[dayOfWeek].MealsForDay[mealTimes[mealTime]].Remove(recipePrefab.RecipeButton.Recipe);
            }
            
            recipePrefab = null;
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: fix this with information from datetime picker controls on Meal Planning Tab
            //DateTime start = DateTime.Today;
            //PlannedWeek plannedWeek = new PlannedWeek(start, start.AddDays(6));

            List<MealTime> mealTimes = new List<MealTime>();
            using (HarvestTableUtility harvest = new HarvestTableUtility(new MealTimeQuery()))
                mealTimes = harvest.Get(-1) as List<MealTime>;

            foreach (Control flowControl in weekTableLayout.Controls)
                foreach (Control control in flowControl.Controls)
                    if (control is PlannedRecipeControl)
                    {
                        RecipeButton button = (control as PlannedRecipeControl).RecipeButton;
                        int dayIndex = weekTableLayout.GetColumn(flowControl);
                        MealTime mealTime = mealTimes[weekTableLayout.GetRow(flowControl)];
                        if (currentWeek.DaysOfWeek[dayIndex].MealsForDay[mealTime].Any(r => r.RecipeID == button.Recipe.RecipeID) == false)
                            currentWeek.DaysOfWeek[dayIndex].MealsForDay[mealTime].Add(button.Recipe);
                    }

            try
            {
                using (HarvestTableUtility harvest = new HarvestTableUtility(new PlannedMealQuery()))
                {
                    //Restrict list to only planned meals that fall within plannedMeals_Week's dates
                    List<PlannedMeals> plannedMeals_DB = (harvest.Get(-1) as List<PlannedMeals>).Where(
                        p =>
                        p.DatePlanned >= currentWeek.StartOfWeek.Date &&
                        p.DatePlanned <= currentWeek.EndOfWeek.Date
                        ).ToList();

                    List<PlannedMeals> plannedMeals_Week = currentWeek.GetPlannedMeals(); 
                    //If there are existing plans
                    List<PlannedMeals> newPlannedMeals = (plannedMeals_DB.Count > 0) 
                        ? new List<PlannedMeals>() //If there are records in the database for this week
                        //initialize a new list for the missing recipes to be added to
                        : plannedMeals_Week;
                    //otherwise, there are no records in the database, so everything on the form needs to be added in

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

            using (GroceryListForm groceryList = new GroceryListForm(currentWeek))
            {
                if (groceryList.ShowDialog() == DialogResult.OK)
                {
                    groceryList.Dispose();
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
                using(HarvestTableUtility harvest = new HarvestTableUtility(new RecipeIngredientQuery()))
                {
                    inventoryItemsToRemove.ForEach(inventory =>
                    {
                        if ((harvest.Get(-1) as List<RecipeIngredient>).Any(ri => ri.InventoryID == inventory.InventoryID) == false)
                        {
                            harvest.HarvestQuery = new InventoryQuery();
                            harvest.Remove(inventory);
                            harvest.HarvestQuery = new RecipeIngredientQuery();
                        }    
                        else
                        {
                            string recipeBoundItemErrorMessage = ", because it is required for at least one recipe. It must be removed from the recipe before it can be deleted from the Inventory.";
                            MessageBox.Show("Unable to delete " + inventory.IngredientName + recipeBoundItemErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }

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
                    using (HarvestTableUtility harvest = new HarvestTableUtility(new RecipeIngredientQuery()))
                        foreach (Recipe recipe in recipesToRemove)
                        {
                            recipe.GetIngredients().ForEach(ingredient => { harvest.Remove(ingredient); });

                            harvest.HarvestQuery = new PlannedMealQuery();
                            var plansWithThisRecipe = (harvest.Get(-1) as List<PlannedMeals>).Where(p => p.RecipeID == recipe.RecipeID).ToList();
                            plansWithThisRecipe.ForEach(plan => { harvest.Remove(plan); });

                            harvest.HarvestQuery = new RecipeQuery();
                            harvest.Remove(recipe);
                        }
                    recipesToRemove.Clear();
                    RefreshCurrentTab();
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
                    RefreshCurrentTab();
            }
                
           
        }

        private void RecipeAddNewRecipeButton_Click(object sender, EventArgs e)
        {
            AddOrModifiyRecipeItem(null);
        }




        #endregion
    }
}
