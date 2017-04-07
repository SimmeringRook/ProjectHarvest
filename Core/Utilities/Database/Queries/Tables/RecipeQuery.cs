using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    public class RecipeQuery : IHarvestQuery
    {
        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Recipe.Load();
            if ((int)itemID == -1)
                return HarvestDatabase.Recipe.ToList();
            return HarvestDatabase.Recipe.SingleOrDefault(inventory => inventory.RecipeID.Equals((int)itemID));
        }

        public void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Recipe.Load();
            HarvestDatabase.Recipe.Add(itemToAdd as Recipe);
            HarvestDatabase.SaveChanges();
        }

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Recipe.Load();
            var recipe = (itemToRemove as Recipe);
            var recipeToDelete = HarvestDatabase.Recipe.Single(r => r.RecipeID == recipe.RecipeID);
            HarvestDatabase.Recipe.Remove(recipeToDelete);
            HarvestDatabase.SaveChanges();
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Recipe.Load();
            HarvestDatabase.Recipe.AddOrUpdate(itemToChange as Recipe);
            HarvestDatabase.SaveChanges();
        }
    }
}
