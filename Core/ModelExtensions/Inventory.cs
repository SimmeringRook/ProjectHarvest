using Core.DatabaseUtilities;
using Core.DatabaseUtilities.Queries;
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

        public string FoodCategory { get; set; }

        public void PopulateGUIProperties()
        {
            using (HarvestUtility harvest = new HarvestUtility(new IngredientCategoryQuery()))
            {
                this.FoodCategory = (harvest.Get(this.InventoryID) as IngredientCategory).Category;

                harvest.HarvestQuery = new MetricQuery();
                this.Measurement = (harvest.Get(this.InventoryID) as Metric).Measurement;
            }
        }
    }
}
