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

                string metricID = items[itemID].Measurement;
                string name = "Error";

                foreach (Metric metric in metrics)
                    if (metric.Measurement == metricID)
                        name = metric.Measurement;
                return name;
            }
        }

        public static int GetMeasurementIndexByItemMetricName(string itemMetricName)
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
                    if (metric.Measurement == itemMetricName)
                        index = metrics.IndexOf(metric);
                }

                return index;
            }
        }
        #endregion

        #region  Food Category Helper Functions
        public static string GetFoodCategoryByRowPostion(int rowIndex)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                //Load the tables
                context.IngredientCategory.Load();
                context.Inventory.Load();

                //Build the lists
                List<Inventory> items = context.Inventory.ToList();
                List<IngredientCategory> foodTypes = context.IngredientCategory.ToList();

                string foodID = items[rowIndex].Category;
                string name = "Error";

                foreach (IngredientCategory type in foodTypes)
                    if (type.Category == foodID)
                        name = type.Category;
                return name;
            }
        }

        /**
         * Is this needed anymore!!
         */

        //public static int GetFoodCategoryIndexByItemFoodTypeID(int itemFoodTypeID)
        //{
        //    using (HarvestEntities context = new HarvestEntities())
        //    {
        //        //Load the tables
        //        context.IngredientCategory.Load();

        //        //Build the list
        //        List<IngredientCategory> foods = context.IngredientCategory.ToList();

        //        //Get the index of the FoodType
        //        int index = -1;
        //        foreach (IngredientCategory food in foods)
        //        {
        //            if (food.ID == itemFoodTypeID)
        //                index = foods.IndexOf(food);
        //        }

        //        return index;
        //    }
        //}
        #endregion

        public static void UpdateItemInDatabaseByItem(Inventory modifiedItem)
        {
            using (HarvestEntities context = new HarvestEntities())
            {
                //Load the table, and get the Item to modify
                context.Inventory.Load();
                
                Inventory itemInDB = context.Inventory.SingleOrDefault(i => i.InventoryID == modifiedItem.InventoryID);

                if (itemInDB != null)
                {
                    //Assign the new values
                    itemInDB.IngredientName = modifiedItem.IngredientName;
                    itemInDB.Amount = modifiedItem.Amount;
                    itemInDB.Measurement = modifiedItem.Measurement;
                    itemInDB.Category = modifiedItem.Category;
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
                        if (item.InventoryID == dbItem.InventoryID)
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
