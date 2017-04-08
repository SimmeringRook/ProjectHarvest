using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    internal class InventoryBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList(Adapters.Database.HarvestDatabaseEntities _HarvestDatabase)
        {
            _HarvestDatabase.Inventory.Load();
            return _HarvestDatabase.Inventory.Local.ToBindingList();
        }
    }
}
