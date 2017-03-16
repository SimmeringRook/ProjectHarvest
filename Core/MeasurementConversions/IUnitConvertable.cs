namespace Core.MeasurementConversions
{
    public interface IUnitConvertable
    {
        bool IsCorrectMeasurementType(MeasurementUnit measurement);
    }
}
