using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.DatabaseUtilities;
using Client_Desktop.Helpers;
using System.Data.Entity;
using System.ComponentModel;

namespace Client_Desktop
{
    public partial class RecipeForm : Form
    {
        private int numberOfRows;
        private List<IngredientInformation> Ingredients = new List<IngredientInformation>();

        public RecipeForm(Recipe recipeToModify)
        {
            if (recipeToModify != null)
                DisplayRecipeToModify();

            InitializeComponent();

            using (HarvestEntities context = new HarvestEntities())
            {
                context.RecipeClass.Load();
                categoryCombo.DataSource = context.RecipeClass.Local.ToBindingList();
               
            }

            numberOfRows = recipeTableLayout.RowCount - 1;
            AddNewIngredientRow();
            subtractButton.Enabled = false;


        }

        private void DisplayRecipeToModify()
        {

        }

        #region Row Management
        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewIngredientRow();
        }

        private BindingList<Metric> GetListForMetric()
        {
            BindingList<Metric> units = new BindingList<Metric>();
            try
            {
                using (HarvestEntities context = new HarvestEntities())
                {
                    context.Metric.Load();
                    units = context.Metric.Local.ToBindingList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            return units;
        }

        private void AddNewIngredientRow()
        {
            recipeTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));



            IngredientInformation rowToBeAdded = new IngredientInformation(GetListForMetric());

            recipeTableLayout.Controls.Add(rowToBeAdded.Name, 0, numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Quantity, 1, numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Unit, 2, numberOfRows);
            //TODO fix
            //recipeTableLayout.Controls.Add(rowToBeAdded.Type, 3, numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Selected, 3, numberOfRows);

            Ingredients.Add(rowToBeAdded);
            numberOfRows++;

            if (numberOfRows >= 2)
                subtractButton.Enabled = true;
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            numberOfRows--;

            for (int i = 0; i < recipeTableLayout.ColumnCount; i++)
            {
                Control controlToRemove = recipeTableLayout.GetControlFromPosition(i, numberOfRows);
                recipeTableLayout.Controls.Remove(controlToRemove);
            }

            recipeTableLayout.RowStyles.RemoveAt(numberOfRows - 1);
            recipeTableLayout.RowCount = numberOfRows - 1;

            Ingredients.Remove(Ingredients.Last());

            if (numberOfRows == 1)
                subtractButton.Enabled = false;
        }
        #endregion


        private void addModifyRecipeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Recipe newRecipe = GetRecipeFromControls();

                foreach (IngredientInformation ingredient in Ingredients)
                    newRecipe.AssociatedItems.Add(ingredient.GetInventoryFromControls());

                RecipeUtility.UpdateRecipeInDatabase(newRecipe);
                RecipeIngredientUtility.UpdateTable(newRecipe);

                this.DialogResult = DialogResult.OK;
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private Recipe GetRecipeFromControls()
        {
            Recipe temp = new Recipe();
            temp.RecipeName = RecipeNameTextBox.Text;
            temp.RCategory = categoryCombo.SelectedValue.ToString();
            temp.Servings = int.Parse(servingsTextbox.Text);
            return temp;
        }
    }
}
