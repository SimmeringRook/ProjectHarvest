using System;
using System.Data.Entity;
using System.Linq;

namespace Core.DatabaseUtilities.Queries
{
    public class RecipeCategoryQuery : IHarvestQuery
    {

        public object Get(int itemID)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Recipe.Load();
                Recipe item = harvestDatabase.Recipe.SingleOrDefault(recipe => recipe.RecipeID == itemID);

                harvestDatabase.RecipeClass.Load();
                return harvestDatabase.RecipeClass.SingleOrDefault(recipeCategory => recipeCategory.RCategory.Equals(item.RCategory));
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
