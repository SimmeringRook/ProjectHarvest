using Core;
using System;
using System.Windows.Forms;

namespace Client_Desktop.Extensions
{
    public class PlannedRecipeControl
    {
        public FlowLayoutPanel Container;
        public RecipeButton RecipeButton;
        private Button deleteButton;
        private HarvestForm mainForm;

        public PlannedRecipeControl(HarvestForm mainForm, Recipe selectedRecipe)
        {
            this.mainForm = mainForm;

            Container = new FlowLayoutPanel();
            Container.Margin = new Padding(5, 2, 0, 2);
            Container.AutoSize = true;
            Container.BorderStyle = BorderStyle.FixedSingle;

            RecipeButton = new RecipeButton(selectedRecipe);
            Container.Controls.Add(RecipeButton);

            deleteButton = newDeleteButton();
            Container.Controls.Add(deleteButton);

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
            Control parentOfParent = Container.Parent;

            //Remove recipe from plan
            mainForm.RemoveRecipeFromThisWeek(this);

            RecipeButton = null;

            deleteButton = null;
            Container.Controls.Clear();
            parentOfParent.Controls.Remove(Container);
        }
        #endregion

    }
}
