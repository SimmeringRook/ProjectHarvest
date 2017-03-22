using System;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    public class IngredientCategoryQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            Inventory item = HarvestDatabase.Inventory.SingleOrDefault(inventory => inventory.InventoryID == (int) itemID);

            HarvestDatabase.IngredientCategory.Load();
            return HarvestDatabase.IngredientCategory.SingleOrDefault(ingredientCategory => ingredientCategory.Category.Equals(item.Category));
        }

        public void Insert(object itemToAdd, HarvestEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }

        public void Remove(object itemToRemove, HarvestEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }

        public void Update(object itemToChange, HarvestEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }
    }

}
