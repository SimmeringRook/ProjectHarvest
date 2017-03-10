using System.Data.Entity;

namespace Core.DatabaseUtilities.BindingListQueries
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