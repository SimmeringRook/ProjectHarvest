using System.Data.Entity;

namespace Core.DatabaseUtilities.BindingListQueries
{
    public class IngredientCategoryBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList()
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.IngredientCategory.Load();
                return harvestDatabase.IngredientCategory.Local.ToBindingList();
            }
        }
    }
}
