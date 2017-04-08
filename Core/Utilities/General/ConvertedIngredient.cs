using Core.Adapters.Objects;

namespace Core.Utilities.UnitConversions
{
    public struct ConvertedIngredient
    {
        public double Amount { get; set; }
        public MeasurementUnit Measurement { get; set; }
        public RecipeIngredient Ingredient { get; set; }

        public ConvertedIngredient(double amount, MeasurementUnit unit)
        {
            Amount = amount;
            Measurement = unit;
            Ingredient = null;
        }

        public ConvertedIngredient(RecipeIngredient ri)
        {
            Amount = ri.Amount;
            Measurement = ri.Measurement;
            Ingredient = ri;
        }
    }
}
