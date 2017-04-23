using Core.Utilities.Queries;
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

        public PlannedWeek()
        {
            StartOfWeek = DateTime.Today;

            using (HarvestEntitiesUtility launchTable = new HarvestEntitiesUtility(new LastLaunchedQuery()))
            {
                var firstLaunch = launchTable.Get(-1) as Database.LastLaunched;
                if (firstLaunch == null)
                    launchTable.Update(new Database.LastLaunched() { Date = StartOfWeek });
                else
                    StartOfWeek = firstLaunch.Date;
            }

            EndOfWeek = StartOfWeek.AddDays(6);

            for (DateTime d = StartOfWeek; d.DayOfYear <= EndOfWeek.DayOfYear; d = d.AddDays(1))
                DaysOfWeek.Add(new PlannedDay(d));
        }

        public Dictionary<RecipeIngredient, double> GetAllItemsToPurchase()
        {
            Dictionary<RecipeIngredient, double> allItemsToPurchase = new Dictionary<RecipeIngredient, double>();

            foreach (PlannedDay day in DaysOfWeek)
            {
                foreach (PlannedMeal meal in day.MealsForDay)
                {
                    if (meal.HasBeenEaten == false)
                        foreach (RecipeIngredient ingredient in meal.PlannedRecipe.AssociatedIngredients)
                        {
                            if (allItemsToPurchase.Any(item => item.Key.Inventory.Equals(ingredient.Inventory)))
                                allItemsToPurchase[ingredient] += ConvertedAmount(ingredient, ingredient.Inventory.Measurement);
                            else
                                allItemsToPurchase.Add(ingredient, ingredient.Amount);
                        }
                }
            }

            return allItemsToPurchase;
        }

        private double ConvertedAmount(RecipeIngredient ingredientToConvert, MeasurementUnit unitToConvertTo)
        {
            try
            {
                using (HarvestConverter conversion = new HarvestConverter(new VolumeUnitConversion()))
                {
                    if (conversion.IsCorrectMeasurementType(ingredientToConvert.Measurement) == false)
                        conversion.ConversionType = new WeightUnitConversion();
                    return conversion.Convert(new ConvertedIngredient(ingredientToConvert), unitToConvertTo).Amount;
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