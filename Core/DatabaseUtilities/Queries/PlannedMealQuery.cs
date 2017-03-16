using System;
using System.Data.Entity;
using System.Linq;

namespace Core.DatabaseUtilities
{
    public class PlannedMealQuery : IHarvestQuery
    {
        public object Get(object itemID)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.PlannedMeals.Load();
                return harvestDatabase.PlannedMeals.SingleOrDefault(plannedMeal => plannedMeal.DatePlanned.Equals((DateTime)itemID));
            }
        }

        public void Insert(object itemToAdd)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.PlannedMeals.Load();
                harvestDatabase.PlannedMeals.Add(itemToAdd as PlannedMeals);
                harvestDatabase.SaveChanges();
            }
        }

        public void Remove(object itemToRemove)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.PlannedMeals.Load();
                harvestDatabase.PlannedMeals.Remove(itemToRemove as PlannedMeals);
                harvestDatabase.SaveChanges();
            }
        }

        public void Update(object itemToChange)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.PlannedMeals.Load();
                PlannedMeals itemInDatabase = Get((itemToChange as PlannedMeals).DatePlanned) as PlannedMeals;
                itemInDatabase = itemToChange as PlannedMeals;
                harvestDatabase.SaveChanges();
            }
        }
    }
}
