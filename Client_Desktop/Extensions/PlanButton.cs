using System;
using System.Windows.Forms;

namespace Client_Desktop.Extensions
{
    public class PlanButton : Button
    {
        private HarvestForm mainForm;
        public PlanButton(HarvestForm mainForm)
        {
            this.mainForm = mainForm;
            this.Anchor = AnchorStyles.Top;
            this.Text = "- Plan -";
            this.Tag = "Plan";
            this.Click += new System.EventHandler(PlanMealButton_Click);
        }

        private void PlanMealButton_Click(object sender, EventArgs e)
        {
            using (RecipePickerForm picker = new RecipePickerForm())
            {
                if (picker.ShowDialog() == DialogResult.OK)
                {
                    //var recipePrefab = new PlannedRecipeControl(mainForm, picker.SelectedRecipe, );
                    //((Button)sender).Parent.Controls.Add(recipePrefab);

                    //mainForm.AddRecipeToThisWeek(recipePrefab);
                }

            }
        }

    }
}
