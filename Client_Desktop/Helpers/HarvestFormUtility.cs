using Core;
using Core.DatabaseUtilities.BindingListQueries;
using Core.DatabaseUtilities.Queries;
using Core.MealPlanning;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Client_Desktop.Helpers
{
    public static class HarvestFormUtility
    {
        /// <summary>
        /// Loads the relevant table for the current TabPage, and rebinds the table to the datagridview
        /// </summary>
        public static void RefreshCurrentTab(TabControl pantryTabs)
        {
            DataGridView gridOnTab = GetDataGridForTabPage(pantryTabs.SelectedTab);
            switch (pantryTabs.SelectedIndex)
            {
                case 0:
                    foreach (Control control in pantryTabs.SelectedTab.Controls)
                        if (control is TableLayoutPanel)
                            foreach(Control cntrl in control.Controls)
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
            pantryTabs.SelectedTab.Refresh();
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

        private static void LoadWeek(TableLayoutPanel weekTableLayout)
        {
            //TODO UpdateWeekDayHeader()
            List<MealTime> mealTimes = new List<MealTime>();
            using (HarvestUtility harvest = new HarvestUtility(new MealTimeQuery()))
                mealTimes = harvest.Get(-1) as List<MealTime>;
            PlannedWeek thisWeek = new PlannedWeek(DateTime.Today.Date, DateTime.Today.AddDays(6).Date);

            foreach (Control flowLayout in weekTableLayout.Controls)
            {
                if (flowLayout.Controls.Count < 1)
                    flowLayout.Controls.Add(CreatePlanMealButton());

                int currentMealTime = weekTableLayout.GetRow(flowLayout);
                int currentDay = weekTableLayout.GetColumn(flowLayout);
                MealTime mealTime = mealTimes[currentMealTime];

                if (thisWeek.DaysOfWeek[currentDay].MealsForDay[mealTime].Count > 0)
                    foreach (Recipe plannedRecipe in thisWeek.DaysOfWeek[currentDay].MealsForDay[mealTimes[currentMealTime]])
                        flowLayout.Controls.Add(new RecipeButton(plannedRecipe));
            }
        }

        private static Button CreatePlanMealButton()
        {
            Button template = new Button();
            template.Anchor = AnchorStyles.Top;
            template.Text = "- Plan -";
            template.Tag = "Plan";
            template.Click += new System.EventHandler(PlanMealButton_Click);
            return template;
        }

        private static void PlanMealButton_Click(object sender, EventArgs e)
        {
            using (RecipePickerForm picker = new RecipePickerForm())
            {
                if (picker.ShowDialog() == DialogResult.OK)
                    ((Button)sender).Parent.Controls.Add(new RecipeButton(picker.SelectedRecipe));
            }
        }
    }
}
