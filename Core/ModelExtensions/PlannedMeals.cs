using Core.DatabaseUtilities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public partial class PlannedMeals
    {
        public DateTime Day;
        public Dictionary<MealTime, List<Recipe>> MealsPlanned;

        private MealTime breakfast = new MealTime("Breakfast");
        private MealTime lunch = new MealTime("Lunch");
        private MealTime dinner = new MealTime("Dinner");

        public PlannedMeals()
        {

        }

        public PlannedMeals(DateTime dayBeingPlanned)
        {
            Day = dayBeingPlanned;
            MealsPlanned = new Dictionary<MealTime, List<Recipe>>()
            {
                {breakfast, new List<Recipe>() },
                {lunch, new List<Recipe>() },
                {dinner, new List<Recipe>() }
            };

        }

        private void AddRecipeToMealTime(Meal_Time mealTime, Recipe recipe)
        {
            switch (mealTime)
            {
                case Meal_Time.Breakfast:
                    MealsPlanned[breakfast].Add(recipe);
                    break;
                case Meal_Time.Lunch:
                    MealsPlanned[lunch].Add(recipe);
                    break;
                case Meal_Time.Dinner:
                    MealsPlanned[dinner].Add(recipe);
                    break;
            }
        }

        public void ConvertRecipeNamesIntoRecipes(int mealTime, List<string> recipeNames)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (HarvestUtility harvest = new HarvestUtility(new RecipeQuery()))
                recipes = harvest.Get(-1) as List<Recipe>;

            foreach (string recipeName in recipeNames)
            {
                Recipe recipe = recipes.Single(r => r.RecipeName.Equals(recipeName));
                recipe.PopulateGUIProperties();
                AddRecipeToMealTime((Meal_Time)mealTime, recipe);
            }
        }

        public List<RecipeIngredient> GetIngredientsForPlannedRecipes()
        {
            List<RecipeIngredient> allIngredients = new List<RecipeIngredient>();
            foreach (KeyValuePair<MealTime, List<Recipe>> keyValuePair in MealsPlanned)
                foreach (Recipe recipe in keyValuePair.Value)
                    foreach (RecipeIngredient ingredient in recipe.AssociatedIngredients)
                        if (allIngredients.Contains(ingredient) == false)
                            allIngredients.Add(ingredient);

            return allIngredients;
        }
        
        public List<Recipe> GetRecipesPlannedForDay(int meal_time)
        {
            List<Recipe> recipesForDay = new List<Recipe>();
            List<Meal_Time> mealtimes = new List<Meal_Time>() { Meal_Time.Breakfast, Meal_Time.Lunch, Meal_Time.Dinner };
            using (HarvestUtility harvest = new HarvestUtility(new PlannedMealQuery()))
            {
                List<PlannedMeals> plannedMealsForDay = harvest.Get(this.DatePlanned) as List<PlannedMeals>;

                harvest.HarvestQuery = new RecipeQuery();
                foreach (PlannedMeals meal in plannedMealsForDay)
                {
                    if (meal.MealName.Equals(mealtimes[meal_time]))
                        recipesForDay.Add(harvest.Get(meal.RecipeID) as Recipe);
                }
            }

            return recipesForDay;
        }

        public void BuildForDatabase()
        {
            /* So where I left off:
             * 
             * This class needs to reflect the database object
             */ 
            this.DatePlanned = Day;
            //this.MealTime
        }
    }

    public enum Meal_Time
    {
        Breakfast = 0,
        Lunch = 1,
        Dinner = 2
    }
}
