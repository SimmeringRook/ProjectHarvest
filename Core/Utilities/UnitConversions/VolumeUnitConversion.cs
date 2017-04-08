using System.Collections.Generic;
using System.Linq;

namespace Core.Utilities.UnitConversions
{
    public class VolumeUnitConversion : IUnitConvertable
    {
        private static List<MeasurementUnit> _units = new List<MeasurementUnit>()
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

        public bool IsCorrectMeasurementType(MeasurementUnit measurement)
        {
            return _units.Any(unit => unit == measurement);
        }
    }
}
