using System;

namespace Core
{
    public partial class MealTime : ICloneable
    {
        public object Clone()
        {
            MealTime deepClone = new MealTime();//(MealTime)this.MemberwiseClone();
            deepClone.MealName = string.Copy(this.MealName);
            return deepClone;
        }

        public override bool Equals(object obj)
        {
            MealTime mealTime = obj as MealTime;
            return this.MealName.Equals(mealTime.MealName);
        }

        public override int GetHashCode()
        {
            return Utilities.General.HashGenerator.Hash(this.MealName);
        }
    }
}
