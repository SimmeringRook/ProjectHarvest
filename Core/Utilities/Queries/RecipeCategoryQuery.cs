using Core.Adapters.Database;
using Core.Cache;
using System;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Queries
{
    internal class RecipeCategoryQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.RecipeClass.Load();
            Cache<string> categories = new Cache<string>();

            foreach (RecipeClass category in HarvestDatabase.RecipeClass.ToList())
                categories.Add(category.RCategory);

            categories.RaiseListChangedEvents = true;
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
