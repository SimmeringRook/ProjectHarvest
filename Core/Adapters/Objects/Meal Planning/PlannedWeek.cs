using Core.Utilities.UnitConversions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Adapters.Objects
{
    public class PlannedWeek
    {
        public List<PlannedDay> DaysOfWeek = new List<PlannedDay>();
        public DateTime StartOfWeek { get; private set; }
        public DateTime EndOfWeek { get; private set; }

        public PlannedWeek(DateTime start, DateTime end)
        {
            StartOfWeek = start;
            EndOfWeek = end;

            for (DateTime d = start; d.DayOfYear <= end.DayOfYear; d = d.AddDays(1))
                DaysOfWeek.Add(new PlannedDay(d));
        }

        public List<RecipeIngredient> GetAllIngredientsForWeek()
        {
            List<RecipeIngredient> allIngredients = new List<RecipeIngredient>();

            foreach (PlannedDay day in DaysOfWeek)
            {
                foreach (RecipeIngredient ingredientsFrequencyForDay in day.GetIngredientsForToday())
                    if (allIngredients.Any(ingredient => ingredient.Inventory.ID == ingredientsFrequencyForDay.Inventory.ID))
                    {
                        RecipeIngredient ri = allIngredients.Single(i => i.Inventory.ID == ingredientsFrequencyForDay.Inventory.ID);
                        allIngredients[allIngredients.IndexOf(ri)].Amount += ConvertedAmount(ingredientsFrequencyForDay, ri);
                    }
                    else
                        allIngredients.Add(ingredientsFrequencyForDay);
            }

            return allIngredients;
        }

        private double ConvertedAmount(RecipeIngredient ingredientToConvert, RecipeIngredient unitToConvertTo)
        {
            try
            {
                using (HarvestConverter conversion = new HarvestConverter(new VolumeUnitConversion()))
                {
                    if (conversion.IsCorrectMeasurementType(ingredientToConvert.Measurement) == false)
                        conversion.ConversionType = new WeightUnitConversion();
                    return conversion.Convert(new ConvertedIngredient(ingredientToConvert), unitToConvertTo.Measurement).Amount;
                }
            }
            catch (InvalidConversionException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return 0.0;
            }
        }


    }
}
