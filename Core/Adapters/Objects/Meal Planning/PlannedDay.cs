using Core.Utilities.UnitConversions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Adapters.Objects
{
    public class PlannedDay
    {
        public DateTime Day { get; private set; }
        public Dictionary<string, List<Recipe>> MealsForDay;

        public PlannedDay(DateTime day)
        {
            Day = day;

            MealsForDay = new Dictionary<string, List<Recipe>>();

            foreach (string mealTime in HarvestAdapter.MealTimes)
                MealsForDay.Add(mealTime, new List<Recipe>());

            foreach (PlannedMeal meal in HarvestAdapter.PlannedMeals.Where(p => p.Date.Equals(Day)).ToList())
                MealsForDay[meal.MealTime].Add(meal.PlannedRecipe);
        }

        public List<RecipeIngredient> GetIngredientsForToday()
        {
            List<RecipeIngredient> allIngredients = new List<RecipeIngredient>();

            //For each Meal Time in Day ("Breakfast", "Lunch", "Dinner")
            foreach (KeyValuePair<string, List<Recipe>> recipesByMealTime in MealsForDay)
            {
                //For each recipe in that meal time,
                foreach (Recipe recipe in recipesByMealTime.Value)
                {
                    //Compare the recipe ingredients in 'this' recipe to the 'master list' (allIngredients)
                    foreach (RecipeIngredient recipeIngredient in recipe.AssociatedIngredients)
                    {
                        RecipeIngredient ingredientToAdd = allIngredients.SingleOrDefault(_ingredient => _ingredient.Equals(recipeIngredient));
                        //If the recipe is already in allIngredients
                        if (ingredientToAdd != null && allIngredients.Contains(ingredientToAdd))
                        {
                            //convert the amount required to the same unit as what allIngredients has
                            int indexOfIngredient = allIngredients.IndexOf(ingredientToAdd);
                            allIngredients[indexOfIngredient].Amount += ConvertedAmount(recipeIngredient, ingredientToAdd.Measurement);
                        }
                        else
                        {
                            //Otherwise, it doesn't exist in the list yet,
                            //Therefore, add it.
                            allIngredients.Add(ingredientToAdd);
                        }
                    }
                }
            }
       
            return allIngredients;
        }

        private double ConvertedAmount(RecipeIngredient ingredientToConvert, MeasurementUnit unitToConvertTo)
        {
            using (HarvestConverter conversion = new HarvestConverter(new VolumeUnitConversion()))
            {
                if (conversion.IsCorrectMeasurementType(ingredientToConvert.Measurement) == false)
                    conversion.ConversionType = new WeightUnitConversion();
                return conversion.Convert(new ConvertedIngredient(ingredientToConvert), unitToConvertTo).Amount;
            }
        }
    }
}
