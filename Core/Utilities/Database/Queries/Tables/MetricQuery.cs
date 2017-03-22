using System;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    public class MetricQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            Inventory item = HarvestDatabase.Inventory.SingleOrDefault(i => i.InventoryID == (int)itemID);

            HarvestDatabase.Metric.Load();
            return HarvestDatabase.Metric.SingleOrDefault(m => m.Measurement.Equals(item.Measurement));
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
