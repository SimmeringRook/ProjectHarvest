using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.DatabaseUtilities.Queries
{
    public class RecipeIngredientQuery : IHarvestQuery
    {
        public object Get(object itemID)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.RecipeIngredient.Load();
                return harvestDatabase.RecipeIngredient.Where(inventory => inventory.RecipeID.Equals((int)itemID)).ToList();
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
                harvestDatabase.RecipeIngredient.AddOrUpdate(itemToChange as RecipeIngredient);
                harvestDatabase.SaveChanges();
            }
        }
    }
}
