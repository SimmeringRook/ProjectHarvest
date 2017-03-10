using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Desktop.Helpers
{
    public class PlannedMealDay
    {
        public DateTime Day;
        public Dictionary<MealTime, List<Recipe>> MealsPlanned;

        public PlannedMealDay(DateTime dayBeingPlanned)
        {
            Day = dayBeingPlanned;
            MealsPlanned = new Dictionary<MealTime, List<Recipe>>()
            {
                {new MealTime("Breakfast"), new List<Recipe>() },
                {new MealTime("Lunch"), new List<Recipe>() },
                {new MealTime("Dinner"), new List<Recipe>() }
            };

        }


    }
}
