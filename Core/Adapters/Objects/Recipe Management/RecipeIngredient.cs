using Core.Utilities.UnitConversions;

namespace Core.Adapters.Objects
{
    public class RecipeIngredient
    {
        private int _id;
        public int RecipeID { get { return _id; } set { _id = value; _dirty = true; } }

        private Inventory _inventory;
        public Inventory Inventory { get { return _inventory; } set { _inventory = value; _dirty = true; } }

        private double _amount;
        public double Amount { get { return _amount; } set { _amount = value; _dirty = true; } }

        private MeasurementUnit _measurement;
        public MeasurementUnit Measurement { get { return _measurement; } set { _measurement = value; _dirty = true; } }

        private bool _dirty;
        public bool IsDirty { get { return _dirty; } }

        public RecipeIngredient()
        {
            _dirty = false;
            _id = 0;
            _inventory = Factories.InventoryFactory.Create_Client_From_Database(0);
            _amount = 0.0;
            _measurement = MeasurementUnit.Cup;
        }

        internal RecipeIngredient(int id, Inventory inventory, double amount, string unit)
        {
            _dirty = false;
            _id = id;
            _inventory = inventory;
            _amount = amount;
            _measurement = (MeasurementUnit)System.Enum.Parse(typeof(MeasurementUnit), unit);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            RecipeIngredient comparison = obj as RecipeIngredient;
            bool sameRecipe = this.RecipeID.Equals(comparison.RecipeID);
            bool sameInventory = this.Inventory.ID.Equals(comparison.Inventory.ID);
            return (sameRecipe && sameInventory);
        }

        public override int GetHashCode()
        {
            return Utilities.General.HashGenerator.Hash(this.RecipeID, this.Inventory.GetHashCode(), this.Amount, this.Measurement);
        }

        /// <summary>
        /// Sets the IsDirty property to return true until the object has been re-synchronized with the database.
        /// </summary>
        internal void SetDirtyFlag()
        {
            _dirty = true;
        }
    }
}
