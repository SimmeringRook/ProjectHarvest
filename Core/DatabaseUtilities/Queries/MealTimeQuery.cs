using System;
using System.Data.Entity;
using System.Linq;

namespace Core.DatabaseUtilities.Queries
{
    public class MealTimeQuery : IHarvestQuery
    {
        public object Get(object itemID)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.MealTime.Load();
                if (itemID is int)
                    return harvestDatabase.MealTime.ToList();
                return harvestDatabase.MealTime.Where(meal => meal.MealName.Equals(itemID as string));
            }
        }

        public void Insert(object itemToAdd)
        {
            throw new NotImplementedException();
        }

        public void Remove(object itemToRemove)
        {
            throw new NotImplementedException();
        }

        public void Update(object itemToChange)
        {
            throw new NotImplementedException();
        }
    }
}
