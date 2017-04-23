using System.Windows.Forms;
using Core.Adapters.Objects;
using Core.Utilities.UnitConversions;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Core.Utilities.General
{
    public class IngredientInformation
    {
        public List<Control> Controls;
        public TextBox Name;
        public Label NameLabel;
        public TextBox Quantity;
        public ComboBox Unit;
        public ComboBox Category;
        public CheckBox Selected;

        private ErrorProvider _formErrorProvider;

        public IngredientInformation(bool isEditable, ErrorProvider formErrorProvider)
        {
            _formErrorProvider = formErrorProvider;
            Controls = new List<Control>();
            if (isEditable)
            {
                Controls.Add(Name = ControlFactory.CreateControlTemplate(new TextBox(), Validation.HarvestRegex.Name, _formErrorProvider) as TextBox);
                Controls.Add(Category = ControlFactory.CreateControlTemplate(new ComboBox()) as ComboBox);
            }
            else
            {
                Controls.Add(NameLabel = ControlFactory.CreateControlTemplate(new Label()) as Label);
            }
            Controls.Add(Quantity = ControlFactory.CreateControlTemplate(new TextBox(), Validation.HarvestRegex.Amount, _formErrorProvider) as TextBox);
            Controls.Add(Unit = ControlFactory.CreateControlTemplate(new ComboBox()) as ComboBox);
            Controls.Add(Selected = ControlFactory.CreateControlTemplate(new CheckBox()) as CheckBox);
        }

        public void LoadExistingData(RecipeIngredient ingredient)
        {
            Name.Text = ingredient.Inventory.Name;
            Quantity.Text = ingredient.Amount.ToString();

            Unit.SelectedIndex = Unit.Items.IndexOf(ingredient.Measurement);
            Category.SelectedIndex = Category.Items.IndexOf(ingredient.Inventory.Category);

            Selected.Checked = false;
        }

        public RecipeIngredient GetRecipeIngredient(int recipeID)
        {
            RecipeIngredient ingredient = new RecipeIngredient();
            ingredient.RecipeID = recipeID;
            ingredient.Amount = double.Parse(Quantity.Text);
            ingredient.Measurement = (MeasurementUnit)System.Enum.Parse(typeof(MeasurementUnit), Unit.SelectedValue.ToString());

            try
            {
                if (Adapters.HarvestAdapter.InventoryItems.Any(item => item.Name.Equals(Name.Text)))
                {
                    ingredient.Inventory = Adapters.HarvestAdapter.InventoryItems.SingleOrDefault(item => item.Name.Equals(Name.Text));
                }
                else
                {
                    ingredient.Inventory = new Inventory();
                    ingredient.Inventory.Name = Name.Text;
                    ingredient.Inventory.Category = Category.SelectedValue.ToString();
                    ingredient.Inventory.Measurement = ingredient.Measurement;

                    Adapters.HarvestAdapter.InventoryItems.Add(ingredient.Inventory);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured while trying to retrieve information from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logging.Logger.Log(ex);
            }

            return ingredient;
        }

        public override string ToString()
        {
            return NameLabel.Text.PadRight(25) + Quantity.Text.PadRight(5) + Unit.Text.PadRight(25);
        }
    }
}
