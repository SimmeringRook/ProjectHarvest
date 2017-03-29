using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using System.ComponentModel;
using Core.Utilities.General;
using Core.Utilities.Database.Queries.BindingLists;
using Core.Utilities.Database.Queries.Tables;

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
            this._recipeToModify = (recipe != null) ? (Recipe) recipe.Clone() : recipe;
            recipe = null;
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
            IngredientInformation rowToBeAdded = (information != null) ? information : new IngredientInformation();
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

                rowToBeAdded.Type.DataBindings.Add(new Binding("SelectedItem", category, "Category", true, DataSourceUpdateMode.OnPropertyChanged));
                rowToBeAdded.Type.DataSource = category.ToList();
                rowToBeAdded.Type.DisplayMember = "Category";
                rowToBeAdded.Type.ValueMember = "Category";

                rowToBeAdded.Unit.DataBindings.Add(new Binding("SelectedItem", units, "Measurement", true, DataSourceUpdateMode.OnPropertyChanged));
                rowToBeAdded.Unit.DataSource = units.ToList();
                rowToBeAdded.Unit.DisplayMember = "Measurement";
                rowToBeAdded.Unit.ValueMember = "Measurement";

                rowToBeAdded.Selected.CheckStateChanged += Selected_CheckStateChanged;
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

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<IngredientInformation> ingredientInfoToKeep = new List<IngredientInformation>();
                List<IngredientInformation> ingredientInfoToDiscard = new List<IngredientInformation>();

                //Find out what needs to be deleted
                _Ingredients.ForEach(row => {
                    if (!row.Selected.Checked) { ingredientInfoToKeep.Add(row); }
                    else { ingredientInfoToDiscard.Add(row); }   
                });

                //Clear out the ingredient information list, which will be repopulated with
                //information from the ingredientInfoToKeep list.
                _Ingredients.Clear();

                //if this is an existing Recipe
                if (_recipeToModify != null)
                {
                    using (HarvestTableUtility harvest = new HarvestTableUtility(new RecipeIngredientQuery()))
                    {
                        List<int> recipeIngredientIDs = new List<int>();
                        List<Inventory> recipeInventoryItems = _recipeToModify.GetInventoryItems();
                        //Get the inventoryIDs for each recipe ingredient to be deleted
                        foreach (Inventory recipeInventoryItem in recipeInventoryItems)
                            ingredientInfoToDiscard.ForEach(ingredientInfo =>
                            {
                                if (ingredientInfo.Name.Text.Equals(recipeInventoryItem.IngredientName))
                                    recipeIngredientIDs.Add(recipeInventoryItem.InventoryID);
                            });

                        //Remove the recipe ingredients from the database
                        recipeIngredientIDs.ForEach(ingredientInventoryID =>
                        {
                            RecipeIngredient recipeIngredient = _recipeToModify.GetIngredients().Single(ingredient => ingredient.InventoryID == ingredientInventoryID);
                            harvest.Remove(recipeIngredient);
                        });

                        //allow GC
                        recipeInventoryItems.Clear();
                        recipeIngredientIDs.Clear();
                    }
                }
                
                //Delete everything from the table
                recipeTableLayout.RowCount = _numberOfRows = 0;
                recipeTableLayout.Controls.Clear();
                recipeTableLayout.RowStyles.Clear();

                //Rebuild table layout
                ingredientInfoToKeep.ForEach(row =>
                {
                    //Clear out obsolete references
                    row.Type.DataBindings.Clear();
                    row.Unit.DataBindings.Clear();
                    row.Selected.CheckStateChanged -= Selected_CheckStateChanged;
                    //Create the row
                    AddNewIngredientRow(row);
                });

                //allow GC
                ingredientInfoToDiscard.Clear();
                ingredientInfoToKeep.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            removeSelectedButton.Enabled = false;
        }
    }
}