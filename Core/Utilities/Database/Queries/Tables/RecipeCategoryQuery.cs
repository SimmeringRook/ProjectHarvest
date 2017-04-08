using Core.Adapters.Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    internal class RecipeCategoryQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Recipe.Load();
            Recipe item = HarvestDatabase.Recipe.SingleOrDefault(recipe => recipe.RecipeID == (int)itemID);
            return HarvestDatabase.RecipeClass.SingleOrDefault(recipeCategory => recipeCategory.RCategory.Equals(item.RCategory));
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
