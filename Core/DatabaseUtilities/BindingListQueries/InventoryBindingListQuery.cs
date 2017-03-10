using System.Data.Entity;

namespace Core.DatabaseUtilities.BindingListQueries
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
