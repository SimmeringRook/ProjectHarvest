using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.EntityFramework_Utils
{
    public static class InventoryTranslator
    {
        #region Measurement Helper Functions
        public static string GetMeasurementNameByItemID(int itemID)
        {
            //Connect
            using (HarvestEntities context = new HarvestEntities())
            {
                //Load the tables
                context.Metric.Load();
                context.Inventory.Load();

                //Build the lists
                List<Inventory> items = context.Inventory.ToList();
                List<Metric> metrics = context.Metric.ToList();

                int? metricID = items[itemID].MetricID;
                string name = "Error";

                foreach (Metric metric in metrics)
                    if (metric.ID == metricID.Value)
                        name = metric.Name;
                return name;
            }
        }

        public static int GetMeasurementIndexByItemMetricID(int itemMetricID)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                //Load the tables
                context.Metric.Load();

                //Build the list
                List<Metric> metrics = context.Metric.ToList();

                //Get the index of the Metric
                int index = -1;
                foreach (Metric metric in metrics)
                {
                    if (metric.ID == itemMetricID)
                        index = metrics.IndexOf(metric);
                }

                return index;
            }
        }
        #endregion

        #region  Food Category Helper Functions
        public static string GetFoodCategoryByItemID(int itemID)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                //Load the tables
                context.FoodType.Load();
                context.Inventory.Load();

                //Build the lists
                List<Inventory> items = context.Inventory.ToList();
                List<FoodType> foodTypes = context.FoodType.ToList();

                int foodID = items[itemID].TypeID.Value;
                string name = "Error";

                foreach (FoodType food in foodTypes)
                    if (food.ID == foodID)
                        name = food.Name;
                return name;
            }
        }

        public static int GetFoodCategoryIndexByItemFoodTypeID(int itemFoodTypeID)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                //Load the tables
                context.FoodType.Load();

                //Build the list
                List<FoodType> foods = context.FoodType.ToList();

                //Get the index of the FoodType
                int index = -1;
                foreach (FoodType food in foods)
                {
                    if (food.ID == itemFoodTypeID)
                        index = foods.IndexOf(food);
                }

                return index;
            }
        }
        #endregion

        public static void UpdateItemInDatabaseByItem(Inventory modifiedItem)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                //Load the table, and get the Item to modify
                context.Inventory.Load();
                
                Inventory itemInDB = context.Inventory.SingleOrDefault(i => i.ID == modifiedItem.ID);

                if (itemInDB != null)
                {
                    //Assign the new values
                    itemInDB.Name = modifiedItem.Name;
                    itemInDB.Amount = modifiedItem.Amount;
                    itemInDB.MetricID = modifiedItem.MetricID;
                    itemInDB.TypeID = modifiedItem.TypeID;
                }
                else
                {
                    context.Inventory.Add(modifiedItem);
                }
                //commit changes to DB
                context.SaveChanges();
            }
        }

        public static void RemoveItemsFromDatabase(ref List<Inventory> itemsToRemove)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                context.Inventory.Load();
                foreach (Inventory item in itemsToRemove)
                {
                    //TODO: Check if the item is tied to a recipe object
                    foreach (Inventory dbItem in context.Inventory.Local.ToList())
                        if (item.ID == dbItem.ID)
                            context.Inventory.Remove(dbItem); //delete item
                }
                context.SaveChanges();

                //If the item no longer exists in the database, remove it from the list
                //the only items remaining will be the one prevented from being removed.
                foreach (Inventory databaseItem in context.Inventory.ToList())
                {
                    if (itemsToRemove.Contains(databaseItem) == false)
                        itemsToRemove.Remove(databaseItem);
                }
            }
        }

    }
}
