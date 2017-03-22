using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
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
