using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Desktop.Extensions
{
    public class PlanButton : Button
    {
        private HarvestForm mainForm;
        private DateTime dayplanned;
        private MealTime mealTime;
        public PlanButton(HarvestForm mainForm, DateTime dayplanned, MealTime mealTime)
        {
            this.mainForm = mainForm;
            this.Anchor = AnchorStyles.Top;
            this.Text = "- Plan -";
            this.Tag = "Plan";
            this.dayplanned = dayplanned;
            this.mealTime = mealTime;
            this.Click += new System.EventHandler(PlanMealButton_Click);
        }

        private void PlanMealButton_Click(object sender, EventArgs e)
        {
            using (RecipePickerForm picker = new RecipePickerForm())
            {
                if (picker.ShowDialog() == DialogResult.OK)
                {
                    var recipePrefab = new PlannedRecipeControl(mainForm, picker.SelectedRecipe, dayplanned, mealTime);
                    ((Button)sender).Parent.Controls.Add(recipePrefab);

                    mainForm.AddRecipeToThisWeek(recipePrefab);
                }

            }
        }

    }
}
