using Core.RecipeMangement;
using System.Collections.Generic;

namespace Core.MeasurementConversions
{
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
            if (IsVolumeMeasurement(unitToConvertTo))
            {
                List<float> conversionFactors = MeasurementConversionFactors.GetSameSystemRatios();
                float convertedAmount = ingredientToConvert.Amount;

                //Ensure we're dealing with the same measurement system
                bool startingUnitIsMetric = IsMetricUnitSystem(ingredientToConvert.Measurement);
                bool endUnitIsMetric = IsMetricUnitSystem(unitToConvertTo);

                if (startingUnitIsMetric != endUnitIsMetric)
                    ingredientToConvert = ConvertToSameUnitSystem(ingredientToConvert, startingUnitIsMetric, endUnitIsMetric);
                
                //A weird error occured while trying to convert from US to Metric (or vice versa)
                //Exit Early
                if (ingredientToConvert == null)
                    return null;

                //Volume Units belong to the same measurement system now, continue converting to the desired unit
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
            return null;
        }

        private static bool IsMetricUnitSystem(MeasurementUnit unitToCheck)
        {
            if ((int)unitToCheck < (int)MeasurementUnit.MilliLiter == false)
                    return ((int)unitToCheck < (int)MeasurementUnit.Milligram);
            return false;
        }

        private static Ingredient ConvertToSameUnitSystem(Ingredient ingredientToConvert, bool startingUnitIsMetric, bool endingUnitIsMetric)
        {
            float amount = 0.0f;
            
            if (startingUnitIsMetric == true && endingUnitIsMetric == false)
            {
                if (ingredientToConvert.Measurement != MeasurementUnit.MilliLiter)
                    amount = Convert(ingredientToConvert, MeasurementUnit.MilliLiter).Amount;
                amount *= MeasurementConversionFactors.GetMilliliterToFluidOunceRatio();
                return new Ingredient(amount, MeasurementUnit.FluidOunce);
            }
            else if (startingUnitIsMetric == false && endingUnitIsMetric == true)
            {
                if (ingredientToConvert.Measurement != MeasurementUnit.FluidOunce)
                    amount = Convert(ingredientToConvert, MeasurementUnit.FluidOunce).Amount;
                amount /= MeasurementConversionFactors.GetMilliliterToFluidOunceRatio();
                return new Ingredient(amount, MeasurementUnit.MilliLiter);
            }
            return null;
        }
    }
}
