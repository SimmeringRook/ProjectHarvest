using System;

namespace Core.Utilities.UnitConversions
{
    public class HarvestConverter : IDisposable
    {
        public IUnitConvertable ConversionType;
        private string invalidConversionExceptionMessage = "Harvest encountered an issue when trying to convert from: {0} to {1}.\n" +
                    "Please ensure that the measurement category (Volume vs Weight units) Ingredient matches the same category as its Inventory item.\n" +
                    "Ingredient: {2} uses {0}\nInventory Item: {2} uses {3}";
        public HarvestConverter(IUnitConvertable conversionType)
        {
            ConversionType = conversionType;
        }

        public bool IsCorrectMeasurementType(MeasurementUnit measurement)
        {
            return ConversionType.IsCorrectMeasurementType(measurement);
        }

        /// <summary>
        /// Returns the given Ingredient's amount, converted to the same unit as unitToConvertTo.
        /// </summary>
        public ConvertedIngredient Convert(ConvertedIngredient ingredientToConvert, MeasurementUnit unitToConvertTo)
        {
            if (!ConversionType.IsCorrectMeasurementType(unitToConvertTo) || !ConversionType.IsCorrectMeasurementType(ingredientToConvert.Measurement))
            {
                string completeExceptionMessage = string.Format(
                    invalidConversionExceptionMessage,
                    ingredientToConvert.Measurement, 
                    unitToConvertTo.ToString(),
                    ingredientToConvert.Ingredient.Inventory.Name,
                    ingredientToConvert.Ingredient.Inventory.Measurement
                    ); //TODO Can I tie in the recipe to this?
                throw new InvalidConversionException(completeExceptionMessage);
            }
                
            if (IsMetricUnitSystem(ingredientToConvert.Measurement) != IsMetricUnitSystem(unitToConvertTo))
                ConvertToSameUnitSystem(ref ingredientToConvert);

            double convertedAmount = ingredientToConvert.Amount;

            if ((int)ingredientToConvert.Measurement > (int)unitToConvertTo)
            {
                //Converting from bigger to smaller unit
                for (int i = (int)ingredientToConvert.Measurement - 1; i >= (int)unitToConvertTo; i--)
                    convertedAmount /= MeasurementConversionFactors.ConversionFactors[i];
            }
            else
            {
                //Converting from smaller to Bigger
                for (int i = (int)ingredientToConvert.Measurement; i < (int)unitToConvertTo; i++)
                    convertedAmount *= MeasurementConversionFactors.ConversionFactors[i];
            }

            return new ConvertedIngredient(convertedAmount, unitToConvertTo);
        }

        private bool IsMetricUnitSystem(MeasurementUnit unitToCheck)
        {
            return (((int)unitToCheck >= (int)MeasurementUnit.MilliLiter) && ((int)unitToCheck <= (int)MeasurementUnit.Kilogram));
        }

        /// <summary>
        /// Converts the ingredient to the same measurement system.
        /// </summary>
        /// <param name="ingredientToConvert"></param>
        private void ConvertToSameUnitSystem(ref ConvertedIngredient ingredientToConvert)
        {
            MeasurementUnit unitToStandarizeWith = (IsMetricUnitSystem(ingredientToConvert.Measurement))
                ? MeasurementUnit.MilliLiter
                : MeasurementUnit.FluidOunce;

            if (ingredientToConvert.Measurement != unitToStandarizeWith)
                ingredientToConvert = Convert(ingredientToConvert, unitToStandarizeWith);
               
            if (IsMetricUnitSystem(ingredientToConvert.Measurement))
            {
                ingredientToConvert = new ConvertedIngredient(
                    ingredientToConvert.Amount * MeasurementConversionFactors.GetMilliliterToFluidOunceRatio(),
                    MeasurementUnit.FluidOunce);
            }
            else
            {
                ingredientToConvert = new ConvertedIngredient(
                    ingredientToConvert.Amount / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio(),
                    MeasurementUnit.MilliLiter);
            }  
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }
                ConversionType = null;
                invalidConversionExceptionMessage = null;
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
