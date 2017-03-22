using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    public class RecipeBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList()
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Recipe.Load();
                return harvestDatabase.Recipe.Local.ToBindingList();
            }
        }
    }
}