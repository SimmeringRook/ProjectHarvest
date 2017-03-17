using System;
using System.Collections.Generic;

namespace Core.MeasurementConversions
{
    public class HarvestConverter : IDisposable
    {
        public IUnitConvertable ConversionType;

        public HarvestConverter(IUnitConvertable conversionType)
        {
            ConversionType = conversionType;
        }

        public bool IsCorrectMeasurementType(MeasurementUnit measurement)
        {
            return ConversionType.IsCorrectMeasurementType(measurement);
        }

        public RecipeIngredient Convert(RecipeIngredient ingredientToConvert, MeasurementUnit unitToConvertTo)
        {
            //TODO: add in error handling for attempts to convert weight to volume (or volume to weight)
            if (!ConversionType.IsCorrectMeasurementType(unitToConvertTo) || !ConversionType.IsCorrectMeasurementType(ingredientToConvert.GetMeasurementUnit()))
                throw new System.Exception();

            //Get the list of conversion factors
            List<float> conversionFactors = MeasurementConversionFactors.GetRatios();

            //Ensure we're dealing with the same measurement system
            if (IsMetricUnitSystem(ingredientToConvert.GetMeasurementUnit()) != IsMetricUnitSystem(unitToConvertTo))
                ConvertToSameUnitSystem(ref ingredientToConvert);


            //Volume Units belong to the same measurement system now, continue converting to the desired unit
            double convertedAmount = ingredientToConvert.Amount;

            if ((int)ingredientToConvert.GetMeasurementUnit() > (int)unitToConvertTo)
            {
                //Converting from bigger to smaller unit
                for (int i = (int)ingredientToConvert.GetMeasurementUnit() - 1; i >= (int)unitToConvertTo; i--)
                    convertedAmount /= conversionFactors[i];
            }
            else
            {
                //Converting from smaller to Bigger
                for (int i = (int)ingredientToConvert.GetMeasurementUnit(); i < (int)unitToConvertTo; i++)
                    convertedAmount *= conversionFactors[i];
            }

            return new RecipeIngredient(convertedAmount, unitToConvertTo);
        }

        private bool IsMetricUnitSystem(MeasurementUnit unitToCheck)
        {
            return (((int)unitToCheck >= (int)MeasurementUnit.MilliLiter) && ((int)unitToCheck <= (int)MeasurementUnit.Kilogram));
        }

        private void ConvertToSameUnitSystem(ref RecipeIngredient ingredientToConvert)
        {
            //grab a reference of the amount that needs to be converted
            double amount = ingredientToConvert.Amount;

            bool startingWithMetric = IsMetricUnitSystem(ingredientToConvert.GetMeasurementUnit());
            MeasurementUnit unitToStandarizeWith = (startingWithMetric)
                ? MeasurementUnit.MilliLiter
                : MeasurementUnit.FluidOunce;

            //If the ingredient is not MilliLiter or Fluid Ounce (respective to the value of startingWithMetric)
            //Convert down/up to the respective unit
            if (ingredientToConvert.GetMeasurementUnit() != unitToStandarizeWith)
                ingredientToConvert = Convert(ingredientToConvert, unitToStandarizeWith);

            //Metric to US
            if (startingWithMetric)
                ingredientToConvert = new RecipeIngredient(
                    ingredientToConvert.Amount * MeasurementConversionFactors.GetMilliliterToFluidOunceRatio(),
                    MeasurementUnit.FluidOunce);
            //US to Metric
            else
                ingredientToConvert = new RecipeIngredient(
                    ingredientToConvert.Amount / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio(),
                    MeasurementUnit.MilliLiter);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~HarvestConverter() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
