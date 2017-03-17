using Core.MeasurementConversions;
using System;

namespace Core
{
    public partial class RecipeIngredient 
    {
        public RecipeIngredient()
        {

        }

        public RecipeIngredient(double amount, MeasurementUnit unit)
        {
            this.Amount = amount;
            this.Measurement = unit.ToString();   
        }
        public MeasurementUnit GetMeasurementUnit()
        {
            return (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), this.Measurement, true);
        }
    }
}
