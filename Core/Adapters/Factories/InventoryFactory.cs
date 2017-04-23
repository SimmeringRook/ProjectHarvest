using Core.Utilities.Queries;

namespace Core.Adapters.Factories
{
    internal static class InventoryFactory
    {
        #region Form Object
        /// <summary>
        /// This creates a Inventory object for Client_Desktop from a record in the Inventory Table.
        /// This will return an empty Inventory object (0 for numeric fields, "Error" for strings) if
        /// the record could not be found.
        /// </summary>
        internal static Objects.Inventory Create_Client_From_Database(int id)
        {
            if(id == 0)
                return Create_Client_From_Database(null);
            
            using(HarvestEntitiesUtility harvestDatabase = new HarvestEntitiesUtility(new InventoryQuery()))
            {
                Database.Inventory dbInventory = harvestDatabase.Get(id) as Database.Inventory;
                return Create_Client_From_Database(dbInventory);
            }
        }

        /// <summary>
        /// This creates a Inventory object for Client_Desktop from a record in the Inventory Table.
        /// This will return an empty Inventory object (0 for numeric fields, "Error" for strings) if
        /// the record could not be found.
        /// </summary>
        internal static Objects.Inventory Create_Client_From_Database(Database.Inventory databaseInventory)
        {
            if (databaseInventory != null)
                return new Objects.Inventory(databaseInventory.InventoryID, databaseInventory.IngredientName,
                    databaseInventory.Category, databaseInventory.Amount, databaseInventory.Measurement);
            else
                return new Objects.Inventory();
        }
        #endregion

        #region Database Object
        /// <summary>
        /// This takes a Client_Desktop Inventory object and transfers its data over to an Inventory database Object.
        /// </summary>
        /// <param name="clientInventory"></param>
        /// <returns></returns>
        internal static Database.Inventory Create_Database_From_Client(Objects.Inventory clientInventory)
        {
            Database.Inventory databaseInventory = new Database.Inventory();

            databaseInventory.InventoryID = clientInventory.ID;
            databaseInventory.IngredientName = clientInventory.Name;
            databaseInventory.Amount = clientInventory.Amount;
            databaseInventory.Category = clientInventory.Category;
            databaseInventory.Measurement = clientInventory.Measurement.ToString();

            return databaseInventory;
        }
        #endregion
    }
}
