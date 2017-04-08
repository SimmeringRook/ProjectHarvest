using Core.Utilities.UnitConversions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Adapters.Objects
{
    public class PlannedDay
    {
        public DateTime Day { get; private set; }
        public List<PlannedMeal> MealsForDay { get { return HarvestAdapter.PlannedMeals.Where(p => p.Date.Equals(Day)).ToList(); } }

        public PlannedDay(DateTime day)
        {
            Day = day;
        }

        public void PlanRecipe(Recipe recipe, string mealTime)
        {
            HarvestAdapter.PlannedMeals.Add(new PlannedMeal(recipe, mealTime, Day, false));

        }

        public void UnplanRecipe(Recipe recipe, string mealTime)
        {
            HarvestAdapter.PlannedMeals.Remove(new PlannedMeal(recipe, mealTime, Day, false));
        }

        public List<RecipeIngredient> GetIngredientsForToday()
        {
            List<RecipeIngredient> allIngredients = new List<RecipeIngredient>();

            foreach (var meal in MealsForDay)
            {
                //Compare the recipe ingredients in 'this' recipe to the 'master list' (allIngredients)
                foreach (RecipeIngredient recipeIngredient in meal.PlannedRecipe.AssociatedIngredients)
                {
                    RecipeIngredient ingredientToAdd = allIngredients.SingleOrDefault(_ingredient => _ingredient.Equals(recipeIngredient));
                    //If the recipe is already in allIngredients
                    if (allIngredients.Contains(ingredientToAdd))
                    {
                        //convert the amount required to the same unit as what allIngredients has
                        int indexOfIngredient = allIngredients.IndexOf(ingredientToAdd);
                        allIngredients[indexOfIngredient].Amount += ConvertedAmount(recipeIngredient, ingredientToAdd.Measurement);
                    }
                    else
                    {
                        //Otherwise, it doesn't exist in the list yet, add it.
                        allIngredients.Add(ingredientToAdd);
                    }
                }
                
            }
       
            return allIngredients;
        }

        private double ConvertedAmount(RecipeIngredient ingredientToConvert, MeasurementUnit unitToConvertTo)
        {
            try
            {
                using (HarvestConverter conversion = new HarvestConverter(new VolumeUnitConversion()))
                {
                    if (conversion.IsCorrectMeasurementType(ingredientToConvert.Measurement) == false)
                        conversion.ConversionType = new WeightUnitConversion();
                    return conversion.Convert(new ConvertedIngredient(ingredientToConvert), unitToConvertTo).Amount;
                }
            }
            catch(InvalidConversionException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return 0.0;
            }
        }
    }
}
