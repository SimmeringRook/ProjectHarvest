using Core.Adapters;
using Core.Adapters.Objects;
using Core.Utilities.UnitConversions;
using System;
using System.Windows.Forms;

namespace Client_Desktop.Extensions
{
    public class PlannedRecipeControl : FlowLayoutPanel
    {
        public PlannedMeal PlannedMeal;
        //Controls
        public RecipeButton RecipeButton;
        private Button deleteButton;
        private Button ateButton;

        public PlannedRecipeControl(PlannedMeal plannedRecipe)
        {
            this.PlannedMeal = plannedRecipe;

            this.Margin = new Padding(5, 2, 0, 2);
            this.AutoSize = true;
            this.BorderStyle = BorderStyle.FixedSingle;
            
            RecipeButton = new RecipeButton(PlannedMeal.PlannedRecipe);
            this.Controls.Add(RecipeButton);

            deleteButton = _CreateButtonTemplate("X", deleteButton_Click);
            this.Controls.Add(deleteButton);

            ateButton = _CreateButtonTemplate("A", ateButton_Click);
            this.Controls.Add(ateButton);

            if (plannedRecipe.HasBeenEaten)
                SetControlsForHasBeenEaten();
        }

        private void SetControlsForHasBeenEaten()
        {
            RecipeButton.Enabled = false;
            ateButton.Visible = false;
        }

        private Button _CreateButtonTemplate(string text, EventHandler eventHandler)
        {
            Button template = new Button();
            template.Text = text;
            template.Size = new System.Drawing.Size(20, RecipeButton.Height);
            template.Click += new EventHandler(eventHandler);
            return template;
        }

        #region Button Click Events
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Remove recipe from plan
            foreach (var plannedDay in HarvestAdapter.CurrentWeek.DaysOfWeek)
            {
                if (plannedDay.Day.Equals(PlannedMeal.Date))
                {
                    plannedDay.UnplanRecipe(PlannedMeal);
                    break;
                }
            }

            //TODO Do this but with the Dispose pattern
            foreach (Control control in this.Controls)
                control.Dispose();

            this.Controls.Clear();
            this.Parent.Controls.Remove(this);
        }

        private void ateButton_Click(object sender, EventArgs e)
        {
            PlannedMeal.HasBeenEaten = true;
            try
            {
                foreach (RecipeIngredient ingredient in RecipeButton.Recipe.AssociatedIngredients)
                    using (HarvestConverter conversion = new HarvestConverter(new VolumeUnitConversion()))
                    {
                        if (conversion.IsCorrectMeasurementType(ingredient.Measurement) == false)
                            conversion.ConversionType = new WeightUnitConversion();
                        ingredient.Inventory.Amount -= conversion.Convert(new ConvertedIngredient(ingredient), ingredient.Inventory.Measurement).Amount;
                    }
            }
            catch (InvalidConversionException ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (MessageBox.Show("Remove from plan?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteButton_Click(sender, e);
            }
            else
            {
                SetControlsForHasBeenEaten();
            }
        }
        #endregion
    }
}
