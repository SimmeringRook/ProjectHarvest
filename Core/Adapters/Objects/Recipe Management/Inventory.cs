using Core.Utilities.UnitConversions;
using System.ComponentModel;

namespace Core.Adapters.Objects
{
    public class Inventory : INotifyPropertyChanged
    {
        #region Properties
        private int _id;
        public int ID
        {
            get
            { return _id; }
            set
            { _id = value; OnPropertyChanged("ID"); }
        }

        private string _name;
        public string Name
        {
            get
            { return _name; }
            set
            { _name = value; OnPropertyChanged("Name"); }
        }

        private string _category;
        public string Category
        {
            get
            { return _category; }
            set
            { _category = value; OnPropertyChanged("Category"); }
        }

        private double _amount;
        public double Amount
        {
            get
            { return _amount; }
            set
            { _amount = value; OnPropertyChanged("Amount"); }
        }

        private MeasurementUnit _measurement;
        public MeasurementUnit Measurement
        {
            get
            { return _measurement; }
            set
            { _measurement = value; OnPropertyChanged("Measurement"); }
        }
        #endregion

        public Inventory()
        {
            _id = 0;
            _name = "Empty";
            _category = "Error";
            _amount = 0.0;
            _measurement = MeasurementUnit.Cup;
        }

        internal Inventory(int id, string name, string category, double amount, string unit)
        {
            _id = id;
            _name = string.Copy(name);
            _category = string.Copy(category);
            _amount = amount;
            _measurement = (MeasurementUnit)System.Enum.Parse(typeof(MeasurementUnit), unit);
        }

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Inventory comparison = obj as Inventory;
            return (this.ID.Equals(comparison.ID));
        }

        public override int GetHashCode()
        {
            return Utilities.General.HashGenerator.Hash(this.ID, this.Name, this.Category);
        }
    }
}
