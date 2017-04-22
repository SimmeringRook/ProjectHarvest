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

            if (firstTimeLaunched != null)
                return _GetPlannedMealsWithinDateRange(firstTimeLaunched.Date, HarvestDatabase);
            else
                return new Cache<PlannedMeal>();
        }

        private Cache<PlannedMeal> _GetPlannedMealsWithinDateRange(DateTime startDate, HarvestDatabaseEntities HarvestDatabase)
        {
            DateTime endDate = startDate.AddDays(6);
            Cache<PlannedMeal> plannedMeals = new Cache<PlannedMeal>();
            var results = HarvestDatabase.PlannedMeals.Where(meal => meal.DatePlanned >= startDate && meal.DatePlanned <= endDate).ToList();

            plannedMeals.RaiseListChangedEvents = false;

            foreach (var plan in results)
                plannedMeals.Add(PlannedMealFactory.Create_Client_From_Database(plan));

            plannedMeals.RaiseListChangedEvents = true;

            return plannedMeals;
        }

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();
            PlannedMeals item = itemToRemove as PlannedMeals;
            var planToDelete = HarvestDatabase.PlannedMeals.Single(
                p => 
                p.RecipeID == item.RecipeID &&
                DbFunctions.TruncateTime(p.DatePlanned) == DbFunctions.TruncateTime(item.DatePlanned) &&
                p.MealName == item.MealName
                );
            HarvestDatabase.PlannedMeals.Remove(planToDelete);
            HarvestDatabase.SaveChanges();
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();
            HarvestDatabase.PlannedMeals.AddOrUpdate(itemToChange as PlannedMeals);
            HarvestDatabase.SaveChanges();
        }
        public void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();
            HarvestDatabase.PlannedMeals.Add(itemToAdd as PlannedMeals);
            HarvestDatabase.SaveChanges();
        }

        private void AddOrUpdate()
        {

        }
    }
}
