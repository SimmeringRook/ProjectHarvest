using Core.Adapters.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Queries
{
    internal class MealTimeQuery : IHarvestQuery
    {
        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.MealTime.Load();
            List<string> mealTimes = new List<string>();
            foreach (MealTime mealTIme in HarvestDatabase.MealTime.ToList())
                mealTimes.Add(mealTIme.MealName);
            return mealTimes;
        }

        public void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }
    }
}
