using System;
using System.Data.Entity;
using System.Linq;

namespace Core.DatabaseUtilities.Queries
{
    public class RecipeIngredientQuery : IHarvestQuery
    {
        public object Get(int itemID)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.RecipeIngredient.Load();
                return harvestDatabase.RecipeIngredient.Where(inventory => inventory.RecipeID.Equals(itemID)).ToList();
            }
        }

        public void Insert(object itemToAdd)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.RecipeIngredient.Load();
                harvestDatabase.RecipeIngredient.Add(itemToAdd as RecipeIngredient);
                harvestDatabase.SaveChanges();
            }
        }

        public void Remove(object itemToRemove)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.RecipeIngredient.Load();
                harvestDatabase.RecipeIngredient.Remove(itemToRemove as RecipeIngredient);
                harvestDatabase.SaveChanges();
            }
        }

        public void Update(object itemToChange)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.RecipeIngredient.Load();
                RecipeIngredient itemInDatabase = Get((itemToChange as RecipeIngredient).RecipeID) as RecipeIngredient;
                itemInDatabase = itemToChange as RecipeIngredient;
                harvestDatabase.SaveChanges();
            }
        }
    }
}
