﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Adapters.Factories
{
    //Do I actually need a client version of Planned Meal?
    internal class PlannedMealFactory
    {

        /// <summary>
        /// Creates a Recipe Ingredient Object for Client_Desktop use from a RecipeIngredient (database) record.
        /// This will return an empty Recipe Ingredient object (0 for numeric fields, "Error" for strings) if
        /// the record could not be found.
        /// </summary>
        internal static Objects.PlannedMeal Create_Client_From_Database(Database.PlannedMeals databaseMeal)
        {
            if (databaseMeal != null)
            {
                //Populate the Client_Desktop version of the Recipe Ingredient Object
                Objects.PlannedMeal clientMeal = new Objects.PlannedMeal(
                    RecipeFactory.Create_Client_From_Database(databaseMeal.RecipeID),
                    databaseMeal.MealName,
                    databaseMeal.DatePlanned,
                    databaseMeal.MealEaten
                    );
                
                return clientMeal;
            }

            return new Objects.PlannedMeal();
        }
    }
}