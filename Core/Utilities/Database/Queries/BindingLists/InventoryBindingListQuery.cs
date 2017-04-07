using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    public class InventoryBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList(HarvestDatabaseEntities _HarvestDatabase)
        {
            _HarvestDatabase.Inventory.Load();
            return _HarvestDatabase.Inventory.Local.ToBindingList();
        }
    }
}
