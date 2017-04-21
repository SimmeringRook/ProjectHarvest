using Core.Adapters.Database;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Utilities.Queries
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

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.LastLaunched.Load();
            HarvestDatabase.LastLaunched.AddOrUpdate(itemToChange as LastLaunched);
            HarvestDatabase.SaveChanges();
        }
    }
}
