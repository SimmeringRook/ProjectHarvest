using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Utilities.General;
using Core.Adapters.Objects;
using Core.Adapters;
using Core.Utilities.Validation;
using System.ComponentModel;

namespace Client_Desktop
{
    public partial class RecipeForm : Form
    {
        private int _numberOfRows;
        private List<IngredientInformation> _Ingredients = new List<IngredientInformation>();
        private Recipe _recipeToModify;

        public RecipeForm(Recipe recipe)
        {
            InitializeComponent();

            _numberOfRows = recipeTableLayout.RowCount - 1;
            LoadRecipe(recipe);
            subtractButton.Enabled = (_Ingredients.Count > 1);
        }
        
        private void LoadRecipe(Recipe recipe)
        {
            try
            {
                if (recipe != null)
                {
                    _recipeToModify = HarvestAdapter.Recipes.Single(r => r.ID == recipe.ID);
                    DisplayRecipeToModify();
                }
                else
                {
                    AddNewIngredientRow();
                }
                categoryCombo.DataSource = HarvestAdapter.RecipeCategories.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            recipe = null;
        }

        private void DisplayRecipeToModify()
        {
            //Populate Recipe Controls with Information
            RecipeNameTextBox.Text = _recipeToModify.Name;
            categoryCombo.SelectedValue = _recipeToModify.Category;
            servingsTextbox.Text = _recipeToModify.Servings.ToString();

            //Create rows for each ingredient and populate
            for (int i = 0; i < _recipeToModify.AssociatedIngredients.Count; i++)
            {
                AddNewIngredientRow();
                _Ingredients[i].LoadExistingData(_recipeToModify.AssociatedIngredients[i]);
            }
            RecipeNameTextBox.Focus();
        }

        #region Row Management

        #region Add Rows
        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewIngredientRow();
            subtractButton.Enabled = (_numberOfRows > 1);
        }

        private void AddNewIngredientRow(IngredientInformation information = null)
        {
            IngredientInformation rowToBeAdded = (information != null) ? information : new IngredientInformation(isEditable: true, formErrorProvider: recipeErrorProvider);
            recipeTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            for (int column = 0; column < rowToBeAdded.Controls.Count; column++)
                recipeTableLayout.Controls.Add(rowToBeAdded.Controls[column], column, _numberOfRows);

            rowToBeAdded.Selected.CheckStateChanged += Selected_CheckStateChanged;

            try
            {
                Binding typeBinding = new Binding("SelectedItem", HarvestAdapter.IngredientCategories.ToList(), "", true, DataSourceUpdateMode.OnPropertyChanged);
                rowToBeAdded.SetDataBindings(rowToBeAdded.Type, typeBinding);

                Binding unitBinding = new Binding("SelectedItem", HarvestAdapter.Measurements.ToList(), "", true, DataSourceUpdateMode.OnPropertyChanged);
                rowToBeAdded.SetDataBindings(rowToBeAdded.Unit, unitBinding);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            _Ingredients.Add(rowToBeAdded);
            _numberOfRows++;
        }

        private void Selected_CheckStateChanged(object sender, EventArgs e)
        {
            removeSelectedButton.Enabled = _Ingredients.Any(row => row.Selected.Checked);
        }

        #endregion

        #region Remove Rows
        private void subtractButton_Click(object sender, EventArgs e)
        {
            RemoveRow();
            subtractButton.Enabled = (_numberOfRows > 1);
        }

        private void RemoveRow()
        {
            _numberOfRows--;

            for (int i = 0; i < recipeTableLayout.ColumnCount; i++)
            {
                Control controlToRemove = recipeTableLayout.GetControlFromPosition(i, _numberOfRows);
                recipeTableLayout.Controls.Remove(controlToRemove);
            }

            recipeTableLayout.RowStyles.RemoveAt(_numberOfRows - 1);
            recipeTableLayout.RowCount = _numberOfRows - 1;

            _Ingredients.Remove(_Ingredients.Last());
        }
        #endregion

        #endregion

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (IsValid() == false)
                return;

            try
            {
                if (_recipeToModify != null)
                {//update
                    CheckForChangesToRecipe();
                    foreach (var i in _Ingredients)
                    {
                        var newRI = i.GetRecipeIngredient(_recipeToModify.ID);
                        if (_recipeToModify.AssociatedIngredients.Contains(newRI) == false)
                            _recipeToModify.AssociatedIngredients.Add(newRI);
                    }
                }
                else
                {//create
                    
                    HarvestAdapter.Recipes.Add(GetRecipeFromControls());
                    var temp = HarvestAdapter.Recipes.Last();
                    foreach (var ingredient in _Ingredients)
                    {
                        temp.AssociatedIngredients.Add(ingredient.GetRecipeIngredient(temp.ID));
                    }
                    

                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void RecipeNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            HarvestValidator.Validate(RecipeNameTextBox, HarvestRegex.Name, recipeErrorProvider);
        }

        private void servingsTextbox_Validating(object sender, CancelEventArgs e)
        {
            HarvestValidator.Validate(servingsTextbox, HarvestRegex.Amount, recipeErrorProvider);
        }

        private bool IsValid()
        {
            bool noErrors = true;

            //Validate Recipe
            if (HarvestValidator.Validate(RecipeNameTextBox, HarvestRegex.Name, recipeErrorProvider) == false ||
                HarvestValidator.Validate(servingsTextbox, HarvestRegex.Amount, recipeErrorProvider) == false)
                noErrors = false;

            //Validate Ingredients
            foreach (var row in _Ingredients)
            {
                if (HarvestValidator.Validate(row.Name, HarvestRegex.Name, recipeErrorProvider) == false ||
                    HarvestValidator.Validate(row.Quantity, HarvestRegex.Amount, recipeErrorProvider) == false)
                    noErrors = false;
            }

            return noErrors;
        }

        private Recipe GetRecipeFromControls()
        {
            Recipe temp = new Recipe();
            temp.Name = RecipeNameTextBox.Text;
            temp.Category = categoryCombo.SelectedValue.ToString();
            temp.Servings = double.Parse(servingsTextbox.Text);
            temp.ID = 0;
            return temp;
        }

        private void CheckForChangesToRecipe()
        {
            if (_recipeToModify.Name.Equals(RecipeNameTextBox.Text) == false) _recipeToModify.Name = RecipeNameTextBox.Text;
            if (_recipeToModify.Category.Equals(categoryCombo.SelectedValue.ToString()) == false) _recipeToModify.Category = categoryCombo.SelectedValue.ToString();
            if (_recipeToModify.Servings.Equals(double.Parse(servingsTextbox.Text)) == false) _recipeToModify.Servings = double.Parse(servingsTextbox.Text);
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            List<IngredientInformation> ingredientInfoToKeep = new List<IngredientInformation>();
            List<IngredientInformation> ingredientInfoToDiscard = new List<IngredientInformation>();

            //Find out what needs to be deleted
            _Ingredients.ForEach(row => {
                if (!row.Selected.Checked) { ingredientInfoToKeep.Add(row); }
                else { ingredientInfoToDiscard.Add(row); }   
            });

            //if this is an existing Recipe
            if (_recipeToModify != null)
            {
                //Delete the record tying the Ingredient to the Recipe
                try
                {
                    foreach (IngredientInformation ingredientToDelete in ingredientInfoToDiscard)
                    {
                        var ingredient = _recipeToModify.AssociatedIngredients.Single(ing => ing.Inventory.Name.Equals(ingredientToDelete.Name.Text));
                        _recipeToModify.AssociatedIngredients.Remove(ingredient);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            ClearIngredientTableLayout();
            RebuildIngredientTableLayout(ingredientInfoToKeep);

            //allow GC
            ingredientInfoToDiscard.Clear();
            ingredientInfoToKeep.Clear();
            removeSelectedButton.Enabled = false;
        }

        private void ClearIngredientTableLayout()
        {
            _Ingredients.Clear();

            //Delete everything from the table
            recipeTableLayout.RowCount = _numberOfRows = 0;
            recipeTableLayout.Controls.Clear();
            recipeTableLayout.RowStyles.Clear();
        }

        private void RebuildIngredientTableLayout(List<IngredientInformation> ingredientsToKeep)
        {
            foreach (IngredientInformation row in ingredientsToKeep)
            {
                //Clear out obsolete references
                row.Type.DataBindings.Clear();
                row.Unit.DataBindings.Clear();
                row.Selected.CheckStateChanged -= Selected_CheckStateChanged;
                //Create the row
                AddNewIngredientRow(row);
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            _recipeToModify = null;
            _Ingredients = null;

            base.Dispose(disposing);
        }
    }
}