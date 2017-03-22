using System;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    public class RecipeCategoryQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.Recipe.Load();
            Recipe item = HarvestDatabase.Recipe.SingleOrDefault(recipe => recipe.RecipeID == (int)itemID);

            HarvestDatabase.RecipeClass.Load();
            return HarvestDatabase.RecipeClass.SingleOrDefault(recipeCategory => recipeCategory.RCategory.Equals(item.RCategory));
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
