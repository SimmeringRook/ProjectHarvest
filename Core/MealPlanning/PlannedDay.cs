using Core.DatabaseUtilities.Queries;
using Core.MeasurementConversions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.MealPlanning
{
    public class PlannedDay
    {
        public DateTime Day { get; private set; }
        public Dictionary<MealTime, List<Recipe>> MealsForDay;

        public PlannedDay(DateTime day)
        {
            Day = day;
            MealsForDay = new Dictionary<MealTime, List<Recipe>>();
            List<PlannedMeals> onlyRelevantPlans = new List<PlannedMeals>();
            using (HarvestUtility harvest = new HarvestUtility(new MealTimeQuery()))
            {
                foreach (MealTime mealTime in harvest.Get(-1) as List<MealTime>)
                    MealsForDay.Add(mealTime, new List<Recipe>());

                harvest.HarvestQuery = new PlannedMealQuery();
                //If a record exists, populate information
                var allPlans = harvest.Get(-1) as List<PlannedMeals>;
                onlyRelevantPlans = allPlans.Where(plannedMeal => plannedMeal.DatePlanned.Date == day.Date).ToList();
                foreach (PlannedMeals meal in onlyRelevantPlans)
                    MealsForDay[meal.MealTime].Add(meal.Recipe);
            }

        }

        public List<RecipeIngredient> GetIngredientsForToday()
        {
            List<RecipeIngredient> allIngredients = new List<RecipeIngredient>();

            foreach (KeyValuePair<MealTime, List<Recipe>> keyValuePair in MealsForDay)
                foreach (Recipe recipe in keyValuePair.Value)
                    foreach (RecipeIngredient ingredient in recipe.AssociatedIngredients)
                        if (allIngredients.Any(ing => ing.InventoryID == ingredient.InventoryID))
                        {
                            RecipeIngredient ri = allIngredients.Single(i => i.InventoryID == ingredient.InventoryID);
                            allIngredients[allIngredients.IndexOf(ri)].Amount += ConvertedAmount(ingredient, ri);
                        }
                        else
                            allIngredients.Add(ingredient);
            return allIngredients;
        }

        private double ConvertedAmount(RecipeIngredient ingredientToConvert, RecipeIngredient unitToConvertTo)
        {
            using (HarvestConverter conversion = new HarvestConverter(new VolumeUnitConversion()))
            {
                if (conversion.IsCorrectMeasurementType(ingredientToConvert.GetMeasurementUnit()) == false)
                    conversion.ConversionType = new WeightUnitConversion();
                return conversion.Convert(ingredientToConvert, unitToConvertTo.GetMeasurementUnit()).Amount;
            }
        }

        public List<PlannedMeals> ConvertPlannedDayIntoDatabaseObject()
        {
            List<PlannedMeals> plannedMeals = new List<PlannedMeals>();

            foreach (KeyValuePair<MealTime, List<Recipe>> meals in MealsForDay)
                foreach (Recipe recipe in meals.Value)
                    plannedMeals.Add(PlannedMeals.CreateRecord(this.Day, recipe.RecipeID, meals.Key));

            return plannedMeals;
        }
    }
}
