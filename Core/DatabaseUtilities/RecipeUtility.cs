using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

/// <summary>
/// The Try/Catch blocks should be placed on the forms in the methods that call these methods.
/// If an expection occurs (ie, cannot connect to DB), that needs to be handled at the GUI level,
/// not inside here.
/// </summary>
namespace Core.DatabaseUtilities
{
    public class RecipeUtility
    {
        public static void UpdateRecipeInDatabase(Recipe modifiedRecipe)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                context.Recipe.Load();
                Recipe recipeInDB = context.Recipe.SingleOrDefault(recipe => recipe.RecipeName == modifiedRecipe.RecipeName);

                if (recipeInDB != null)
                {
                    //Assign new values
                    recipeInDB.RecipeName = modifiedRecipe.RecipeName;
                    recipeInDB.Servings = modifiedRecipe.Servings;
                    recipeInDB.RCategory = modifiedRecipe.RCategory;
                }
                else
                {
                    context.Recipe.Add(modifiedRecipe);
                }
                context.SaveChanges();
            }
        }

        public static void RemoveRecipeFromDatabase(Recipe recipeToRemove)
        {

        }
        

        #region Get Ingredients
        /// <summary>
        /// This returns a list of ingredients that do not currently exist in the database.
        /// </summary>
        public static List<Inventory> GetIngredientsThatDontExist(Recipe recipe)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                context.Inventory.Load();
                List<Inventory> ingredientsThatAlreadyExist = new List<Inventory>();

                List<Inventory> ingredientsAssociatedWithRecipe = new List<Inventory>();
                foreach (Inventory item in recipe.AssociatedItems)
                    ingredientsAssociatedWithRecipe.Add(item);
                //TODO - consider swapping which list is itterated over
                //As the inventory will most likely always contain more records than
                //the ingredients associated with a new recipe

                //If the ingredient already exists as a record in the Inventory table
                //add it to the list of items to be removed
                foreach (Inventory ingredient in ingredientsAssociatedWithRecipe)
                    if (context.Inventory.Any(i => i.IngredientName.Equals(ingredient.IngredientName)))
                        ingredientsThatAlreadyExist.Add(ingredient);

                //Remove every ingredient that already exists in the Inventory table
                //because we don't need to create empty records for these ingredients
                foreach (Inventory itemToRemove in ingredientsThatAlreadyExist)
                    ingredientsAssociatedWithRecipe.Remove(itemToRemove);

                return ingredientsAssociatedWithRecipe;
            }
        }

        #endregion
        
        public static int GetRecipeCategoryFromRecipe(Recipe recipe)
        {
            using(HarvestEntities context = new HarvestEntities())
            {
                //Get the index of the recipe category
                context.RecipeClass.Load();
                var categories = context.RecipeClass.Local.ToList();

                int index = -1;
                
                foreach (var category in categories)
                {
                    if (category.RCategory.Equals(recipe.RCategory))
                        index = categories.IndexOf(category);
                }

                return index;
            }
        }

       
    }
}
