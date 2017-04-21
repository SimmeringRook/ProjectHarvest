using Core.Adapters.Database;
using Core.Adapters.Factories;
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
            if (itemID is int)
                return HarvestDatabase.PlannedMeals.ToList();
            else if (itemID is Adapters.Objects.PlannedWeek)
            {
                Adapters.Objects.PlannedWeek CurrentWeek = itemID as Adapters.Objects.PlannedWeek;

                Cache<Adapters.Objects.PlannedMeal> plannedMeals = new Cache<Adapters.Objects.PlannedMeal>();
                foreach (var plan in HarvestDatabase.PlannedMeals.Where(meal => meal.DatePlanned >= CurrentWeek.StartOfWeek 
                && meal.DatePlanned <= CurrentWeek.EndOfWeek).ToList())
                {
                    plannedMeals.Add(PlannedMealFactory.Create_Client_From_Database(plan));
                }

                return plannedMeals;
            }
                
            DateTime day = (DateTime) itemID;
            return HarvestDatabase.PlannedMeals.Where(plannedMeal => DbFunctions.TruncateTime(plannedMeal.DatePlanned) == DbFunctions.TruncateTime(day)).ToList();
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
