using System.Collections.Generic;

namespace Core.Utilities.UnitConversions
{
    /// <summary>
    /// This class stores all conversion factors for converting one unit to another.
    /// </summary>
    public static class MeasurementConversionFactors
    {
        /// <summary>
        /// Returns the ratio of 1 milliliter to fluid ounces.
        /// </summary>
        public static float GetMilliliterToFluidOunceRatio()
        {
            return 0.033814f;
        }

        /// <summary>
        /// Returns the ratio of 1 gram to ounces. (Weight)
        /// </summary>
        public static float GetGramToOunceRatio()
        {
            return 0.035274f;
        }

        public static List<float> GetRatios()
        {
            return ConversionFactors;
        }

        private static List<float> ConversionFactors = new List<float>()
        {
            TeaSpoonToTableSpoonRatio,
            TableSpoonToFluidOunceRatio,
            FluidOunceToCupRatio,
            CupToPintRatio,
            PintToQuartRatio,
            QuartToGallonRatio,
            MillilitersToLiters,
            MilligramsToGrams,
            OunceToLbs,
            GramsToKiloGrams
        };

        #region US Volume Ratios
        public const float TeaSpoonToTableSpoonRatio = (1.0f / 3.0f); //3 tsp = 1 tbs
        public const float TableSpoonToFluidOunceRatio = (1.0f / 2.0f); //2 tbs = 1 fl oz
        public const float FluidOunceToCupRatio = (1.0f / 8.0f); // 8.11537 fl oz = 1 cup
        public const float CupToPintRatio = (1.0f / 2.0f); // 1.97157 cups = 1 pint
        public const float PintToQuartRatio = (1.0f / 2.0f); // 2 pints = 1 quart
        public const float QuartToGallonRatio = (1.0f / 4.0f); //4 quarts = 1 gallon
        #endregion

        #region Metric Volume Ratios
        public const float MillilitersToLiters = (1.0f / 1000f); //1000 mL = 1 L
        #endregion

        #region US Weight Ratios
        public const float OunceToLbs = (1.0f / 16.0f); // 16 oz = 1lbs
        #endregion

        #region Metric Weight Ratios
        public const float MilligramsToGrams = (1.0f / 1000f); // 1000 mg = 1 g
        public const float GramsToKiloGrams = (1.0f / 1000f); // 1000 g = 1 kg
        #endregion
    }
}
