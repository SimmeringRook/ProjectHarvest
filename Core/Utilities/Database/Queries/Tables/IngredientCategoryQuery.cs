using Core.Adapters.Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    internal class IngredientCategoryQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.IngredientCategory.Load();
            Inventory item = HarvestDatabase.Inventory.SingleOrDefault(inventory => inventory.InventoryID == (int) itemID);
            return HarvestDatabase.IngredientCategory.SingleOrDefault(ingredientCategory => ingredientCategory.Category.Equals(item.Category));
        }

        public void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }
    }

}
