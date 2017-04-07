namespace Core.Utilities.General
{
    public static class HarvestEntityFactory
    {
        public static Inventory CreateInventory(string name, float amount, string measurement, string category, int id = 0)
        {
            Inventory itemToCreate = new Inventory();
            itemToCreate.InventoryID = id;
            itemToCreate.IngredientName = name;
            itemToCreate.Amount = amount;
            itemToCreate.Measurement = measurement;
            itemToCreate.Category = category;
            return itemToCreate;
        }
    }
}
