using System.Data.Entity;
using System.Linq;

namespace Core.DatabaseUtilities.Queries
{
    public class RecipeQuery : IHarvestQuery
    {
        public object Get(int itemID)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Recipe.Load();
                return harvestDatabase.Recipe.SingleOrDefault(inventory => inventory.RecipeID.Equals(itemID));
            }
        }

        public void Insert(object itemToAdd)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Recipe.Load();
                harvestDatabase.Recipe.Add(itemToAdd as Recipe);
                harvestDatabase.SaveChanges();
            }
        }

        public void Remove(object itemToRemove)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Recipe.Load();
                harvestDatabase.Recipe.Remove(itemToRemove as Recipe);
                harvestDatabase.SaveChanges();
            }
        }

        public void Update(object itemToChange)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Recipe.Load();
                Recipe itemInDatabase = Get((itemToChange as Recipe).RecipeID) as Recipe;
                itemInDatabase = itemToChange as Recipe;
                harvestDatabase.SaveChanges();
            }
        }
    }
}
