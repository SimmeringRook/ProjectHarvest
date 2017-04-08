using Core.Adapters.Factories;
using Core.Utilities.Database.Queries.Tables;
using Core.Utilities.UnitConversions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Adapters
{
    public static class HarvestAdapter
    {
        #region Recipe
        private static List<Objects.Recipe> _recipes = new List<Objects.Recipe>();
        public static List<Objects.Recipe> Recipes
        {
            get { return _GetValidRecipeCache(); }
        }

        private static List<Objects.Recipe> _GetValidRecipeCache()
        {
            using (HarvestTableUtility recipeTable = new HarvestTableUtility(new RecipeQuery()))
            {
                List<Database.Recipe> databaseRecipes = recipeTable.Get(-1) as List<Database.Recipe>;
                foreach (Objects.Recipe recipe in _recipes)
                {
                    if (recipe.IsDirty)
                    {
                        recipeTable.Update(RecipeFactory.Create_Database_From_Client(recipe));

                        if (recipe.ID == 0)
                        {//This was a new recipe, add ingredients to the RI table
                            databaseRecipes = recipeTable.Get(-1) as List<Database.Recipe>;
                            recipe.ID = databaseRecipes.Single(r => r.RecipeName.Equals(recipe.Name)).RecipeID;

                            foreach (var recipeIngredient in recipe.AssociatedIngredients)
                                Add_Ingredient_To_Recipe(recipe, recipeIngredient);
                        }
                            
                    }
                }

                databaseRecipes = recipeTable.Get(-1) as List<Database.Recipe>;
                if (_recipes.Count != databaseRecipes.Count)
                {
                    _recipes.Clear();
                    foreach (Database.Recipe dbRecipe in databaseRecipes)
                        _recipes.Add(RecipeFactory.Create_Client_From_Database(dbRecipe));
                }
            }
            return _recipes;
        }

        public static void Remove_Recipe(Objects.Recipe recipeToRemove)
        {
            using (HarvestTableUtility harvest = new HarvestTableUtility(new RecipeIngredientQuery()))
            {
                //Remove Ingredients first
                recipeToRemove.AssociatedIngredients.ForEach(ingredient => { harvest.Remove(ingredient); });

                //Remove all planned meals using this recipe
                harvest.HarvestQuery = new PlannedMealQuery();
                var plansWithThisRecipe = (harvest.Get(-1) as List<Database.PlannedMeals>).Where(p => p.RecipeID == recipeToRemove.ID).ToList();
                plansWithThisRecipe.ForEach(plan => { harvest.Remove(plan); });

                //Delete the recipe
                harvest.HarvestQuery = new RecipeQuery();
                harvest.Remove(RecipeFactory.Create_Database_From_Client(recipeToRemove));
            }
        }
        #endregion

        #region Inventory
        private static List<Objects.Inventory> _inventories = new List<Objects.Inventory>();
        public static List<Objects.Inventory> InventoryItems
        {
            get { return _GetValidInventoryCache(); }
        }

        private static List<Objects.Inventory> _GetValidInventoryCache()
        {
            using (HarvestTableUtility inventoryTable = new HarvestTableUtility(new InventoryQuery()))
            {
                List<Database.Inventory> databaseInventoryItems = inventoryTable.Get(-1) as List<Database.Inventory>;
                foreach (Objects.Inventory item in _inventories)
                {
                    if (item.IsDirty)
                    {
                        inventoryTable.Update(InventoryFactory.Create_Database_From_Client(item));
                    }
                        
                }

                databaseInventoryItems = inventoryTable.Get(-1) as List<Database.Inventory>;
                if (_inventories.Count < databaseInventoryItems.Count)
                {
                    _inventories.Clear();
                    foreach (Database.Inventory dbItem in databaseInventoryItems)
                        _inventories.Add(InventoryFactory.Create_Client_From_Database(dbItem));
                }
            }
            return _inventories;
        }
        #endregion

        #region Recipe Ingredient

        internal static void Add_Ingredient_To_Recipe(Objects.Recipe recipe, Objects.RecipeIngredient riToAdd)
        {
            if (InventoryItems.Any(item => item.Name.Equals(riToAdd.Inventory.Name)) == false)
            {
                InventoryItems.Add(riToAdd.Inventory);
            }

            using(HarvestTableUtility recipeIngredientTable = new HarvestTableUtility(new RecipeCategoryQuery()))
            {
                riToAdd.Inventory = InventoryItems.Single(item => item.Name.Equals(riToAdd.Inventory.Name));
                recipeIngredientTable.Update(RecipeIngredientFactory.Create_Database_From_Client(riToAdd));
            }
        }

        public static void Remove_Ingredient_From_Recipe(Objects.Recipe recipe, string ingredientName)
        {
            Objects.RecipeIngredient itemToRemove = null;
            foreach (var ri in recipe.AssociatedIngredients)
            {
                if (ri.Inventory.Name.Equals(ingredientName))
                    itemToRemove = ri;
            }

            if (itemToRemove == null)
                return;

            recipe.AssociatedIngredients.Remove(itemToRemove);

            using (HarvestTableUtility recipeIngredientTable = new HarvestTableUtility(new RecipeIngredientQuery()))
            {
                 recipeIngredientTable.Remove(itemToRemove);
            }

            recipe.SetDirtyFlag();
        }

        #endregion

        #region Recipe Category
        private static List<string> _recipeCategories = new List<string>();
        public static List<string> RecipeCategories
        {
            get { return _GetValidRecipeCategoryCache(); }
        }

        private static List<string> _GetValidRecipeCategoryCache()
        {
            using (HarvestTableUtility categoryTable = new HarvestTableUtility(new RecipeCategoryQuery()))
            {
                var databaseCategories = categoryTable.Get(-1) as List<Database.RecipeClass>;
                if (_recipeCategories.Count != databaseCategories.Count)
                {
                    _recipeCategories.Clear();
                    foreach (var category in databaseCategories)
                        _recipeCategories.Add(category.RCategory);
                } 
            }
            return _recipeCategories;
        }
        #endregion

        #region Ingredient Category
        private static List<string> _ingredientCategories = new List<string>();
        public static List<string> IngredientCategories
        {
            get { return _GetValidIngredientCategoryCache(); }
        }

        private static List<string> _GetValidIngredientCategoryCache()
        {
            using (HarvestTableUtility categoryTable = new HarvestTableUtility(new IngredientCategoryQuery()))
            {
                var databaseCategories = categoryTable.Get(-1) as List<Database.IngredientCategory>;
                if (_ingredientCategories.Count != databaseCategories.Count)
                {
                    _ingredientCategories.Clear();
                    foreach (var category in databaseCategories)
                        _ingredientCategories.Add(category.Category);
                }
            }
            return _ingredientCategories;
        }
        #endregion

        #region Meal Time
        private static List<string> _mealTimes = new List<string>();
        public static List<string> MealTimes
        {
            get { return _GetValidMealTimeCache(); }
        }

        private static List<string> _GetValidMealTimeCache()
        {
            using (HarvestTableUtility mealTimeTable = new HarvestTableUtility(new MealTimeQuery()))
            {
                var databaseMealTimes = mealTimeTable.Get(-1) as List<Database.MealTime>;
                if (_mealTimes.Count != databaseMealTimes.Count)
                {
                    _mealTimes.Clear();
                    foreach (var mealTime in databaseMealTimes)
                        _mealTimes.Add(mealTime.MealName);
                }
            }
            return _mealTimes;
        }
        #endregion

        #region Planned Meals/Week

        private static List<Objects.PlannedMeal> _plannedMeals = new List<Objects.PlannedMeal>();
        internal static List<Objects.PlannedMeal> PlannedMeals
        {
            get { return _GetValidPlannedMealCache(); }
        }
        private static List<Objects.PlannedMeal> _GetValidPlannedMealCache()
        {
            using (HarvestTableUtility plannedTable = new HarvestTableUtility(new PlannedMealQuery()))
            {
                var databasePlannedMeals = (plannedTable.Get(-1) as List<Database.PlannedMeals>).Where(meal => 
                meal.DatePlanned >= CurrentWeek.StartOfWeek &&
                meal.DatePlanned <= CurrentWeek.EndOfWeek).ToList();

                if (_plannedMeals.Count < databasePlannedMeals.Count)
                {
                    _plannedMeals.Clear();
                    foreach (var meal in databasePlannedMeals)
                        _plannedMeals.Add(PlannedMealFactory.Create_Client_From_Database(meal));
                }
                else if (_plannedMeals.Count > databasePlannedMeals.Count)
                {
                    foreach (var plannedMeal in _plannedMeals)
                    {
                        Database.PlannedMeals databasePlan = PlannedMealFactory.Create_Database_From_Client(plannedMeal);
                        if (databasePlannedMeals.Any(meal => meal.Equals(databasePlan)) == false)
                            plannedTable.Update(databasePlan);
                    }
                }
            }

            return _plannedMeals;
        }

        private static Objects.PlannedWeek _currentWeek = null;
        public static Objects.PlannedWeek CurrentWeek { get { return _GetCurrentWeekCache(); } }
        private static Objects.PlannedWeek _GetCurrentWeekCache()
        {
            if (_currentWeek == null)
                _BuildNewCurrentWeek();

            return _currentWeek;
        }

        private static void _BuildNewCurrentWeek()
        {
            DateTime startOfWeek = DateTime.Today;
            using (HarvestTableUtility launchTable = new HarvestTableUtility(new LastLaunchedQuery()))
            {
                var lastHarvestLaunch = launchTable.Get(null) as List<Database.LastLaunched>;
                if (lastHarvestLaunch.Count == 0)
                {
                    launchTable.Insert(startOfWeek);
                }
                else
                {
                    startOfWeek = lastHarvestLaunch.First().Date;
                }
            }
            _currentWeek = new Objects.PlannedWeek(startOfWeek, startOfWeek.AddDays(6));
        }
        #endregion

        #region Measurements
        private static List<MeasurementUnit> _measurementUnits = new List<MeasurementUnit>();
        public static List<MeasurementUnit> Measurements
        {
            get { return _GetValidMeasurementCache(); }
        }

        private static List<MeasurementUnit> _GetValidMeasurementCache()
        {
            using (HarvestTableUtility metricTable = new HarvestTableUtility(new MetricQuery()))
            {
                var databaseMeasurements = metricTable.Get(-1) as List<Database.Metric>;
                if (_measurementUnits.Count != databaseMeasurements.Count)
                {
                    _measurementUnits.Clear();
                    foreach (var metric in databaseMeasurements)
                        _measurementUnits.Add((MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), metric.Measurement));
                }
            }
            return _measurementUnits;
        }
        #endregion

    }
}
