using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.DatabaseUtilities.Queries
{
    public class RecipeQuery : IHarvestQuery
    {
        public object Get(object itemID)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Recipe.Load();
                if ((int)itemID == -1)
                    return harvestDatabase.Recipe.ToList();
                return harvestDatabase.Recipe.SingleOrDefault(inventory => inventory.RecipeID.Equals((int)itemID));
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
                harvestDatabase.Recipe.AddOrUpdate(itemToChange as Recipe);
                harvestDatabase.SaveChanges();
            }
        }
    }
}
