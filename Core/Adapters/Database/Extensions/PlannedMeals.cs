namespace Core.Adapters.Database
{
    internal partial class PlannedMeals
    {
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            PlannedMeals comparison = obj as PlannedMeals;
            bool sameRecipe = this.RecipeID.Equals(comparison.RecipeID);
            bool sameDay = this.DatePlanned.Date.Equals(comparison.DatePlanned.Date);
            bool sameTime = this.MealTime.Equals(comparison.MealTime);
            return (sameRecipe && sameDay && sameTime);
        }

        public override int GetHashCode()
        {
            return Utilities.General.HashGenerator.Hash(this.DatePlanned.Date, this.MealTime, this.MealEaten, this.RecipeID);
        }
    }
}
