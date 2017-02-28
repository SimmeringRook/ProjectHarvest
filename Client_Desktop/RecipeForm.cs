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
            //Make sure controls exist and are not null before loading anything
            InitializeComponent();

            //Need to Populate the Combo Before -possibly- loading a recipe to modify
            using (HarvestEntities context = new HarvestEntities())
            {
                context.RecipeClass.Load();
                categoryCombo.DataSource = context.RecipeClass.Local.ToBindingList();
            }

            numberOfRows = recipeTableLayout.RowCount - 1;
            //Handle the possiblity of modifying an existing recipe
            if (recipeToModify != null)
            {
                DisplayRecipeToModify(recipeToModify);
            }
            else
            {
                AddNewIngredientRow();
                subtractButton.Enabled = false;
            }
        }

        private void DisplayRecipeToModify(Recipe recipeToModify)
        {
           
            int index = RecipeUtility.GetRecipeCategoryFromRecipe(recipeToModify);
            if (index == -1)
            {
                //TODO:: Do something useful with this error
                MessageBox.Show("There was an error looking up the recipe's information.");
            }
            else
            {
                //Recipe First
                RecipeNameTextBox.Text = recipeToModify.RecipeName;
                categoryCombo.SelectedItem = categoryCombo.Items[index];
                servingsTextbox.Text = recipeToModify.Servings.ToString();
                
                //Now Ingredients:
                using (HarvestEntities context = new HarvestEntities())
                {
                    var ingredients = context.RecipeIngredient.Where(r => r.RecipeID == recipeToModify.RecipeID).ToList();
                    
                    for (int i = 0; i < ingredients.Count; i++)
                    {
                        AddNewIngredientRow();
                        Ingredients[i].LoadExistingData(ingredients[i]);
                    }
                }
            }

            
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



            IngredientInformation rowToBeAdded = new IngredientInformation();
            var units = GetListForMetric();


            recipeTableLayout.Controls.Add(rowToBeAdded.Name, 0, numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Quantity, 1, numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Unit, 2, numberOfRows);

            //Apparently the databinding needs to happen after the ComboBox has been added to the form
            //otherwise Unit.Items will always be "0" and not let you set the pre-set value when loading in a recipe
            rowToBeAdded.Unit.DataBindings.Add(new Binding("SelectedValue", units, "Measurement", true));
            rowToBeAdded.Unit.DataSource = units.ToList();
            rowToBeAdded.Unit.DisplayMember = "Measurement";
            rowToBeAdded.Unit.ValueMember = "Measurement";

            //This also means that we should only need one combo box template function in IngredientInformation,
            //Since the assignment needs to occur after the control has been added.

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
