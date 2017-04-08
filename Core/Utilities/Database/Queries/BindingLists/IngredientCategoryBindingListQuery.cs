using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    internal class IngredientCategoryBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList(Adapters.Database.HarvestDatabaseEntities _HarvestDatabase)
        {
            _HarvestDatabase.IngredientCategory.Load();
            return _HarvestDatabase.IngredientCategory.Local.ToBindingList();
        }
    }
}
