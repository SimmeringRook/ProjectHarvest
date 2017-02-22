using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.DatabaseUtilities;
using Client_Desktop.Helpers;

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

        private void AddNewIngredientRow()
        {
            recipeTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            IngredientInformation rowToBeAdded = new IngredientInformation();

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

            return temp;
        }
    }
}
