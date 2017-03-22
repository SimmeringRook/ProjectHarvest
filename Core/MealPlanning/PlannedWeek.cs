using Core.Utilities.UnitConversions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.MealPlanning
{
    public class PlannedWeek
    {
        public List<PlannedDay> DaysOfWeek = new List<PlannedDay>();
        public DateTime StartOfWeek { get; private set; }
        public DateTime EndOfWeek { get; private set; }

        public PlannedWeek(DateTime start, DateTime end)
        {
            StartOfWeek = start;
            EndOfWeek = end;

            for (DateTime d = start; d.DayOfYear <= end.DayOfYear; d = d.AddDays(1))
                DaysOfWeek.Add(new PlannedDay(d));
        }

        public List<RecipeIngredient> GetAllIngredientsForWeek()
        {
            List<RecipeIngredient> allIngredients = new List<RecipeIngredient>();

            foreach (PlannedDay day in DaysOfWeek)
            {
                foreach (RecipeIngredient ingredientsFrequencyForDay in day.GetIngredientsForToday())
                    if (allIngredients.Any(ingredient => ingredient.InventoryID == ingredientsFrequencyForDay.InventoryID))
                    {
                        RecipeIngredient ri = allIngredients.Single(i => i.InventoryID == ingredientsFrequencyForDay.InventoryID);
                        allIngredients[allIngredients.IndexOf(ri)].Amount += ConvertedAmount(ingredientsFrequencyForDay, ri);
                    }
                    else
                        allIngredients.Add(ingredientsFrequencyForDay);
            }

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

        public List<PlannedMeals> GetPlannedMeals()
        {
            List<PlannedMeals> plannedMeals = new List<PlannedMeals>();
            foreach (PlannedDay day in DaysOfWeek)
            {
                foreach (var mealPlan in day.MealsForDay)
                {
                    var plannedMeal = new PlannedMeals();
                    plannedMeal.DatePlanned = day.Day;
                    plannedMeal.MealName = mealPlan.Key.MealName;
                    foreach (var meal in mealPlan.Value)
                    {
                        plannedMeal.RecipeID = meal.RecipeID;
                        plannedMeals.Add(plannedMeal);
                    }
                }
            }
            return plannedMeals;
        }
    }
}
