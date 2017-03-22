using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    public class InventoryQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            if ((int)itemID == -1)
                return HarvestDatabase.Inventory.ToList();
            return HarvestDatabase.Inventory.SingleOrDefault(inventory => inventory.InventoryID.Equals((int) itemID));
        }

        public void Insert(object itemToAdd, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            HarvestDatabase.Inventory.Add(itemToAdd as Inventory);
            HarvestDatabase.SaveChanges();
        }

        public void Remove(object itemToRemove, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            HarvestDatabase.Inventory.Remove(itemToRemove as Inventory);
            HarvestDatabase.SaveChanges();
        }

        public void Update(object itemToChange, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            HarvestDatabase.Inventory.AddOrUpdate(itemToChange as Inventory);
            HarvestDatabase.SaveChanges();
        }
    }
}
