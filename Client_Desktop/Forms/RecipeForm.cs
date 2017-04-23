using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Utilities.General;
using Core.Adapters.Objects;
using Core.Adapters;
using Core.Utilities.Validation;
using System.ComponentModel;
using Core.Utilities.UnitConversions;

namespace Client_Desktop
{
    public partial class RecipeForm : Form
    {
        private Recipe _recipe = null;
        private int _numberOfRows;
        private List<IngredientInformation> _listOfIngredients = new List<IngredientInformation>();
        
        public RecipeForm(Recipe recipe)
        {
            InitializeComponent();
             _recipe = recipe;

            try
            {
                categoryCombo.DataSource = HarvestAdapter.RecipeCategories.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecipeForm_Load(object sender, EventArgs e)
        {
            _numberOfRows = recipeTableLayout.RowCount - 1;
            subtractButton.Enabled = (_listOfIngredients.Count > 1);

            this.Text = "New Recipe";

            if (_recipe != null)
                _DisplayRecipe();
            else
                AddNewIngredientRow();
        }

        private void _DisplayRecipe()
        {
            this.Text = _recipe.Name;

            //Populate Recipe Controls with Information
            RecipeNameTextBox.Text = _recipe.Name;
            categoryCombo.SelectedIndex = categoryCombo.Items.IndexOf(_recipe.Category);
            servingsTextbox.Text = _recipe.Servings.ToString();

            //Create rows for each ingredient and populate
            for (int i = 0; i < _recipe.AssociatedIngredients.Count; i++)
            {
                AddNewIngredientRow();
                _listOfIngredients[i].LoadExistingData(_recipe.AssociatedIngredients[i]);
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
            rowToBeAdded.Selected.CheckStateChanged += (object sender, EventArgs e) => { removeSelectedButton.Enabled = _listOfIngredients.Any(row => row.Selected.Checked); };

            try
            {
                rowToBeAdded.Category.DataSource = HarvestAdapter.IngredientCategories.ToList();
                rowToBeAdded.Unit.DataSource = HarvestAdapter.Measurements.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            _listOfIngredients.Add(rowToBeAdded);
            _numberOfRows++;
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

            _listOfIngredients.Remove(_listOfIngredients.Last());
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            List<IngredientInformation> ingredientInfoToKeep = new List<IngredientInformation>();
            List<IngredientInformation> ingredientInfoToDiscard = new List<IngredientInformation>();

            //Find out what needs to be deleted
            _listOfIngredients.ForEach(row => {
                if (!row.Selected.Checked) { ingredientInfoToKeep.Add(row); }
                else { ingredientInfoToDiscard.Add(row); }
            });

            //if this is an existing Recipe
            if (_recipe != null)
            {
                //Delete the record tying the Ingredient to the Recipe
                try
                {
                    foreach (IngredientInformation ingredientToDelete in ingredientInfoToDiscard)
                    {
                        var ingredient = _recipe.AssociatedIngredients.Single(ing => ing.Inventory.Name.Equals(ingredientToDelete.Name.Text));
                        _recipe.AssociatedIngredients.Remove(ingredient);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            ClearIngredientTableLayout();
            ingredientInfoToDiscard.Clear();

            RebuildIngredientTableLayout(ingredientInfoToKeep);

            removeSelectedButton.Enabled = false;
        }
        #endregion

        private void ClearIngredientTableLayout()
        {
            _listOfIngredients.Clear();

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
                row.Category.DataBindings.Clear();
                row.Unit.DataBindings.Clear();
                //Create the row
                AddNewIngredientRow(row);
            }
            ingredientsToKeep.Clear();
        }
        #endregion

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (IsValid() == false)
                return;
            try
            {
                if (_recipe != null)
                {
                    CheckForChangesToRecipe();
                }
                else
                {
                    Recipe newRecipe = GetRecipeFromControls();
                    HarvestAdapter.Recipes.Add(newRecipe);

                    foreach (var ingredient in _listOfIngredients)
                        newRecipe.AssociatedIngredients.Add(ingredient.GetRecipeIngredient(newRecipe.ID));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.DialogResult = DialogResult.OK;
        }

        #region Create New Object Or Update Existing
        private Recipe GetRecipeFromControls()
        {
            Recipe temp = new Recipe();
            temp.Name = RecipeNameTextBox.Text;
            temp.Category = categoryCombo.SelectedValue.ToString();
            temp.Servings = double.Parse(servingsTextbox.Text);
            return temp;
        }

        private void CheckForChangesToRecipe()
        {
            if (_recipe.Name.Equals(RecipeNameTextBox.Text) == false) _recipe.Name = RecipeNameTextBox.Text;
            if (_recipe.Category.Equals(categoryCombo.SelectedValue.ToString()) == false) _recipe.Category = categoryCombo.SelectedValue.ToString();
            if (_recipe.Servings.Equals(double.Parse(servingsTextbox.Text)) == false) _recipe.Servings = double.Parse(servingsTextbox.Text);

            foreach (IngredientInformation ingredientRow in _listOfIngredients)
                CheckForChangesToIngredient(ingredientRow);
        }

        private void CheckForChangesToIngredient(IngredientInformation row)
        {
            RecipeIngredient ingredient = _recipe.AssociatedIngredients.SingleOrDefault(item => item.Equals(row.GetRecipeIngredient(_recipe.ID)));
            if (ingredient == null)
            {
                _recipe.AssociatedIngredients.Add(ingredient);
            }  
            else
            {
                if (ingredient.Inventory.Name.Equals(row.Name.Text) == false) ingredient.Inventory.Name = row.Name.Text;
                if (ingredient.Amount.Equals(double.Parse(row.Quantity.Text)) == false) ingredient.Amount = double.Parse(row.Quantity.Text);
                if (ingredient.Measurement.ToString().Equals(row.Unit.Text) == false) ingredient.Measurement = (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), row.Unit.Text);
            }
        }
        #endregion

        #region Input Validation
        private bool IsValid()
        {
            bool noErrors = true;

            //Validate Recipe
            if (HarvestValidator.Validate(RecipeNameTextBox, HarvestRegex.Name, recipeErrorProvider) == false ||
                HarvestValidator.Validate(servingsTextbox, HarvestRegex.Amount, recipeErrorProvider) == false)
                noErrors = false;

            //Validate Ingredients
            foreach (var row in _listOfIngredients)
            {
                if (HarvestValidator.Validate(row.Name, HarvestRegex.Name, recipeErrorProvider) == false ||
                    HarvestValidator.Validate(row.Quantity, HarvestRegex.Amount, recipeErrorProvider) == false)
                    noErrors = false;
            }

            return noErrors;
        }
        private void recipeNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            HarvestValidator.Validate(RecipeNameTextBox, HarvestRegex.Name, recipeErrorProvider);
        }

        private void servingsTextbox_Validating(object sender, CancelEventArgs e)
        {
            HarvestValidator.Validate(servingsTextbox, HarvestRegex.Amount, recipeErrorProvider);
        }


        #endregion

        #region IDisposable
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

            _recipe = null;
            _listOfIngredients = null;

            base.Dispose(disposing);
        }
        #endregion
    }
}