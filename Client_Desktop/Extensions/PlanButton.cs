using Core.Adapters;
using Core.Adapters.Objects;
using System;
using System.Linq;
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

                    HarvestAdapter.PlannedMeals.Add(meal);

                    PlannedRecipeControl recipePrefab = new PlannedRecipeControl(meal);
                    ((Button)sender).Parent.Controls.Add(recipePrefab);
                }

            }
        }

    }
}
