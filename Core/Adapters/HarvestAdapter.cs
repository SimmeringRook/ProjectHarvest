using Core.Cache;
using Core.Utilities.Queries;
using Core.Utilities.UnitConversions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Adapters
{
    public static class HarvestAdapter
    {
        #region Recipe
        private static RecipeCache<Objects.Recipe> _recipes = new HarvestEntitiesUtility(new RecipeQuery()).Get(-1) as RecipeCache<Objects.Recipe>;
        public static RecipeCache<Objects.Recipe> Recipes { get { return _recipes; } }
        #endregion

        #region Inventory
        private static InventoryCache<Objects.Inventory> _inventories = new HarvestEntitiesUtility(new InventoryQuery()).Get(-1) as InventoryCache<Objects.Inventory>;
        public static InventoryCache<Objects.Inventory> InventoryItems { get { return _inventories; } }
        #endregion

        #region Planned Meals
        private static Cache<Objects.PlannedMeal> _plannedMeals = new HarvestEntitiesUtility(new PlannedMealQuery()).Get(-1) as Cache<Objects.PlannedMeal>;

        public static Cache<Objects.PlannedMeal> PlannedMeals { get { return _plannedMeals; } }
        #endregion

        #region Current Week
        private static Objects.PlannedWeek _currentWeek = new Objects.PlannedWeek();
        public static Objects.PlannedWeek CurrentWeek { get { return _currentWeek; } }
        #endregion

        #region Recipe Category
        private static List<string> _recipeCategories = new HarvestEntitiesUtility(new RecipeCategoryQuery()).Get(-1) as List<string>;
        public static List<string> RecipeCategories { get { return _recipeCategories; } }
        #endregion

        #region Ingredient Category
        private static List<string> _ingredientCategories = new HarvestEntitiesUtility(new IngredientCategoryQuery()).Get(-1) as List<string>;
        public static List<string> IngredientCategories { get { return _ingredientCategories; } }
        #endregion

        #region Meal Time
        private static List<string> _mealTimes = new HarvestEntitiesUtility(new MealTimeQuery()).Get(-1) as List<string>;
        public static List<string> MealTimes { get { return _mealTimes; } }
        #endregion

        #region Measurements
        private static List<MeasurementUnit> _measurementUnits = new HarvestEntitiesUtility(new MetricQuery()).Get(-1) as List<MeasurementUnit>;
        public static List<MeasurementUnit> Measurements { get { return _measurementUnits; } }
        #endregion
    }
}