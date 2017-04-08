using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Adapters.Objects
{
    public class PlannedMeal
    {
        private Recipe _plannedRecipe;
        public Recipe PlannedRecipe
        {
            get
            { return _plannedRecipe; }
            set
            { _plannedRecipe = value; _dirty = true; }
        }

        private string _mealTime;
        public string MealTime
        {
            get
            { return _mealTime; }
            set
            { _mealTime = value; _dirty = true; }
        }

        private DateTime _date;
        public DateTime Date
        {
            get
            { return _date; }
            set
            { _date = value; _dirty = true; }
        }

        private bool _hasBeenEaten;
        public bool HasBeenEaten
        {
            get
            { return _hasBeenEaten; }
            set
            { _hasBeenEaten = value; _dirty = true; }
        }

        private bool _dirty;
        public bool IsDirty { get { return _dirty; } }

        public PlannedMeal()
        {
            _dirty = false;
            _date = DateTime.Today;
            _mealTime = "Error";
            _plannedRecipe = Factories.RecipeFactory.Create_Client_From_Database(0);
            _hasBeenEaten = false;
        }

        internal PlannedMeal(Recipe recipe, string mealTime, DateTime date, bool hasBeenEaten)
        {
            _dirty = false;
            _plannedRecipe = recipe;
            _mealTime = string.Copy(mealTime);
            _date = date.Date;
            _hasBeenEaten = hasBeenEaten;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            PlannedMeal comparison = obj as PlannedMeal;
            bool sameRecipe = this.PlannedRecipe.Equals(comparison.PlannedRecipe);
            bool sameDay = this.Date.Date.Equals(comparison.Date.Date);
            bool sameTime = this.MealTime.Equals(comparison.MealTime);
            return (sameRecipe && sameDay && sameTime);
        }

        public override int GetHashCode()
        {
            return Utilities.General.HashGenerator.Hash(this.Date.Date, this.MealTime, this.HasBeenEaten, this.PlannedRecipe.ID);
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
