using Core.Adapters.Database;
using Core.Cache;
using System;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Queries
{
    internal class MealTimeQuery : IHarvestQuery
    {
        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.MealTime.Load();
            Cache<string> mealTimes = new Cache<string>();

            foreach (MealTime mealTime in HarvestDatabase.MealTime.ToList())
                mealTimes.Add(mealTime.MealName);

            var lunch = mealTimes.Last();
            mealTimes[2] = mealTimes[1];
            mealTimes[1] = lunch;

            mealTimes.RaiseListChangedEvents = true;
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
