using System.Collections.Generic;

namespace Core.Adapters.Objects
{
    public class Recipe
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

        private double _servings;
        public double Servings
        {
            get
            { return _servings; }
            set
            { _servings = value; _dirty = true; }
        }

        private string _category;
        public string Category
        {
            get
            { return _category; }
            set
            { _category = value; _dirty = true; }
        }

        private bool _dirty;
        internal bool IsDirty { get { return _dirty; } }

        public List<RecipeIngredient> AssociatedIngredients { get; set; }

        public Recipe()
        {
            _dirty = false;
            _id = 0;
            _name = "Empty";
            _servings = 0.0;
            _category = "Error";
            AssociatedIngredients = new List<Objects.RecipeIngredient>();
        }

        internal Recipe(int id, string name, double servings, string category)
        {
            _id = id;
            _name = string.Copy(name);
            _servings = servings;
            _category = string.Copy(category);
            _dirty = false;
        }

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

        [System.Obsolete] //?
        internal void ResetDirtyFlag()
        {
            _dirty = false;
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
