using Core.RecipeMangement;
using System.Collections.Generic;

namespace Core.MeasurementConversions
{
    /// <summary>
    /// Handles all Same System and System-to-System Volume unit conversions.
    /// </summary>
    public static class VolumeUnitConverter
    {
        /* This lets us have one struct object for Ingredients,
         * If the unit of measurement is for volume, then we can allow the program 
         * to proceed Converting from one unit to another.
         * Otherwise, Convert should return false/an error that a weight unit was trying
         * to be converted to a volume unit (or vice versa).
         */

        private static List<MeasurementUnit> volumeUnits = new List<MeasurementUnit>()
        {
            MeasurementUnit.TeaSpoon,
            MeasurementUnit.TableSpoon,
            MeasurementUnit.FluidOunce,
            MeasurementUnit.Cup,
            MeasurementUnit.Pint,
            MeasurementUnit.Quart,
            MeasurementUnit.Gallon,
            MeasurementUnit.MilliLiter,
            MeasurementUnit.Liter
        };

        /// <summary>
        /// Returns whether or not a MeasurementUnit is a Volume unit (regardless of System)
        /// </summary>
        /// <param name="measurement"></param>
        /// <returns></returns>
        public static bool IsVolumeMeasurement(MeasurementUnit measurement)
        {
            foreach (MeasurementUnit unit in volumeUnits)
            {
                if (unit == measurement)
                    return true;
            }
            return false;
        }

        public static Ingredient Convert(Ingredient ingredientToConvert, MeasurementUnit unitToConvertTo)
        {
            //TODO: add in error handling for attempts to convert weight to volume (or volume to weight)
            if (!IsVolumeMeasurement(unitToConvertTo) || !IsVolumeMeasurement(ingredientToConvert.Measurement))
                throw new System.Exception();

            //Get the list of conversion factors
            List<float> conversionFactors = MeasurementConversionFactors.GetRatios();
                
            //Ensure we're dealing with the same measurement system
            if (IsMetricUnitSystem(ingredientToConvert.Measurement) != IsMetricUnitSystem(unitToConvertTo))
                ConvertToSameUnitSystem(ref ingredientToConvert);
               

            //Volume Units belong to the same measurement system now, continue converting to the desired unit
            float convertedAmount = ingredientToConvert.Amount;

            if ((int) ingredientToConvert.Measurement > (int) unitToConvertTo)
            {
                //Converting from bigger to smaller unit
                for (int i = (int) ingredientToConvert.Measurement -1; i >= (int)unitToConvertTo; i--)
                    convertedAmount /= conversionFactors[i];
            }
            else
            {
                //Converting from smaller to Bigger
                for (int i = (int)ingredientToConvert.Measurement; i < (int)unitToConvertTo; i++)
                    convertedAmount *= conversionFactors[i];
            }

            return new Ingredient(convertedAmount, unitToConvertTo);
        }

        private static bool IsMetricUnitSystem(MeasurementUnit unitToCheck)
        {
            //Check to see if the unit is between the values of Milliter and Milligram for Metric Volume units
            if ((int)unitToCheck < (int)MeasurementUnit.MilliLiter == false)
                    return ((int)unitToCheck < (int)MeasurementUnit.Milligram);
            return false; //US volume unit
        }

        private static void ConvertToSameUnitSystem(ref Ingredient ingredientToConvert)
        {
            //grab a reference of the amount that needs to be converted
            float amount = ingredientToConvert.Amount;

            bool startingWithMetric = IsMetricUnitSystem(ingredientToConvert.Measurement);
            MeasurementUnit unitToStandarizeWith = (startingWithMetric) 
                ? MeasurementUnit.MilliLiter 
                : MeasurementUnit.FluidOunce;

            //If the ingredient is not MilliLiter or Fluid Ounce (respective to the value of startingWithMetric)
            //Convert down/up to the respective unit
            if (ingredientToConvert.Measurement != unitToStandarizeWith)
                ingredientToConvert = Convert(ingredientToConvert, unitToStandarizeWith);

            //Metric to US
            if (startingWithMetric)
                ingredientToConvert = new Ingredient(
                    ingredientToConvert.Amount * MeasurementConversionFactors.GetMilliliterToFluidOunceRatio(), 
                    MeasurementUnit.FluidOunce);
            //US to Metric
            else
                ingredientToConvert = new Ingredient(
                    ingredientToConvert.Amount / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio(), 
                    MeasurementUnit.MilliLiter);
        }
    }
}
