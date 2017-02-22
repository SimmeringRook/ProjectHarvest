using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.DatabaseUtilities
{
    public static class RecipeIngredientUtility
    {
        public static List<RecipeIngredient> GetRecipeIngredients(Recipe recipe)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                context.RecipeIngredient.Load();
                return context.RecipeIngredient.Where(r => r.RecipeID == recipe.RecipeID).ToList();
            }
        }

        public static void UpdateTable(Recipe recipe)
        {
            HandleNonExistantIngredients(recipe);

            using (HarvestEntities context = new HarvestEntities())
            {
                context.Inventory.Load();
                foreach (Inventory ingredient in recipe.AssociatedItems)
                {
                    RecipeIngredient ri = new RecipeIngredient();
                    ri.RecipeID = recipe.RecipeID;
                    ri.InventoryID = context.Inventory.SingleOrDefault(i => i.IngredientName.Equals(ingredient.IngredientName)).InventoryID;
                    ri.Amount = ingredient.Amount;
                    ri.Measurement = ingredient.Measurement;

                    context.RecipeIngredient.Add(ri); //This -should- work?
                }

            }
        }

        /// <summary>
        /// Creates empty ingredient records in the Inventory table
        /// </summary>
        private static void HandleNonExistantIngredients(Recipe recipe)
        {

            //Get the modified list of ingredients
            List<Inventory> ingredientsThatNeedToBeCreated = RecipeUtility.GetIngredientsThatDontExist(recipe);

            if (ingredientsThatNeedToBeCreated.Count < 1)
                return;

            using (HarvestEntities context = new HarvestEntities())
            {
                context.Inventory.Load();

                foreach (Inventory ingredient in ingredientsThatNeedToBeCreated)
                {
                    //TODO : Clarify what values we want to be stored in these empty records
                    ingredient.Measurement = "Ounces";
                    ingredient.Amount = 0.0d;

                    context.Inventory.Add(ingredient);
                }

            }
        }

        public static List<Inventory> GetInventoryItemsAssociatedWithRecipe(Recipe recipe)
        {
            List<Inventory> items = new List<Inventory>();

            List<RecipeIngredient> recipeIngredients = RecipeIngredientUtility.GetRecipeIngredients(recipe);
            using (HarvestEntities context = new HarvestEntities())
            {
                foreach (RecipeIngredient ri in recipeIngredients)
                    items.Add(context.Inventory.SingleOrDefault(i => i.InventoryID == ri.InventoryID));
            }

            return items;
        }
    }
}
