using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.DatabaseUtilities.Queries
{
    public class InventoryQuery : IHarvestQuery
    {

        public object Get(object itemID)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Inventory.Load();
                if ((int)itemID == -1)
                    return harvestDatabase.Inventory.ToList();
                return harvestDatabase.Inventory.SingleOrDefault(inventory => inventory.InventoryID.Equals((int) itemID));
            }
        }

        public void Insert(object itemToAdd)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Inventory.Load();
                harvestDatabase.Inventory.Add(itemToAdd as Inventory);
                harvestDatabase.SaveChanges();
            }
        }

        public void Remove(object itemToRemove)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Inventory.Load();
                harvestDatabase.Inventory.Remove(itemToRemove as Inventory);
                harvestDatabase.SaveChanges();
            }
        }

        public void Update(object itemToChange)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Inventory.Load();
                harvestDatabase.Inventory.AddOrUpdate(itemToChange as Inventory);
                harvestDatabase.SaveChanges();
            }
        }
    }
}
