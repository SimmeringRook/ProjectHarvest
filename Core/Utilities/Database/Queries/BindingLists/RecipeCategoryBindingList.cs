using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    internal class RecipeCategoryBindingList : IHarvestBindingList
    {
        public object GetBindingList(Adapters.Database.HarvestDatabaseEntities _HarvestDatabase)
        {
            _HarvestDatabase.RecipeClass.Load();
            return _HarvestDatabase.RecipeClass.Local.ToBindingList();
        }
    }
}
