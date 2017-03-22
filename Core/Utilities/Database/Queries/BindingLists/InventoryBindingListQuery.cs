using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    public class InventoryBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList()
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Inventory.Load();
                return harvestDatabase.Inventory.Local.ToBindingList();
            }
        }
    }
}
