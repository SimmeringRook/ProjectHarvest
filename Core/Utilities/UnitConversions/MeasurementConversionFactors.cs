using System.Collections.Generic;

namespace Core.Utilities.UnitConversions
{
    /// <summary>
    /// This class stores all conversion factors for converting one unit to another.
    /// </summary>
    internal static class MeasurementConversionFactors
    {
        /// <summary>
        /// Returns the ratio of 1 milliliter to fluid ounces.
        /// </summary>
        internal static float GetMilliliterToFluidOunceRatio()
        {
            return 0.033814f;
        }

        /// <summary>
        /// Returns the ratio of 1 gram to ounces. (Weight)
        /// </summary>
        internal static float GetGramToOunceRatio()
        {
            return 0.035274f;
        }

        internal static List<float> ConversionFactors { get { return _conversionFactors; } }

        private static List<float> _conversionFactors = new List<float>()
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
        internal const float TeaSpoonToTableSpoonRatio = (1.0f / 3.0f); //3 tsp = 1 tbs
        internal const float TableSpoonToFluidOunceRatio = (1.0f / 2.0f); //2 tbs = 1 fl oz
        internal const float FluidOunceToCupRatio = (1.0f / 8.0f); // 8.11537 fl oz = 1 cup
        internal const float CupToPintRatio = (1.0f / 2.0f); // 1.97157 cups = 1 pint
        internal const float PintToQuartRatio = (1.0f / 2.0f); // 2 pints = 1 quart
        internal const float QuartToGallonRatio = (1.0f / 4.0f); //4 quarts = 1 gallon
        #endregion

        #region Metric Volume Ratios
        internal const float MillilitersToLiters = (1.0f / 1000f); //1000 mL = 1 L
        #endregion

        #region US Weight Ratios
        internal const float OunceToLbs = (1.0f / 16.0f); // 16 oz = 1lbs
        #endregion

        #region Metric Weight Ratios
        internal const float MilligramsToGrams = (1.0f / 1000f); // 1000 mg = 1 g
        internal const float GramsToKiloGrams = (1.0f / 1000f); // 1000 g = 1 kg
        #endregion
    }
}
