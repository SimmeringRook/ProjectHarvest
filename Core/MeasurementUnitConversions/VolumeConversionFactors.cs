using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MeasurementUnitConversions
{
    public static class VolumeConversionFactors
    {
        //Going from Smaller unit to bigger unit
        public const float TeaSpoonToTableSpoonRatio = (1.0f / 3.0f); //3 tsp = 1 tbs
        public const float TableSpoonToFluidOunceRatio = (1.0f / 2.0f); //2 tbs = 1 fl oz
        public const float FluidOunceToCupRatio = (1.0f / 8.11537f); // 8.11537 fl oz = 1 cup
        public const float CupToPintRatio = (1.0f / 1.97157f); // 1.97157 cups = 1 pint
        public const float PintToQuartRatio = (1.0f / 2.0f); // 2 pints = 1 quart
        public const float QuartToGallonRatio = (1.0f / 4.0f); //4 quarts = 1 gallon

        //Going from Bigger Unit to Smaller unit
        public const float TableSpoonToTeaSpoonRatio = 3.0f; // 1 tbs = 3 tsp
    }
}
