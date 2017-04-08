using Core.Adapters.Objects;
using System;
using System.Windows.Forms;

namespace Client_Desktop.Extensions
{
    public class PlannedRecipeControl : FlowLayoutPanel
    {
        //public FlowLayoutPanel Container;
        public RecipeButton RecipeButton;
        private Button deleteButton;
        private HarvestForm mainForm;
        private DateTime dayPlanned;
        private string mealTime;

        public PlannedRecipeControl(HarvestForm mainForm, Recipe selectedRecipe, DateTime dayPlanned, string mealTime)
        {
            this.mainForm = mainForm;
            this.dayPlanned = dayPlanned;
            this.mealTime = mealTime;

            //Container = new FlowLayoutPanel();
            this.Margin = new Padding(5, 2, 0, 2);
            this.AutoSize = true;
            this.BorderStyle = BorderStyle.FixedSingle;

            RecipeButton = new RecipeButton(selectedRecipe);
            this.Controls.Add(RecipeButton);

            deleteButton = newDeleteButton();
            this.Controls.Add(deleteButton);

        }

        #region Delete Button
        private Button newDeleteButton()
        {
            Button delete = new Button();
            delete.Text = "X";
            delete.Size = new System.Drawing.Size(20, RecipeButton.Height);
            delete.Click += new EventHandler(deleteButton_Click);
            return delete;
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            Control parentOfParent = this.Parent;

            //Remove recipe from plan
            mainForm.RemoveRecipeFromThisWeek(this);

            RecipeButton = null;

            deleteButton = null;
            this.Controls.Clear();
            parentOfParent.Controls.Remove(this);
        }
        #endregion

    }
}
