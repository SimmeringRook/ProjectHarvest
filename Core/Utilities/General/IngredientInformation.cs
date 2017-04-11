using System.Windows.Forms;
using Core.Adapters.Objects;
using Core.Utilities.UnitConversions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Core.Utilities.General
{
    public class IngredientInformation
    {
        public List<Control> Controls;
        public TextBox Name;
        public Label NameLabel;
        public TextBox Quantity;
        public ComboBox Unit;
        public ComboBox Type;
        public CheckBox Selected;

        private ErrorProvider _formErrorProvider;

        public IngredientInformation(bool isEditable, ErrorProvider formErrorProvider)
        {
            _formErrorProvider = formErrorProvider;
            Controls = new List<Control>();
            if (isEditable)
            {
                Controls.Add(Name = GetTextboxTemplate(isAmount: false));
                Controls.Add(Type = GetCategoryComboTemplate());
            }
            else
            {
                Controls.Add(NameLabel = GetLabelTemplate());
            }
            Controls.Add(Quantity = GetTextboxTemplate(isAmount: true));
            Controls.Add(Unit = GetUnitComboTemplate());
            Controls.Add(Selected = GetCheckBoxTemplate());
        }

        public Inventory GetInventoryFromControls()
        {
            Inventory item = new Inventory();
            item.Name = Name.Text;
            item.Amount = double.Parse(Quantity.Text);
            item.Measurement = (MeasurementUnit)System.Enum.Parse(typeof(MeasurementUnit), Unit.SelectedValue.ToString());
            item.Category = Type.SelectedValue.ToString();
            return item;
        }

        private TextBox GetTextboxTemplate(bool isAmount)
        {
            TextBox template = new TextBox();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            if (isAmount)
                template.Validating += nameTextbox_Validating;
            else
                template.Validating += quantityTextbox_Validating;
            return template;
        }

        private void nameTextbox_Validating(object sender, CancelEventArgs e)
        {
            Validation.HarvestValidator.Validate(Name, Validation.HarvestRegex.Name, _formErrorProvider);
        }

        private void quantityTextbox_Validating(object sender, CancelEventArgs e)
        {
            Validation.HarvestValidator.Validate(Quantity, Validation.HarvestRegex.Amount, _formErrorProvider);
        }

        private Label GetLabelTemplate()
        {
            Label template = new Label();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            return template;
        }

        private ComboBox GetCategoryComboTemplate()
        {
            ComboBox template = new ComboBox();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            return template;
        }

        private ComboBox GetUnitComboTemplate()
        {
            ComboBox template = new ComboBox();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            return template;
        }

        private CheckBox GetCheckBoxTemplate()
        {
            CheckBox template = new CheckBox();
            template.Anchor = AnchorStyles.None;
            return template;
        }

        public void SetDataBindings(ComboBox control, Binding dataBinding)
        {
            control.DataBindings.Add(dataBinding);
            control.DataSource = dataBinding.DataSource;
        }

        public void LoadExistingData(RecipeIngredient ingredient)
        {
            Name.Text = ingredient.Inventory.Name;
            Quantity.Text = ingredient.Amount.ToString();

            int index = -1;
            foreach (MeasurementUnit unit in Unit.Items)
                if (unit.Equals(ingredient.Measurement))
                   index = Unit.Items.IndexOf(unit);
            Unit.SelectedItem = Unit.Items[index];

            index = -1;
            foreach (string category in Type.Items)
                if (category.Equals(ingredient.Inventory.Category))
                    index = Type.Items.IndexOf(category);
            Type.SelectedItem = Type.Items[index];

            Selected.Checked = false;
        }

        public RecipeIngredient GetRecipeIngredient()
        {
            RecipeIngredient ingredient = new RecipeIngredient();
            ingredient.Amount = double.Parse(Quantity.Text);
            ingredient.Measurement = (MeasurementUnit)System.Enum.Parse(typeof(MeasurementUnit), Unit.SelectedValue.ToString());

            if (Adapters.HarvestAdapter.InventoryItems.Any(item => item.Name.Equals(Name.Text)))
            {
                ingredient.Inventory = Adapters.HarvestAdapter.InventoryItems.SingleOrDefault(item => item.Name.Equals(Name.Text));
            }
            else
            {
                ingredient.Inventory = new Inventory();
                ingredient.Inventory.ID = 0;
                ingredient.Inventory.Name = Name.Text;
                ingredient.Inventory.Amount = 0.0;
                ingredient.Inventory.Category = Type.SelectedValue.ToString();
                ingredient.Inventory.Measurement = ingredient.Measurement;
            }

            return ingredient;
        }
    }
}
