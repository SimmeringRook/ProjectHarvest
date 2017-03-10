using System;
using System.Data.Entity;
using System.Linq;

namespace Core.DatabaseUtilities
{
    public class MetricQuery : IHarvestQuery
    {

        public object Get(int itemID)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Inventory.Load();
                Inventory item = harvestDatabase.Inventory.SingleOrDefault(i => i.InventoryID == itemID);

                harvestDatabase.Metric.Load();
                return harvestDatabase.Metric.SingleOrDefault(m => m.Measurement.Equals(item.Measurement));
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
