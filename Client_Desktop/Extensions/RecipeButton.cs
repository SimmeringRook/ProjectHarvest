using Core;
using System;
using System.Windows.Forms;

namespace Client_Desktop.Extensions
{
    public class RecipeButton : Button
    {
        public Recipe Recipe { get; private set; }

        public RecipeButton(Recipe recipe)
        {
            this.Recipe = recipe;
            this.Anchor = AnchorStyles.None;
            this.Text = recipe.RecipeName;
            this.Tag = "Recipe";
            this.Click += new System.EventHandler(ShowRecipe_Click);
        }


        public void ShowRecipe_Click(object sender, EventArgs e)
        {
            using (RecipeForm recipe = new RecipeForm((sender as RecipeButton).Recipe))
            {
                if (recipe.ShowDialog() == DialogResult.OK)
                {
                    //var rbut = sender as RecipeButton;
                    //var flow = rbut.Parent;
                    //var table = flow.Parent;
                    //var tabTable = table.Parent;
                    //var tabPage = tabTable.Parent;
                    //var tabControl = tabPage.Parent;
                    //HarvestForm harvest = tabControl.Parent as HarvestForm;
                    //harvest.RefreshCurrentTab();
                    //MessageBox.Show(tabControl.Parent.Name);
                }
                    return;
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.Recipe = null;
            base.Dispose(disposing);
        }
    }
}
