using Core.Utilities.Database.Queries.Tables;
using Core.Utilities.UnitConversions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Objects.Inventory clientInventory = new Objects.Inventory();

            //If ID is already 0, the Recipe Ingredient associated with this Inventory could not be found
            //So instead of hitting the database, just create and return an empty object
            if(id == 0)
                return Create_Client_From_Database(null);
            
            using(HarvestTableUtility harvestDatabase = new HarvestTableUtility(new InventoryQuery()))
            {
                //Get the record from the database
                var dbInventory = (harvestDatabase.Get(id) as List<Database.Inventory>).Single(item => item.InventoryID == id);
                //Build the client object from the record
                clientInventory = Create_Client_From_Database(dbInventory);
            }

            return clientInventory;
        }

        /// <summary>
        /// This creates a Inventory object for Client_Desktop from a record in the Inventory Table.
        /// This will return an empty Inventory object (0 for numeric fields, "Error" for strings) if
        /// the record could not be found.
        /// </summary>
        internal static Objects.Inventory Create_Client_From_Database(Database.Inventory databaseInventory)
        {
            Objects.Inventory clientInventory = null;

            if (databaseInventory != null)
            {
                //Populate the Client_Desktop Inventory object
                clientInventory = new Objects.Inventory(
                    databaseInventory.InventoryID, 
                    databaseInventory.IngredientName,
                    databaseInventory.Category, 
                    databaseInventory.Amount, 
                    databaseInventory.Measurement);
            }
            else
            {
                //If the record could not be found
                //return an empty object
                clientInventory = new Objects.Inventory(0, "Error", "Error", 0.0, "Gallon");
            }

            return clientInventory;
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
