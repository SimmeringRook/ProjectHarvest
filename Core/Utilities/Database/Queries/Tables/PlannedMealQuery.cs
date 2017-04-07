using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    public class PlannedMealQuery : IHarvestQuery
    {
        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();
            if (itemID is int)
                return HarvestDatabase.PlannedMeals.ToList();
            DateTime day = (DateTime) itemID;
            return HarvestDatabase.PlannedMeals.Where(plannedMeal => DbFunctions.TruncateTime(plannedMeal.DatePlanned) == DbFunctions.TruncateTime(day)).ToList();
        }

        public void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();
            HarvestDatabase.PlannedMeals.Add(itemToAdd as PlannedMeals);
            HarvestDatabase.SaveChanges();
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
    }
}
