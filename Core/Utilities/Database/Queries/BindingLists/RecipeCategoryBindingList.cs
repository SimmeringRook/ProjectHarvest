using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    public class RecipeCategoryBindingList : IHarvestBindingList
    {
        public object GetBindingList(HarvestDatabaseEntities _HarvestDatabase)
        {
            _HarvestDatabase.RecipeClass.Load();
            return _HarvestDatabase.RecipeClass.Local.ToBindingList();
        }
    }
}
