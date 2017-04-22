namespace Core.Adapters.Factories
{
    internal static class RecipeIngredientFactory
    {
        #region Form Object
        /// <summary>
        /// Creates a Recipe Ingredient Object for Client_Desktop use from a RecipeIngredient (database) record.
        /// This will return an empty Recipe Ingredient object (0 for numeric fields, "Error" for strings) if
        /// the record could not be found.
        /// </summary>
        internal static Objects.RecipeIngredient Create_Client_From_Database(Database.RecipeIngredient databaseRecipeIngredient)
        {
            if (databaseRecipeIngredient != null)
                return new Objects.RecipeIngredient(databaseRecipeIngredient.RecipeID,
                    InventoryFactory.Create_Client_From_Database(databaseRecipeIngredient.InventoryID),
                    databaseRecipeIngredient.Amount, databaseRecipeIngredient.Measurement);
            else
                return new Objects.RecipeIngredient();
        }
        #endregion

        #region Database Object
        /// <summary>
        /// This takes a Client_Desktop Recipe Ingredient object and transfers its data over to a Recipe Ingredient database object.
        /// </summary>
        internal static Database.RecipeIngredient Create_Database_From_Client(Objects.RecipeIngredient clientRecipeIngredient)
        {
            Database.RecipeIngredient databaseRecipeIngredient = new Database.RecipeIngredient();

            databaseRecipeIngredient.RecipeID = clientRecipeIngredient.RecipeID;
            databaseRecipeIngredient.InventoryID = clientRecipeIngredient.Inventory.ID;
            databaseRecipeIngredient.Amount = clientRecipeIngredient.Amount;
            databaseRecipeIngredient.Measurement = clientRecipeIngredient.Measurement.ToString();

            return databaseRecipeIngredient;
        }
        #endregion
    }
}