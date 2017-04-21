using Core.Utilities.Queries;
using System.Collections.Generic;

namespace Core.Adapters.Factories
{
    internal static class RecipeFactory
    {
        #region Form Object
        /// <summary>
        /// This creates a Recipe object for Client_Desktop from a record in the Recipe Table.
        /// This will return an empty Recipe Ingredient object (0 for numeric fields, "Error" for strings) if
        /// the record could not be found.
        /// </summary>
        internal static Objects.Recipe Create_Client_From_Database(Database.Recipe databaseRecipe)
        {
            if (databaseRecipe != null)
            {
                //Populate the Client_Desktop version of the Recipe Object
                Objects.Recipe clientRecipe = new Objects.Recipe(
                    databaseRecipe.RecipeID, 
                    databaseRecipe.RecipeName, 
                    databaseRecipe.Servings, 
                    databaseRecipe.RCategory);

                clientRecipe.AssociatedIngredients = RecipeIngredientFactory.GetIngredients_For_ClientRecipe(clientRecipe);
                clientRecipe.AssociatedIngredients.RaiseListChangedEvents = true;
                return clientRecipe;
            }

            return new Objects.Recipe();
        }

        internal static Objects.Recipe Create_Client_From_Database(int recipeID)
        {
            using (HarvestEntitiesUtility recipeTable = new HarvestEntitiesUtility(new RecipeQuery()))
                return Create_Client_From_Database(recipeTable.Get(recipeID) as Database.Recipe);
        }
        #endregion

        #region Database Object

        /// <summary>
        /// This takes a Client_Desktop Recipe object and transfers its data over to a Recipe database object.
        /// </summary>
        /// <param name="clientRecipe"></param>
        /// <returns></returns>
        internal static Database.Recipe Create_Database_From_Client(Objects.Recipe clientRecipe)
        {
            Database.Recipe databaseRecipe = new Database.Recipe();

            databaseRecipe.RecipeID = clientRecipe.ID;
            databaseRecipe.RecipeName = clientRecipe.Name;
            databaseRecipe.Servings = clientRecipe.Servings;
            databaseRecipe.RCategory = clientRecipe.Category;

            return databaseRecipe;
        }
        
        #endregion
    }
}
