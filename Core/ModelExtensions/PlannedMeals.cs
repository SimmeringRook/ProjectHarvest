using Core.DatabaseUtilities.Queries;
using System;

namespace Core
{
    public partial class PlannedMeals
    {

        public PlannedMeals()
        {
            if (this.RecipeID != 0)
                this.Recipe = new Recipe(this.RecipeID);
            if (string.IsNullOrWhiteSpace(this.MealName) == false)
                try
                {
                    using (HarvestUtility harvest = new HarvestUtility(new MealTimeQuery()))
                        this.MealTime = harvest.Get(this.MealName) as MealTime;
                }
                catch(Exception ex)
                {
                    var exception = ex;
                }
        }

        private PlannedMeals(DateTime day, int recipeID, MealTime mealTime)
        {
            this.DatePlanned = day.Date;
            this.RecipeID = recipeID;
            //this.Recipe = new Recipe(recipeID);
            this.MealName = mealTime.MealName;

            this.MealEaten = false;
        }

        public static PlannedMeals CreateRecord(DateTime day, int recipeID, MealTime mealTime)
        {
            return new PlannedMeals(day, recipeID, mealTime);
        }

    }
}
