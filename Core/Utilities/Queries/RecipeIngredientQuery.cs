using Core.Adapters.Database;
using Core.Adapters.Factories;
using Core.Cache;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Utilities.Queries
{
    internal class RecipeIngredientQuery : IHarvestQuery
    {
        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.RecipeIngredient.Load();
            Cache<Adapters.Objects.RecipeIngredient> ingredients = new Cache<Adapters.Objects.RecipeIngredient>();

            if (itemID is int)
            {
                if ((int)itemID == -1)
                {
                    foreach (Adapters.Database.RecipeIngredient dbRecipeIngredient in HarvestDatabase.RecipeIngredient.ToList())
                        ingredients.Add(RecipeIngredientFactory.Create_Client_From_Database(dbRecipeIngredient));
                }
                else
                {
                    foreach (Adapters.Database.RecipeIngredient dbRecipeIngredient in HarvestDatabase.RecipeIngredient.Where(inventory => inventory.RecipeID.Equals((int)itemID)).ToList())
                        ingredients.Add(RecipeIngredientFactory.Create_Client_From_Database(dbRecipeIngredient));
                }
                return ingredients;
            }
            else
            {
                var clientItem = itemID as Adapters.Objects.RecipeIngredient;
                return HarvestDatabase.RecipeIngredient.SingleOrDefault(
                    item => item.RecipeID == clientItem.RecipeID && item.InventoryID == clientItem.Inventory.ID);
            }    
        }

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.RecipeIngredient.Load();
            Adapters.Objects.RecipeIngredient recipeIngredient = itemToRemove as Adapters.Objects.RecipeIngredient;
            Adapters.Database.RecipeIngredient ingredientToDelete = HarvestDatabase.RecipeIngredient.Single(ri =>
               ri.RecipeID == recipeIngredient.RecipeID &&
               ri.InventoryID == recipeIngredient.Inventory.ID
                );
            HarvestDatabase.RecipeIngredient.Remove(ingredientToDelete);
            HarvestDatabase.SaveChanges();
        }

        public void Insert(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            AddOrUpdate(itemToChange as Adapters.Objects.RecipeIngredient, HarvestDatabase);
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            AddOrUpdate(itemToChange as Adapters.Objects.RecipeIngredient, HarvestDatabase);
        }

        private void AddOrUpdate(Adapters.Objects.RecipeIngredient itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.RecipeIngredient.Load();

            Adapters.Database.RecipeIngredient dbRecipeIngredient = RecipeIngredientFactory.Create_Database_From_Client(itemToChange);
            HarvestDatabase.RecipeIngredient.AddOrUpdate(dbRecipeIngredient);

            HarvestDatabase.SaveChanges();
        }
    }
}
