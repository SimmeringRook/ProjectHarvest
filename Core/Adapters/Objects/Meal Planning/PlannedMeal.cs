using System;
using System.ComponentModel;

namespace Core.Adapters.Objects
{
    public class PlannedMeal : INotifyPropertyChanged
    {
        #region Properties
        private Recipe _plannedRecipe;
        public Recipe PlannedRecipe
        {
            get
            { return _plannedRecipe; }
            set
            { _plannedRecipe = value; OnPropertyChanged("PlannedRecipe"); }
        }

        private string _mealTime;
        public string MealTime
        {
            get
            { return _mealTime; }
            set
            { _mealTime = value; OnPropertyChanged("MealTime"); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get
            { return _date; }
            set
            { _date = value; OnPropertyChanged("Date"); }
        }

        private bool _hasBeenEaten;
        public bool HasBeenEaten
        {
            get
            { return _hasBeenEaten; }
            set
            { _hasBeenEaten = value; OnPropertyChanged("HasBeenEaten"); }
        }
        #endregion

        public PlannedMeal()
        {
            _date = DateTime.Today;
            _mealTime = "Error";
            _plannedRecipe = new Recipe();
            _hasBeenEaten = false;
        }

        internal PlannedMeal(Recipe recipe, string mealTime, DateTime date, bool hasBeenEaten)
        {
            _plannedRecipe = recipe;
            _mealTime = string.Copy(mealTime);
            _date = date.Date;
            _hasBeenEaten = hasBeenEaten;
        }

        #region NotifyPropertChanged
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
    }
}
