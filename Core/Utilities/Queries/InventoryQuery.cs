using Core.Adapters.Database;
using Core.Adapters.Factories;
using Core.Cache;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Utilities.Queries
{
    internal class InventoryQuery : IHarvestQuery
    {
        public InventoryCache<Adapters.Objects.Inventory> Cache = null;
        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();

            if ((int)itemID > 0)
            {
                int id = (int)itemID;
                Adapters.Database.Inventory dbItem = HarvestDatabase.Inventory.SingleOrDefault(item => item.InventoryID == id);
                return dbItem;
            }
            else
            {
                InventoryCache<Adapters.Objects.Inventory> inventoryItems = new InventoryCache<Adapters.Objects.Inventory>();

                foreach (Inventory dbInventory in HarvestDatabase.Inventory.ToList())
                    inventoryItems.Add(InventoryFactory.Create_Client_From_Database(dbInventory));

                inventoryItems.RaiseListChangedEvents = true;
                return inventoryItems;
            }

        }

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            HarvestDatabase.RecipeIngredient.Load();

            Adapters.Objects.Inventory clientInventory = itemToRemove as Adapters.Objects.Inventory;

            //Remove all Recipe Ingredients that use this InventoryItem
            List<RecipeIngredient> allRecipeIngredientsThatUseItem = HarvestDatabase.RecipeIngredient.Where(ri => ri.InventoryID == clientInventory.ID).ToList();
            foreach (RecipeIngredient recipeIngredient in allRecipeIngredientsThatUseItem)
                HarvestDatabase.RecipeIngredient.Remove(recipeIngredient);

            //Remove this InventoryItem
            Inventory dbInventory = HarvestDatabase.Inventory.Single(inv => inv.InventoryID == clientInventory.ID);
            HarvestDatabase.Inventory.Remove(dbInventory);

            HarvestDatabase.SaveChanges();

            clientInventory = null;
            dbInventory = null;
            itemToRemove = null;
            allRecipeIngredientsThatUseItem = null;
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            if (Cache != null)
                Cache.RaiseListChangedEvents = false;
            HarvestDatabase.Inventory.Load();

            Adapters.Objects.Inventory clientInventory = itemToChange as Adapters.Objects.Inventory;
            Inventory dbInventoryItem = InventoryFactory.Create_Database_From_Client(clientInventory);

            HarvestDatabase.Inventory.AddOrUpdate(dbInventoryItem);

            HarvestDatabase.SaveChanges();

            if (Cache != null)
                Cache.RaiseListChangedEvents = true;
        }

        public void Insert(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            if (Cache != null)
                Cache.RaiseListChangedEvents = false;

            HarvestDatabase.Inventory.Load();

            Adapters.Objects.Inventory clientInventory = itemToChange as Adapters.Objects.Inventory;
            clientInventory.ID = GetNextID(HarvestDatabase);
            Inventory dbInventoryItem = InventoryFactory.Create_Database_From_Client(clientInventory);

            HarvestDatabase.Inventory.AddOrUpdate(dbInventoryItem);

            HarvestDatabase.SaveChanges();

            //clientInventory = null;
            dbInventoryItem = null;

            if (Cache != null)
                Cache.RaiseListChangedEvents = true;
        }

        private int GetNextID(HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Inventory.Load();
            if (HarvestDatabase.Inventory.Count() == 0)
                return 1;
            var lastRecipe = HarvestDatabase.Inventory.OrderByDescending(r => r.InventoryID).First();
            return lastRecipe.InventoryID + 1;
        }
    }
}
