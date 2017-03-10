using System.Data.Entity;
using System.Linq;

namespace Core.DatabaseUtilities
{
    public class InventoryQuery : IHarvestQuery
    {

        public object Get(int itemID)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Inventory.Load();
                return harvestDatabase.Inventory.SingleOrDefault(inventory => inventory.InventoryID.Equals(itemID));
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
                Inventory itemInDatabase = Get((itemToChange as Inventory).InventoryID) as Inventory;
                itemInDatabase = itemToChange as Inventory;
                harvestDatabase.SaveChanges();
            }
        }
    }
}
