using Core.DatabaseUtilities.Queries;

namespace Core
{
    public partial class Inventory
    {
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
