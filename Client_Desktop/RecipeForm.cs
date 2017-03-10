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
            try
            {
                using(HarvestUtility harvest = new HarvestUtility(new RecipeCategoryQuery()))
                {
                    //Recipe First
                    RecipeNameTextBox.Text = recipeToModify.RecipeName;
                    categoryCombo.SelectedValue = (harvest.Get(recipeToModify.RecipeID) as RecipeClass).RCategory;
                    servingsTextbox.Text = recipeToModify.Servings.ToString();

                    //Now Ingredients:
                    using (HarvestEntities harvestDatabase = new HarvestEntities())
                    {
                        var ingredients = harvestDatabase.RecipeIngredient.Where(r => r.RecipeID == recipeToModify.RecipeID).ToList();

                        for (int i = 0; i < ingredients.Count; i++)
                        {
                            AddNewIngredientRow();
                            Ingredients[i].LoadExistingData(ingredients[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

   

        #region Row Management
        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewIngredientRow();
        }

        private BindingList<IngredientCategory> GetListForType()
        {
            BindingList<IngredientCategory> category = new BindingList<IngredientCategory>();
            try
            {
                using (HarvestEntities context = new HarvestEntities())
                {
                    context.IngredientCategory.Load();
                    category = context.IngredientCategory.Local.ToBindingList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong!!!");
            }
            return category;
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
            var category = GetListForType();

            recipeTableLayout.Controls.Add(rowToBeAdded.Name, 0, numberOfRows);

            recipeTableLayout.Controls.Add(rowToBeAdded.Type, 1, numberOfRows);
                        
            rowToBeAdded.Type.DataBindings.Add(new Binding("SelectedValue", category, "Category", true));
            rowToBeAdded.Type.DataSource = category.ToList();
            rowToBeAdded.Type.DisplayMember = "Category";
            rowToBeAdded.Type.ValueMember = "Category";


            recipeTableLayout.Controls.Add(rowToBeAdded.Quantity, 2, numberOfRows);
            recipeTableLayout.Controls.Add(rowToBeAdded.Unit, 3, numberOfRows);

            //Apparently the databinding needs to happen after the ComboBox has been added to the form
            //otherwise Unit.Items will always be "0" and not let you set the pre-set value when loading in a recipe
            rowToBeAdded.Unit.DataBindings.Add(new Binding("SelectedValue", units, "Measurement", true));
            rowToBeAdded.Unit.DataSource = units.ToList();
            rowToBeAdded.Unit.DisplayMember = "Measurement";
            rowToBeAdded.Unit.ValueMember = "Measurement";

            //This also means that we should only need one combo box template function in IngredientInformation,
            //Since the assignment needs to occur after the control has been added.

            recipeTableLayout.Controls.Add(rowToBeAdded.Selected, 4, numberOfRows);

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
                using (HarvestUtility harvest = new HarvestUtility(new RecipeQuery()))
                {
                    //Add the recipe
                    harvest.Insert(GetRecipeFromControls());

                    using (HarvestEntities harvestDatabase = new HarvestEntities())
                    {
                        Recipe recentlyCreatedRecipe = harvestDatabase.Recipe.OrderByDescending(id => id.RecipeID).First(); //Get the ID for later use

                        List<Inventory> ingredientsThatDontExist = new List<Inventory>();
                        foreach (IngredientInformation ingredientInfo in Ingredients)
                        {
                            Inventory listedIngredient = ingredientInfo.GetInventoryFromControls();

                            if (harvestDatabase.Inventory.Any(i => i.IngredientName.Equals(listedIngredient.IngredientName)) == false)
                                ingredientsThatDontExist.Add(listedIngredient);
                            else
                                listedIngredient.InventoryID = harvestDatabase.Inventory.SingleOrDefault(item => item.IngredientName.Equals(listedIngredient.IngredientName)).InventoryID;

                            recentlyCreatedRecipe.AssociatedItems.Add(listedIngredient);
                        }

                        //Handle non existant ingredients
                        harvest.HarvestQuery = new InventoryQuery();
                        if (ingredientsThatDontExist.Count > 0)
                        {
                            foreach (Inventory ingredientToCreate in ingredientsThatDontExist)
                                harvest.Insert(CreateEmptyIngredient(ingredientToCreate)); 
                            

                            //Ensure each ingredient has an ID now
                            foreach (Inventory ingredient in recentlyCreatedRecipe.AssociatedItems)
                                ingredient.InventoryID = harvestDatabase.Inventory.SingleOrDefault(item => item.IngredientName.Equals(ingredient.IngredientName)).InventoryID;
                            ingredientsThatDontExist = null;
                        }


                        harvest.HarvestQuery = new RecipeIngredientQuery();
                        foreach (Inventory ingredient in recentlyCreatedRecipe.AssociatedItems)
                            harvest.Insert(CreateRecipeIngredient(recentlyCreatedRecipe.RecipeID, ingredient));
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private Inventory CreateEmptyIngredient(Inventory ingredient)
        {
            Inventory emptyIngredient = ingredient;
            emptyIngredient.Amount = 0.0d;
            return emptyIngredient;
        }
        private RecipeIngredient CreateRecipeIngredient(int recipeID, Inventory ingredient)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();
            recipeIngredient.RecipeID = recipeID;
            recipeIngredient.InventoryID = ingredient.InventoryID;
            recipeIngredient.Amount = ingredient.Amount;
            recipeIngredient.Measurement = ingredient.Measurement;
            return recipeIngredient;
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
