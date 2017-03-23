using System;
using System.Windows.Forms;

namespace Client_Desktop.Extensions
{
    public static class HarvestFormUtility
    {
        public static Button CreatePlanMealButton()
        {
            Button template = new Button();
            template.Anchor = AnchorStyles.Top;
            template.Text = "- Plan -";
            template.Tag = "Plan";
            template.Click += new System.EventHandler(PlanMealButton_Click);
            return template;
        }

        public static void PlanMealButton_Click(object sender, EventArgs e)
        {
            using (RecipePickerForm picker = new RecipePickerForm())
            {
                if (picker.ShowDialog() == DialogResult.OK)
                    ((Button)sender).Parent.Controls.Add(new RecipeButton(picker.SelectedRecipe));
            }
        }
    }
}
