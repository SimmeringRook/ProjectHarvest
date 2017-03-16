using Core;
using Core.DatabaseUtilities;
using Core.DatabaseUtilities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Desktop.Helpers
{
    public class PlannedMealDay
    {
        public DateTime Day;
        public Dictionary<MealTime, List<Recipe>> MealsPlanned;

        private MealTime breakfast = new MealTime("Breakfast");
        private MealTime lunch = new MealTime("Lunch");
        private MealTime dinner = new MealTime("Dinner");

        public PlannedMealDay(DateTime dayBeingPlanned)
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
    }

    public enum Meal_Time
    {
        Breakfast= 0,
        Lunch = 1,
        Dinner = 2
    }
}
