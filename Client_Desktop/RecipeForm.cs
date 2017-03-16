using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.DatabaseUtilities;
using Client_Desktop.Helpers;
using System.ComponentModel;

using Core.DatabaseUtilities.BindingListQueries;

namespace Client_Desktop
{
    public partial class RecipeForm : Form
    {
        private int numberOfRows;
        private List<IngredientInformation> Ingredients = new List<IngredientInformation>();
        private Recipe recipeToModify;
        public RecipeForm(Recipe recipeToModify)
        {
            InitializeComponent();
            this.recipeToModify = recipeToModify;
            try
            {
                using (HarvestBindingListUtility harvestBindingList = new HarvestBindingListUtility(new RecipeCategoryBindingList()))
                    categoryCombo.DataSource = harvestBindingList.GetBindingList() as BindingList<RecipeClass>;

                numberOfRows = recipeTableLayout.RowCount - 1;

                if (recipeToModify != null)
                    DisplayRecipeToModify(recipeToModify);
                else
                    AddNewIngredientRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (Ingredients.Count < 2)
                subtractButton.Enabled = false;
        }

        private void DisplayRecipeToModify(Recipe recipeToModify)
        {
            recipeToModify.PopulateGUIProperties();

            //Populate Recipe Controls with Information
            RecipeNameTextBox.Text = recipeToModify.RecipeName;
            categoryCombo.SelectedValue = recipeToModify.RecipeCategory;
            servingsTextbox.Text = recipeToModify.Servings.ToString();

            //Create rows for each ingredient and populate
            for (int i = 0; i < recipeToModify.AssociatedInventoryItems.Count; i++)
            {
                AddNewIngredientRow();
                Ingredients[i].LoadExistingData(recipeToModify.AssociatedIngredients[i]);
            }
        }

        #region Row Management

        #region Add Rows
        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewIngredientRow();

            if (numberOfRows >= 2)
                subtractButton.Enabled = true;
        }

        private void AddNewIngredientRow()
        {
            IngredientInformation rowToBeAdded = new IngredientInformation();
            recipeTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            recipeTableLayout.Controls.Add(rowToBeAdded.Name, 0, numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Type, 1, numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Quantity, 2, numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Unit, 3, numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Selected, 4, numberOfRows);

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

            Ingredients.Add(rowToBeAdded);
            numberOfRows++;
        }

        #endregion

        #region Remove Rows
        private void subtractButton_Click(object sender, EventArgs e)
        {
            RemoveRow();
            if (numberOfRows == 1)
                subtractButton.Enabled = false;
        }

        private void RemoveRow()
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
        }
        #endregion

        #endregion

        private void addModifyRecipeButton_Click(object sender, EventArgs e)
        {
            // TODO add validation check
            try
            {
                CreateRecipeUtility.SubmitRecipeAndIngredientsToDatabase(GetRecipeFromControls(), Ingredients);
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
            temp.RecipeID = (recipeToModify != null) ? recipeToModify.RecipeID : 0;
            return temp;
        }       
    }
}