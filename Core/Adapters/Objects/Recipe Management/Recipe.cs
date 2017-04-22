using Core.Cache;
using System.ComponentModel;

namespace Core.Adapters.Objects
{
    public class Recipe : INotifyPropertyChanged
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

        private double _servings;
        public double Servings
        {
            get
            { return _servings; }
            set
            { _servings = value; OnPropertyChanged("Servings"); }
        }

        private string _category;
        public string Category
        {
            get
            { return _category; }
            set
            { _category = value; OnPropertyChanged("Category"); }
        }
        public Cache<RecipeIngredient> AssociatedIngredients { get; set; }
        #endregion

        public Recipe()
        {
            _id = 0;
            _name = "Empty";
            _servings = 0.0;
            _category = "Error";
            AssociatedIngredients = new Cache<RecipeIngredient>();
            AssociatedIngredients.RaiseListChangedEvents = true;
        }

        internal Recipe(int id, string name, double servings, string category)
        {
            _id = id;
            _name = string.Copy(name);
            _servings = servings;
            _category = string.Copy(category);
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
            Recipe comparison = obj as Recipe;
            return (this.ID.Equals(comparison.ID));
        }

        public override int GetHashCode()
        {
            return Utilities.General.HashGenerator.Hash(this.ID, this.Name, this.Servings, this.Category);
        }
    }
}
