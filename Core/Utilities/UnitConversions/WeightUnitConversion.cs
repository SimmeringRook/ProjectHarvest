using System.Collections.Generic;
using System.Linq;

namespace Core.Utilities.UnitConversions
{
    public class WeightUnitConversion : IUnitConvertable
    {
        private static List<MeasurementUnit> _units = new List<MeasurementUnit>()
        {
            MeasurementUnit.Ounce,
            MeasurementUnit.Pound,
            MeasurementUnit.Milligram,
            MeasurementUnit.Gram,
            MeasurementUnit.Kilogram
        };

        public bool IsCorrectMeasurementType(MeasurementUnit measurement)
        {
            return _units.Any(unit => unit == measurement);
        }
    }
}
