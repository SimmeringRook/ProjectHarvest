using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client_Desktop.Helpers;
using Core;

namespace Client_Desktop
{
    public partial class GroceryList : Form
    {
        private List<PlannedMealDay> plannedMealsForTheWeek;
        private List<RecipeIngredient> _ingredients = new List<RecipeIngredient>();
        private int numberOfRows;

        

        public GroceryList(List<PlannedMealDay> plannedMealsForTheWeek)
        {
            this.plannedMealsForTheWeek = plannedMealsForTheWeek;
            InitializeComponent();
            getIngredients();
            
        }

        public void getIngredients()
        {
            numberOfRows = groceryTableLayout.RowCount - 1;
            foreach (var plan in plannedMealsForTheWeek)
            {
                foreach (KeyValuePair<MealTime, List<Recipe>> keyValuePair in plan.MealsPlanned)
                    foreach (Recipe recipe in keyValuePair.Value)
                    {
                        foreach (RecipeIngredient recipeIngredient in recipe.AssociatedIngredients)
                        {
                            if (_ingredients.Any(ingredient => ingredient.InventoryID == recipeIngredient.InventoryID))
                            {
                                _ingredients.Single(i => i.InventoryID == recipeIngredient.InventoryID).Amount += recipeIngredient.Amount;
                            }
                            else
                            {
                                _ingredients.Add(recipeIngredient);
                            }                           
                        }
                    }            
            }

            foreach (RecipeIngredient ri in _ingredients)
                buildRow(ri);
        }

        public void buildRow(RecipeIngredient ri)
        {
            
            IngredientInformation rowToBeAdded = new IngredientInformation();
            groceryTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));


            groceryTableLayout.Controls.Add(rowToBeAdded.NameLabel, 0, numberOfRows);
            rowToBeAdded.NameLabel.Text = ri.InventoryID.ToString();
            groceryTableLayout.Controls.Add(rowToBeAdded.Quantity, 1, numberOfRows);
            rowToBeAdded.Quantity.ReadOnly = true;  // Remove in future MVP
            rowToBeAdded.Quantity.Text = ri.Amount.ToString();
            groceryTableLayout.Controls.Add(rowToBeAdded.Unit, 2, numberOfRows);
            rowToBeAdded.Unit.Text = ri.Measurement.ToString();            
            groceryTableLayout.Controls.Add(rowToBeAdded.Selected, 3, numberOfRows);
            
            numberOfRows++;
        }        
    }
}
