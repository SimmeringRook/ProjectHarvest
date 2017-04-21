using Core.Adapters.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Queries
{
    internal class RecipeCategoryQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.RecipeClass.Load();
            List<string> categories = new List<string>();
            foreach (RecipeClass category in HarvestDatabase.RecipeClass.ToList())
                categories.Add(category.RCategory);
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
