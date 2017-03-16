using System;
using System.Data.Entity;
using System.Linq;

namespace Core.DatabaseUtilities.Queries
{
    public class IngredientCategoryQuery : IHarvestQuery
    {

        public object Get(object itemID)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Inventory.Load();
                Inventory item = harvestDatabase.Inventory.SingleOrDefault(inventory => inventory.InventoryID == (int) itemID);

                harvestDatabase.IngredientCategory.Load();
                return harvestDatabase.IngredientCategory.SingleOrDefault(ingredientCategory => ingredientCategory.Category.Equals(item.Category));
            }
        }

        public void Insert(object itemToAdd)
        {
            throw new NotImplementedException();
        }

        public void Remove(object itemToRemove)
        {
            throw new NotImplementedException();
        }

        public void Update(object itemToChange)
        {
            throw new NotImplementedException();
        }
    }

}
