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

            foreach (MealTime mealTIme in HarvestDatabase.MealTime.ToList())
                mealTimes.Add(mealTIme.MealName);

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
