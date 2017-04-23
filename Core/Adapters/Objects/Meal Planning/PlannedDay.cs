using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Adapters.Objects
{
    public class PlannedDay
    {
        public DateTime Day { get; private set; }
        public List<PlannedMeal> MealsForDay { get { return HarvestAdapter.PlannedMeals.Where(p => p.Date.Equals(Day)).ToList(); } }

        public PlannedDay(DateTime day)
        {
            Day = day;
        }
    }
}
