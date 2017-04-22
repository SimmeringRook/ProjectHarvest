using Core.Adapters.Database;
using Core.Adapters.Factories;
using Core.Adapters.Objects;
using Core.Cache;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Utilities.Queries
{
    internal class PlannedMealQuery : IHarvestQuery
    {
        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();

            LastLaunchedQuery launchQuery = new LastLaunchedQuery();
            LastLaunched firstTimeLaunched = launchQuery.Get(-1, HarvestDatabase) as LastLaunched;

            Cache<PlannedMeal> plannedMeals = null;

            if (firstTimeLaunched != null)
                plannedMeals = getPlannedMealsWithinDateRange(firstTimeLaunched.Date, HarvestDatabase);
            else
                plannedMeals = new Cache<PlannedMeal>();

            plannedMeals.RaiseListChangedEvents = true;
            return plannedMeals;
        }

        private Cache<PlannedMeal> getPlannedMealsWithinDateRange(DateTime startDate, HarvestDatabaseEntities HarvestDatabase)
        {
            DateTime endDate = startDate.AddDays(6);
            Cache<PlannedMeal> plannedMeals = new Cache<PlannedMeal>();
            var results = HarvestDatabase.PlannedMeals.Where(meal => meal.DatePlanned >= startDate && meal.DatePlanned <= endDate).ToList();

            plannedMeals.RaiseListChangedEvents = false;

            foreach (var plan in results)
                plannedMeals.Add(PlannedMealFactory.Create_Client_From_Database(plan));

            return plannedMeals;
        }

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();
            PlannedMeal item = itemToRemove as PlannedMeal;

            var planToDelete = HarvestDatabase.PlannedMeals.Single(
                p => 
                p.RecipeID == item.PlannedRecipe.ID &&
                DbFunctions.TruncateTime(p.DatePlanned) == DbFunctions.TruncateTime(item.Date) &&
                p.MealName.Equals(item.MealTime)
                );

            HarvestDatabase.PlannedMeals.Remove(planToDelete);
            HarvestDatabase.SaveChanges();
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            AddOrUpdate(itemToChange as PlannedMeal, HarvestDatabase);
        }
        public void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase)
        {
            AddOrUpdate(itemToAdd as PlannedMeal, HarvestDatabase);
        }

        private void AddOrUpdate(PlannedMeal plannedMeal, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();
            HarvestDatabase.PlannedMeals.AddOrUpdate(PlannedMealFactory.Create_Database_From_Client(plannedMeal as PlannedMeal));
            HarvestDatabase.SaveChanges();
        }
    }
}
