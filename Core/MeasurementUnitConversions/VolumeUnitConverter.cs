using Core.RecipeMangement;
using System.Collections.Generic;

namespace Core.MeasurementUnitConversions
{
    public static class VolumeUnitConverter
    {
        /* This lets us have one struct object for Ingredients,
         * If the unit of measurement is for volume, then we can allow the program 
         * to proceed Converting from one unit to another.
         * Otherwise, Convert should return false/an error that a weight unit was trying
         * to be converted to a volume unit (or vice versa).
         */

        public static List<MeasurementUnit> volumeUnits = new List<MeasurementUnit>()
        {
            MeasurementUnit.TeaSpoon,
            MeasurementUnit.TableSpoon,
            MeasurementUnit.FluidOunce,
            MeasurementUnit.Cup,
            MeasurementUnit.Pint,
            MeasurementUnit.Quart,
            MeasurementUnit.Gallon
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

        //Temporary?
        //Is there a better way to do this?
        private static List<float> conversionFactors = new List<float>()
        {
            VolumeConversionFactors.TeaSpoonToTableSpoonRatio,
            VolumeConversionFactors.TableSpoonToFluidOunceRatio,
            VolumeConversionFactors.FluidOunceToCupRatio,
            VolumeConversionFactors.CupToPintRatio,
            VolumeConversionFactors.PintToQuartRatio,
            VolumeConversionFactors.QuartToGallonRatio
        };

        public static Ingredient Convert(Ingredient ingredientToConvert, MeasurementUnit unitToConvertTo)
        {
            if (IsVolumeMeasurement(unitToConvertTo))
            {
                float convertedAmount = ingredientToConvert.Amount;
                if ((int) ingredientToConvert.Measurement > (int) unitToConvertTo)
                {
                    //Converting from bigger to smaller unit
                    for (int i = (int) ingredientToConvert.Measurement -1; i >= (int)unitToConvertTo; i--)
                    {
                        convertedAmount /= conversionFactors[i];
                    }
                }
                else
                {
                    //Converting from smaller to Bigger
                    for (int i = (int)ingredientToConvert.Measurement; i < (int)unitToConvertTo; i++)
                    {
                        convertedAmount *= conversionFactors[i];
                    }
                }
                return new Ingredient(convertedAmount, unitToConvertTo);
            }
            return null;
        }

    }
}
