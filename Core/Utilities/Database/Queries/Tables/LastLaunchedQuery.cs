using Core.Adapters.Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    internal class LastLaunchedQuery : IHarvestQuery
    {        
       
        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.LastLaunched.Load();
            return HarvestDatabase.LastLaunched.ToList();
        }

        public void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.LastLaunched.Load();
            HarvestDatabase.LastLaunched.Add(itemToAdd as LastLaunched);
            HarvestDatabase.SaveChanges();
        }

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabas)
        {
            throw new NotImplementedException();
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabas)
        {
            throw new NotImplementedException();
        }
    }
}
