using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using System.ComponentModel;
using Core.Utilities.General;
using Core.Utilities.Database.Queries.BindingLists;

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
            this._recipeToModify = (Recipe) recipe.Clone();
            try
            {
                using (HarvestBindingListUtility harvestBindingList = new HarvestBindingListUtility(new RecipeCategoryBindingList()))
                    categoryCombo.DataSource = harvestBindingList.GetBindingList() as BindingList<RecipeClass>;

                _numberOfRows = recipeTableLayout.RowCount - 1;

                if (_recipeToModify != null)
                    DisplayRecipeToModify();
                else
                    AddNewIngredientRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (_Ingredients.Count < 2)
                subtractButton.Enabled = false;
        }

        private void DisplayRecipeToModify()
        {
            //Populate Recipe Controls with Information
            RecipeNameTextBox.Text = _recipeToModify.RecipeName;
            categoryCombo.SelectedValue = _recipeToModify.RCategory;
            servingsTextbox.Text = _recipeToModify.Servings.ToString();

            //Create rows for each ingredient and populate
            var ingredients = _recipeToModify.GetIngredients();
            for (int i = 0; i < ingredients.Count; i++)
            {
                AddNewIngredientRow();
                _Ingredients[i].LoadExistingData(ingredients[i]);
            }
        }

        #region Row Management

        #region Add Rows
        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewIngredientRow();

            if (_numberOfRows >= 2)
                subtractButton.Enabled = true;
        }

        private void AddNewIngredientRow()
        {
            IngredientInformation rowToBeAdded = new IngredientInformation();
            recipeTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            recipeTableLayout.Controls.Add(rowToBeAdded.Name, 0, _numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Type, 1, _numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Quantity, 2, _numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Unit, 3, _numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Selected, 4, _numberOfRows);

            try
            {
                BindingList<IngredientCategory> category = null;
                BindingList<Metric> units = null;

                using (HarvestBindingListUtility harvestBindingList = new HarvestBindingListUtility(new IngredientCategoryBindingListQuery()))
                {
                    category = harvestBindingList.GetBindingList() as BindingList<IngredientCategory>;

                    harvestBindingList.HarvestBindingList = new MetricBindingListQuery();
                    units = harvestBindingList.GetBindingList() as BindingList<Metric>;
                }

                rowToBeAdded.Type.DataBindings.Add(new Binding("SelectedValue", category, "Category", true));
                rowToBeAdded.Type.DataSource = category.ToList();
                rowToBeAdded.Type.DisplayMember = "Category";
                rowToBeAdded.Type.ValueMember = "Category";


                rowToBeAdded.Unit.DataBindings.Add(new Binding("SelectedValue", units, "Measurement", true));
                rowToBeAdded.Unit.DataSource = units.ToList();
                rowToBeAdded.Unit.DisplayMember = "Measurement";
                rowToBeAdded.Unit.ValueMember = "Measurement";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            _Ingredients.Add(rowToBeAdded);
            _numberOfRows++;
        }

        #endregion

        #region Remove Rows
        private void subtractButton_Click(object sender, EventArgs e)
        {
            RemoveRow();
            if (_numberOfRows == 1)
                subtractButton.Enabled = false;
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

        private void addModifyRecipeButton_Click(object sender, EventArgs e)
        {
            // TODO add validation check
            try
            {
                CreateRecipeUtility.SubmitRecipeAndIngredientsToDatabase(GetRecipeFromControls(), _Ingredients);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
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
            temp.RecipeID = (_recipeToModify != null) ? _recipeToModify.RecipeID : 0;
            return temp;
        }       
    }
}