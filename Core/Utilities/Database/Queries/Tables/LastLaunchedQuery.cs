using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    public class LastLaunchedQuery : IHarvestQuery
    {        
       
        public object Get(object itemID, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.LastLaunched.Load();
            return HarvestDatabase.LastLaunched.ToList();
        }

        public void Insert(object itemToAdd, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.LastLaunched.Add(itemToAdd as LastLaunched);
            HarvestDatabase.SaveChanges();
        }

        public void Remove(object itemToRemove, HarvestEntities HarvestDatabas)
        {
            throw new NotImplementedException();
        }

        public void Update(object itemToChange, HarvestEntities HarvestDatabas)
        {
            throw new NotImplementedException();
        }
    }
}
