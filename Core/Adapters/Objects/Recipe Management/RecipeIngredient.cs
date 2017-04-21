using Core.Utilities.UnitConversions;
using System.ComponentModel;

namespace Core.Adapters.Objects
{
    public class RecipeIngredient : INotifyPropertyChanged
    {
        #region Properties
        private int _id;
        public int RecipeID {
            get { return _id; }
            set { _id = value; OnPropertyChanged("RecipeID"); }
        }

        private Inventory _inventory;
        public Inventory Inventory {
            get { return _inventory; }
            set { _inventory = value; OnPropertyChanged("Inventory"); }
        }

        private double _amount;
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged("Amount"); }
        }

        private MeasurementUnit _measurement;
        public MeasurementUnit Measurement
        {
            get { return _measurement; }
            set { _measurement = value; OnPropertyChanged("Measurement"); }
        }
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public RecipeIngredient()
        {
            _id = 0;
            _inventory = Factories.InventoryFactory.Create_Client_From_Database(0);
            _amount = 0.0;
            _measurement = MeasurementUnit.Cup;
        }

        internal RecipeIngredient(int id, Inventory inventory, double amount, string unit)
        {
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
    }
}
