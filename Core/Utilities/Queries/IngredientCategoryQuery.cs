using Core.Adapters.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Queries
{
    internal class IngredientCategoryQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.IngredientCategory.Load();
            List<string> categories = new List<string>();
            foreach (IngredientCategory category in HarvestDatabase.IngredientCategory.ToList())
                categories.Add(category.Category);
            return categories;
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
