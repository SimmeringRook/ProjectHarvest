using System;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    public class MealTimeQuery : IHarvestQuery
    {
        public object Get(object itemID, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.MealTime.Load();
            if (itemID is int)
                return HarvestDatabase.MealTime.ToList();
            var mealTime = HarvestDatabase.MealTime.Where(meal => meal.MealName.Equals(itemID as string));
            return mealTime;
        }

        public void Insert(object itemToAdd, HarvestEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }

        public void Remove(object itemToRemove, HarvestEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }

        public void Update(object itemToChange, HarvestEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }
    }
}
