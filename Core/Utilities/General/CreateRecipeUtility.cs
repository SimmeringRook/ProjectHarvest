using Core.Utilities.Database.Queries.Tables;
using System.Collections.Generic;
using System.Linq;

namespace Core.Utilities.General
{
    public static class CreateRecipeUtility
    {
        public static void SubmitRecipeAndIngredientsToDatabase(Recipe recipeFromControls, List<IngredientInformation> ingredients)
        {
            //Create the recipe record
            SubmitRecipeToDatabase(recipeFromControls);

            //Get the newly created record and build the AssociatedItems list
            Recipe recipe = (recipeFromControls.RecipeID > 0) ? recipeFromControls : GetRecentlyCreatedRecipe();
            BindAssociatedItemsToInventoryIDs(recipe, ingredients);

            List<Inventory> ingredientsThatDontExist = GetListOfInventoryItemsThatAreNotInDatabase(recipe);

            if (ingredientsThatDontExist.Count > 0)
            {
                CreateInventoryItemsThatAreNotInDatabase(ingredientsThatDontExist);
                BindNewItemsToInventoryIDs(recipe);
                ingredientsThatDontExist = null;
            }

            AddIngredientsToDatabase(recipe, ingredients);
        }

        #region Recipe
        private static void SubmitRecipeToDatabase(Recipe recipeFromControls)
        {
            using (HarvestTableUtility harvest = new HarvestTableUtility(new RecipeQuery()))
            {
                if (recipeFromControls.RecipeID == 0)
                    harvest.Insert(recipeFromControls);
                else
                    harvest.Update(recipeFromControls);
            }
                
        }

        private static Recipe GetRecentlyCreatedRecipe()
        {
            using (HarvestDatabaseEntities harvestDatabase = new HarvestDatabaseEntities())
                return harvestDatabase.Recipe.OrderByDescending(id => id.RecipeID).First();
        }
        #endregion

        #region Inventory
        private static void BindAssociatedItemsToInventoryIDs(Recipe recipe, List<IngredientInformation> ingredients)
        {
            using (HarvestDatabaseEntities harvestDatabase = new HarvestDatabaseEntities())
            {
                foreach (IngredientInformation ingredientInfo in ingredients)
                {
                    Inventory listedIngredient = ingredientInfo.GetInventoryFromControls();
                    Inventory itemInDB = harvestDatabase.Inventory.SingleOrDefault(item => item.IngredientName.Equals(listedIngredient.IngredientName));
                    listedIngredient.InventoryID = (itemInDB != null) ? itemInDB.InventoryID : 0;
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
            using (HarvestTableUtility harvest = new HarvestTableUtility(new InventoryQuery()))
            {
                foreach (Inventory ingredientToCreate in ingredientsThatDontExist)
                {
                    Inventory emptyIngredient = ingredientToCreate;
                    emptyIngredient.Amount = 0.0d;
                    emptyIngredient.Measurement = ingredientToCreate.Measurement;
                    emptyIngredient.Category = "Other";
                    harvest.Insert(emptyIngredient);
                }
            }
        }

        private static void BindNewItemsToInventoryIDs(Recipe recipe)
        {
            using (HarvestDatabaseEntities harvestDatabase = new HarvestDatabaseEntities())
            {
                //Ensure each ingredient has an ID now
                foreach (Inventory ingredient in recipe.AssociatedInventoryItems)
                    ingredient.InventoryID = harvestDatabase.Inventory.SingleOrDefault(item => item.IngredientName.Equals(ingredient.IngredientName)).InventoryID;
            }
        }

        #endregion

        #region Recipe Ingredients
        private static void AddIngredientsToDatabase(Recipe recipe, List<IngredientInformation> ingredients)
        {
            using (HarvestTableUtility harvest = new HarvestTableUtility(new RecipeIngredientQuery()))
            {
                List<RecipeIngredient> ingredientsThatExist = harvest.Get(-1) as List<RecipeIngredient>;
                foreach (Inventory ingredient in recipe.AssociatedInventoryItems)
                {
                    RecipeIngredient recipeIngredient = CreateRecipeIngredient(recipe.RecipeID, ingredient, ingredients);

                    if (ingredientsThatExist.Any(ri => ri.RecipeID == recipe.RecipeID && ri.InventoryID == ingredient.InventoryID))
                        harvest.Update(recipeIngredient);
                    else
                        harvest.Insert(recipeIngredient);
                }  
            }
        }

        private static RecipeIngredient CreateRecipeIngredient(int recipeID, Inventory ingredient, List<IngredientInformation> ingredients)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();
            recipeIngredient.RecipeID = recipeID;
            recipeIngredient.InventoryID = ingredient.InventoryID;
            recipeIngredient.Amount = double.Parse(ingredients.Single(ri => ri.Name.Text.Equals(ingredient.IngredientName)).Quantity.Text);
            recipeIngredient.Measurement = ingredient.Measurement;
            return recipeIngredient;
        }
        #endregion
    }
}
