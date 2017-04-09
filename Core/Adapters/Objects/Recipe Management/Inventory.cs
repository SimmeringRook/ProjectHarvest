using Core.Utilities.UnitConversions;

namespace Core.Adapters.Objects
{
    public class Inventory
    {
        private int _id;
        public int ID
        {
            get
            { return _id; }
            set
            { _id = value; _dirty = true; }
        }

        private string _name;
        public string Name
        {
            get
            { return _name; }
            set
            { _name = value; _dirty = true; }
        }

        private string _category;
        public string Category
        {
            get
            { return _category; }
            set
            { _category = value; _dirty = true; }
        }

        private double _amount;
        public double Amount
        {
            get
            { return _amount; }
            set
            { _amount = value; _dirty = true; }
        }

        private MeasurementUnit _measurement;
        public MeasurementUnit Measurement
        {
            get
            { return _measurement; }
            set
            { _measurement = value; _dirty = true; }
        }

        private bool _dirty;
        public bool IsDirty { get { return _dirty; } }

        public Inventory()
        {
            _dirty = false;
        }


        internal Inventory(int id, string name, string category, double amount, string unit)
        {
            _id = id;
            _name = string.Copy(name);
            _category = string.Copy(category);
            _amount = amount;
            _measurement = (MeasurementUnit)System.Enum.Parse(typeof(MeasurementUnit), unit);
            _dirty = false;
        }

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

        internal void ResetDirtyFlag()
        {
            _dirty = false;
        }
    }
}
