using Core.Utilities.Database.Queries.Tables;
using Core.Utilities.UnitConversions;
using System;
using System.Collections.Generic;
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
            buildMealDictionary();
        }

        private void buildMealDictionary()
        {
            MealsForDay = new Dictionary<MealTime, List<Recipe>>();

            List<MealTime> mealTimes = new List<MealTime>();
            List<Recipe> recipes = new List<Recipe>();
            List<PlannedMeals> plansForDay = new List<PlannedMeals>();

            using (HarvestTableUtility harvest = new HarvestTableUtility(new MealTimeQuery()))
            {
                (harvest.Get(-1) as List<MealTime>).ToList().ForEach(item => { mealTimes.Add((MealTime)item.Clone()); });

                harvest.HarvestQuery = new PlannedMealQuery();
                (harvest.Get(Day) as List<PlannedMeals>).ToList().ForEach(item => { plansForDay.Add((PlannedMeals)item.Clone()); });

                harvest.HarvestQuery = new RecipeQuery();
                (harvest.Get(-1) as List<Recipe>).ForEach(item => { recipes.Add((Recipe)item.Clone()); });
            }

            foreach (MealTime mealTime in mealTimes)
                MealsForDay.Add(mealTime.Clone() as MealTime, new List<Recipe>());
            foreach (PlannedMeals planned in plansForDay)
            {
                MealTime mealtime = mealTimes.Where(m => m.MealName.Equals(planned.MealName)).First();
                Recipe r = recipes.Where(rcp => rcp.RecipeID == planned.RecipeID).First();
                r.HasBeenEaten = planned.MealEaten;
                if (MealsForDay[mealtime].Any(existingRecipe => r.RecipeID == existingRecipe.RecipeID) == false)
                    MealsForDay[mealtime].Add(r.Clone() as Recipe);
            }

            //Dispose of lists
            mealTimes = null;
            recipes = null;
            plansForDay = null;
        }

        public List<RecipeIngredient> GetIngredientsForToday()
        {
            List<RecipeIngredient> allIngredients = new List<RecipeIngredient>();

            foreach (KeyValuePair<MealTime, List<Recipe>> keyValuePair in MealsForDay)
                foreach (Recipe recipe in keyValuePair.Value)
                    foreach (RecipeIngredient ingredient in recipe.GetIngredients())
                        if (allIngredients.Any(ing => ing.InventoryID == ingredient.InventoryID))
                        {
                            RecipeIngredient ri = allIngredients.Single(i => i.InventoryID == ingredient.InventoryID);
                            allIngredients[allIngredients.IndexOf(ri)].Amount += ConvertedAmount(ingredient, ri);
                        }
                        else
                            allIngredients.Add(ingredient.Clone() as RecipeIngredient);
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
                    plannedMeals.Add(PlannedMeals.CreateRecord(this.Day, recipe.RecipeID, meals.Key.MealName));

            return plannedMeals;
        }
    }
}
