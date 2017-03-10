using Core;
using Core.DatabaseUtilities;
using System.Collections.Generic;
using System.Linq;

namespace Client_Desktop.Helpers
{
    public static class CreateRecipeUtility
    {
        public static void SubmitRecipeAndIngredientsToDatabase(Recipe recipeFromControls, List<IngredientInformation> ingredients)
        {
            //Create the recipe record
            SubmitRecipeToDatabase(recipeFromControls);

            //Get the newly created record and build the AssociatedItems list
            Recipe recipe = GetRecentlyCreatedRecipe();
            BindAssociatedItemsToInventoryIDs(recipe, ingredients);

            List<Inventory> ingredientsThatDontExist = GetListOfInventoryItemsThatAreNotInDatabase(recipe);

            if (ingredientsThatDontExist.Count > 0)
            {
                CreateInventoryItemsThatAreNotInDatabase(ingredientsThatDontExist);
                BindNewItemsToInventoryIDs(recipe);
                ingredientsThatDontExist = null;
            }

            AddIngredientsToDatabase(recipe);
        }

        #region Recipe
        private static void SubmitRecipeToDatabase(Recipe recipeFromControls)
        {
            using (HarvestUtility harvest = new HarvestUtility(new RecipeQuery()))
                harvest.Insert(recipeFromControls);
        }

        private static Recipe GetRecentlyCreatedRecipe()
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
                return harvestDatabase.Recipe.OrderByDescending(id => id.RecipeID).First();
        }
        #endregion

        #region Inventory
        private static void BindAssociatedItemsToInventoryIDs(Recipe recipe, List<IngredientInformation> ingredients)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                foreach (IngredientInformation ingredientInfo in ingredients)
                {
                    Inventory listedIngredient = ingredientInfo.GetInventoryFromControls();
                    listedIngredient.InventoryID = harvestDatabase.Inventory.SingleOrDefault(item => item.IngredientName.Equals(listedIngredient.IngredientName)).InventoryID;
                    recipe.AssociatedInventoryItems.Add(listedIngredient);
                }
            }
        }

        private static List<Inventory> GetListOfInventoryItemsThatAreNotInDatabase(Recipe recipe)
        {
            List<Inventory> ingredientsThatDontExist = new List<Inventory>();
            foreach (Inventory ingredient in recipe.AssociatedInventoryItems)
            {
                if (ingredient.InventoryID == 0)
                    ingredientsThatDontExist.Add(ingredient);
            }
            return ingredientsThatDontExist;
        }

        private static void CreateInventoryItemsThatAreNotInDatabase(List<Inventory> ingredientsThatDontExist)
        {
            using (HarvestUtility harvest = new HarvestUtility(new InventoryQuery()))
            {
                foreach (Inventory ingredientToCreate in ingredientsThatDontExist)
                {
                    Inventory emptyIngredient = ingredientToCreate;
                    emptyIngredient.Amount = 0.0d;
                    harvest.Insert(emptyIngredient);
                }
            }
        }

        private static void BindNewItemsToInventoryIDs(Recipe recipe)
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                //Ensure each ingredient has an ID now
                foreach (Inventory ingredient in recipe.AssociatedInventoryItems)
                    ingredient.InventoryID = harvestDatabase.Inventory.SingleOrDefault(item => item.IngredientName.Equals(ingredient.IngredientName)).InventoryID;
            }
        }

        #endregion

        #region Recipe Ingredients
        private static void AddIngredientsToDatabase(Recipe recipe)
        {
            using (HarvestUtility harvest = new HarvestUtility(new RecipeIngredientQuery()))
            {
                foreach (Inventory ingredient in recipe.AssociatedInventoryItems)
                    harvest.Insert(CreateRecipeIngredient(recipe.RecipeID, ingredient));
            }
        }

        private static RecipeIngredient CreateRecipeIngredient(int recipeID, Inventory ingredient)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();
            recipeIngredient.RecipeID = recipeID;
            recipeIngredient.InventoryID = ingredient.InventoryID;
            recipeIngredient.Amount = ingredient.Amount;
            recipeIngredient.Measurement = ingredient.Measurement;
            return recipeIngredient;
        }
        #endregion
    }
}
