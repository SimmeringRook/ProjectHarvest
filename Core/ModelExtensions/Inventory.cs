using Core.Utilities.Database.Queries.Tables;
using System;

namespace Core
{
    public partial class Inventory : ICloneable
    {
        public string FoodCategory { get; set; }

        public void PopulateGUIProperties()
        {
            using (HarvestTableUtility harvest = new HarvestTableUtility(new IngredientCategoryQuery()))
            {
                //this.FoodCategory = (harvest.Get(this.InventoryID) as IngredientCategory).Category;

                harvest.HarvestQuery = new MetricQuery();
                this.Measurement = (harvest.Get(this.InventoryID) as Metric).Measurement;
            }
        }

        public object Clone()
        {
            Inventory deepClone = (Inventory)this.MemberwiseClone();
            deepClone.Amount = this.Amount;
            deepClone.Category = string.Copy(this.Category);
            deepClone.Measurement = string.Copy(this.Measurement);

            return deepClone; 
        }
    }
}
