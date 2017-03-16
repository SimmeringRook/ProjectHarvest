﻿using System.Collections.Generic;
using System.Windows.Forms;
using Client_Desktop.Helpers;
using Core;
using System.Linq;
using Core.MeasurementConversions;

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

            using (HarvestConverter conversion = new HarvestConverter(new VolumeUnitConversion()))
            {
                foreach (PlannedMealDay plan in plannedMealsForTheWeek)
                {
                    foreach (RecipeIngredient recipeIngredient in plan.GetIngredientsForPlannedRecipes())
                    {
                        if (_ingredients.Any(ingredient => ingredient.InventoryID == recipeIngredient.InventoryID))
                        {
                            RecipeIngredient ingredientToConvert = _ingredients.Single(ri => ri.InventoryID == recipeIngredient.InventoryID);

                            if (conversion.IsCorrectMeasurementType(ingredientToConvert.GetMeasurementUnit()) == false)
                                conversion.ConversionType = new WeightUnitConversion();
                            ingredientToConvert = conversion.Convert(recipeIngredient, ingredientToConvert.GetMeasurementUnit());

                            _ingredients.Single(i => i.InventoryID == recipeIngredient.InventoryID).Amount += ingredientToConvert.Amount;
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
            groceryTableLayout.Controls.Add(rowToBeAdded.Type, 1, numberOfRows);
            groceryTableLayout.Controls.Add(rowToBeAdded.Quantity, 2, numberOfRows);
            groceryTableLayout.Controls.Add(rowToBeAdded.Selected, 3, numberOfRows);

            numberOfRows++;
        }
    }
}
