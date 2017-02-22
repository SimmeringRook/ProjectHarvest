using Core.MeasurementConversions;
using System;

namespace Core
{
    public partial class Inventory
    {
        public Inventory(double convertedAmount, MeasurementUnit unitToConvertTo)
        {
            this.Amount = convertedAmount;
            this.Measurement = unitToConvertTo.ToString();
        }
        public MeasurementUnit GetMeasurementUnit()
        {
            return (MeasurementUnit) Enum.Parse(typeof(MeasurementUnit), this.Measurement, true);
        }

    }
}
