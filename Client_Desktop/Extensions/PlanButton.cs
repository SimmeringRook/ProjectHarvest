using Core.Adapters;
using Core.Adapters.Objects;
using System;
using System.Windows.Forms;

namespace Client_Desktop.Extensions
{
    public class PlanButton : Button
    {
        private DateTime dayPlanned;
        private string mealTime;

        public PlanButton(DateTime dayplanned, string mealTime)
        {
            this.Anchor = AnchorStyles.Top;
            this.Text = "- Plan -";
            this.Tag = "Plan";
            this.dayPlanned = dayplanned;
            this.mealTime = mealTime;
            this.Click += new System.EventHandler(PlanMealButton_Click);
        }

        private void PlanMealButton_Click(object sender, EventArgs e)
        {
            using (RecipePickerForm picker = new RecipePickerForm())
            {
                if (picker.ShowDialog() == DialogResult.OK)
                {
                    PlannedMeal meal = new PlannedMeal();
                    meal.PlannedRecipe = picker.SelectedRecipe;
                    meal.Date = dayPlanned;
                    meal.MealTime = mealTime;

                    if (HarvestAdapter.PlannedMeals.Contains(meal))
                    {
                        string errorMessage = string.Format("You already have {0} planned for {1} on {2}.", meal.PlannedRecipe.Name, meal.MealTime, meal.Date.DayOfWeek.ToString());
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        HarvestAdapter.PlannedMeals.Add(meal);

                        PlannedRecipeControl recipePrefab = new PlannedRecipeControl(meal);
                        ((Button)sender).Parent.Controls.Add(recipePrefab);
                    }
                }
            }
        }
    }
}
