using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    public class RecipeBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList(HarvestDatabaseEntities _HarvestDatabase)
        {
            _HarvestDatabase.Recipe.Load();
            return _HarvestDatabase.Recipe.Local.ToBindingList();
        }
    }
}