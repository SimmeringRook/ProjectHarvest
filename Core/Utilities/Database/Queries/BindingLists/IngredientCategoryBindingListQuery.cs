using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    public class IngredientCategoryBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList(HarvestDatabaseEntities _HarvestDatabase)
        {
            _HarvestDatabase.IngredientCategory.Load();
            return _HarvestDatabase.IngredientCategory.Local.ToBindingList();
        }
    }
}
