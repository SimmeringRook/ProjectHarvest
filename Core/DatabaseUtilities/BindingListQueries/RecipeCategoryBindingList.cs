using System.Data.Entity;

namespace Core.DatabaseUtilities.BindingListQueries
{
    public class RecipeCategoryBindingList : IHarvestBindingList
    {
        public object GetBindingList()
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.RecipeClass.Load();
                return harvestDatabase.RecipeClass.Local.ToBindingList();
            }
        }
    }
}
