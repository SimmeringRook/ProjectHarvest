using Core.Adapters.Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    internal class MetricQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Metric.Load();
            Inventory item = HarvestDatabase.Inventory.SingleOrDefault(i => i.InventoryID == (int)itemID);
            return HarvestDatabase.Metric.SingleOrDefault(m => m.Measurement.Equals(item.Measurement));
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
