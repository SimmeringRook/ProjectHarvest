namespace Core.Adapters.Factories
{
    internal class PlannedMealFactory
    {
        #region Form Object
        /// <summary>
        /// Creates a Recipe Ingredient Object for Client_Desktop use from a RecipeIngredient (database) record.
        /// This will return an empty Recipe Ingredient object (0 for numeric fields, "Error" for strings) if
        /// the record could not be found.
        /// </summary>
        internal static Objects.PlannedMeal Create_Client_From_Database(Database.PlannedMeals databaseMeal)
        {
            if (databaseMeal != null)
                return new Objects.PlannedMeal(RecipeFactory.Create_Client_From_Database(databaseMeal.RecipeID),
                    databaseMeal.MealName, databaseMeal.DatePlanned, databaseMeal.MealEaten);
            else
                return new Objects.PlannedMeal();
        }
        #endregion

        #region Database Object
        /// <summary>
        /// This takes a Client_Desktop Inventory object and transfers its data over to an Inventory database Object.
        /// </summary>
        /// <param name="clientMeal"></param>
        /// <returns></returns>
        internal static Database.PlannedMeals Create_Database_From_Client(Objects.PlannedMeal clientMeal)
        {
            Database.PlannedMeals databaseMeal = new Database.PlannedMeals();

            databaseMeal.RecipeID = clientMeal.PlannedRecipe.ID;
            databaseMeal.DatePlanned = clientMeal.Date;
            databaseMeal.MealEaten = clientMeal.HasBeenEaten;
            databaseMeal.MealName = clientMeal.MealTime;
            return databaseMeal;
        }
        #endregion
    }
}
