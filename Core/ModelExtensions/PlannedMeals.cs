using Core.Utilities.Database.Queries.Tables;
using System;

namespace Core
{
    public partial class PlannedMeals : ICloneable
    {
        public PlannedMeals()
        {
            //Need to check if removing this breaks things:
            if (this.RecipeID != 0)
                this.Recipe = new Recipe(this.RecipeID);
            if (string.IsNullOrWhiteSpace(this.MealName) == false)
                try
                {
                    using (HarvestTableUtility harvest = new HarvestTableUtility(new MealTimeQuery()))
                        this.MealTime = harvest.Get(this.MealName) as MealTime;
                }
                catch (Exception ex)
                {
                    var exception = ex;
                }
        }

        private PlannedMeals(DateTime day, int recipeID, string mealTime)
        {
            this.DatePlanned = day.Date;
            this.RecipeID = recipeID;
            this.MealName = MealName;
            this.MealEaten = false;
        }

        public static PlannedMeals CreateRecord(DateTime day, int recipeID, string mealTime)
        {
            return new PlannedMeals(day, recipeID, mealTime);
        }

        public object Clone()
        {
            PlannedMeals deepClone = (PlannedMeals)this.MemberwiseClone();
            deepClone.DatePlanned = this.DatePlanned;

            deepClone.MealName = this.MealName;
            deepClone.RecipeID = this.RecipeID;
            //deepClone.Recipe = this.Recipe.Clone() as Recipe;

            deepClone.MealEaten = this.MealEaten;

            return deepClone;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            PlannedMeals meal = obj as PlannedMeals;
            bool sameRecipe = this.RecipeID == meal.RecipeID;
            bool sameDay = this.DatePlanned.Date == meal.DatePlanned.Date;
            bool sameTime = this.MealName.Equals(meal.MealName);
            return (sameRecipe && sameDay && sameTime);
        }

        public override int GetHashCode()
        {
            return Utilities.General.HashGenerator.Hash(this.DatePlanned.DayOfYear, this.RecipeID, this.MealName);
        }
    }
}
