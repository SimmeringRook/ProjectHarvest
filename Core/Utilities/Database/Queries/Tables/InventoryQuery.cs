using Core.Adapters.Database;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    internal class InventoryQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            if ((int)itemID == -1)
                return HarvestDatabase.Inventory.ToList();
            return HarvestDatabase.Inventory.SingleOrDefault(inventory => inventory.InventoryID.Equals((int) itemID));
        }

        public void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            HarvestDatabase.Inventory.Add(itemToAdd as Inventory);
            HarvestDatabase.SaveChanges();
        }

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            Inventory inventory = itemToRemove as Inventory;
            var item = HarvestDatabase.Inventory.Single(inv => inv.InventoryID == inventory.InventoryID);
            HarvestDatabase.Inventory.Remove(item);
            HarvestDatabase.SaveChanges();
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            HarvestDatabase.Inventory.AddOrUpdate(itemToChange as Inventory);
            HarvestDatabase.SaveChanges();
        }
    }
}
