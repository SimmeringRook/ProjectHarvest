namespace Core
{
    public partial class MealTime
    {
        public MealTime(string mealTime)
        {
            this.MealName = mealTime;
        }

        public override bool Equals(object obj)
        {
            MealTime mealTime = obj as MealTime;
            return this.MealName.Equals(mealTime.MealName);
        }

        public override int GetHashCode()
        {
            return this.MealName.GetHashCode();
        }
    }
}
