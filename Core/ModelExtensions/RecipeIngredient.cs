using Core.Utilities.UnitConversions;
using System;

namespace Core
{
    public partial class RecipeIngredient : ICloneable
    {
        public RecipeIngredient()
        {

        }

        public RecipeIngredient(double amount, MeasurementUnit unit)
        {
            this.Amount = amount;
            this.Measurement = unit.ToString();   
        }

        public object Clone()
        {
            RecipeIngredient deepClone = (RecipeIngredient)this.MemberwiseClone();
            deepClone.RecipeID = this.RecipeID;
            deepClone.InventoryID = this.InventoryID;
            deepClone.Amount = this.Amount;
            deepClone.Measurement = string.Copy(this.Measurement);
            return deepClone;
        }

        public MeasurementUnit GetMeasurementUnit()
        {
            return (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), this.Measurement, true);
        }
    }
}
