using Core.MeasurementConversions;

namespace Core.RecipeMangement
{
    public class Ingredient
    {
        public float Amount { get; private set; }

        public MeasurementUnit Measurement { get; private set; }

        public Ingredient()
        {

        }

        public Ingredient(float amountOfIngredient, MeasurementUnit unitOfMeasurement)
        {
            Amount = amountOfIngredient;
            Measurement = unitOfMeasurement;
        }
    }
}
