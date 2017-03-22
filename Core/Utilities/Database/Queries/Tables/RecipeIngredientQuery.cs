using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    public class RecipeIngredientQuery : IHarvestQuery
    {
        public object Get(object itemID, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.RecipeIngredient.Load();
            if ((int)itemID == -1)
                return HarvestDatabase.RecipeIngredient.ToList();
            return HarvestDatabase.RecipeIngredient.Where(inventory => inventory.RecipeID.Equals((int)itemID)).ToList();
        }

        public void Insert(object itemToAdd, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.RecipeIngredient.Load();
            HarvestDatabase.RecipeIngredient.Add(itemToAdd as RecipeIngredient);
            HarvestDatabase.SaveChanges();
        }

        public void Remove(object itemToRemove, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.RecipeIngredient.Load();
            var r = itemToRemove as RecipeIngredient;
            var ingredientToDelete = HarvestDatabase.RecipeIngredient.Single(
                ri => ri.RecipeID == r.RecipeID &&
                ri.InventoryID == r.InventoryID
                );
            HarvestDatabase.RecipeIngredient.Remove(ingredientToDelete);
            HarvestDatabase.SaveChanges();
        }

        public void Update(object itemToChange, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.RecipeIngredient.Load();
            HarvestDatabase.RecipeIngredient.AddOrUpdate(itemToChange as RecipeIngredient);
            HarvestDatabase.SaveChanges();
        }
    }
}
