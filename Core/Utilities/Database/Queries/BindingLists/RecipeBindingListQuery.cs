using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    internal class RecipeBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList(Adapters.Database.HarvestDatabaseEntities _HarvestDatabase)
        {
            _HarvestDatabase.Recipe.Load();
            return _HarvestDatabase.Recipe.Local.ToBindingList();
        }
    }
}