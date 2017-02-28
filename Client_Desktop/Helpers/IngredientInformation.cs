using Core;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Client_Desktop.Helpers
{
    public class IngredientInformation
    {
        public TextBox Name;
        public TextBox Quantity;
        public ComboBox Unit;
        public ComboBox Type;
        public CheckBox Selected;

        public IngredientInformation(BindingList<Metric> units)
        {
            Name = GetTextboxTemplate();
            Quantity = GetTextboxTemplate();
            Unit = GetUnitComboTemplate(units);
            
            Type = GetCategoryComboTemplate();
            Selected = GetCheckBoxTemplate();
        }

        public Inventory GetInventoryFromControls()
        {
            Inventory item = new Inventory();
            item.IngredientName = Name.Text;
            item.Amount = double.Parse(Quantity.Text);
            item.Measurement = Unit.SelectedValue.ToString();
            //TODO use once the combo is added
            //item.Category = Type.SelectedValue.ToString();
            item.Category = "Grain";
            return item;
        }

        private TextBox GetTextboxTemplate()
        {
            TextBox template = new TextBox();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            return template;
        }

        private ComboBox GetCategoryComboTemplate()
        {
            ComboBox template = new ComboBox();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            return template;
        }

        private ComboBox GetUnitComboTemplate(BindingList<Metric> units)
        {
            ComboBox template = new ComboBox();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            template.DataBindings.Add(new Binding("SelectedValue", units, "Measurement", true));
            template.DataSource = units.ToList();
            template.DisplayMember = "Measurement";
            template.ValueMember = "Measurement";
            return template;
        }

        private CheckBox GetCheckBoxTemplate()
        {
            CheckBox template = new CheckBox();
            template.Anchor = AnchorStyles.None;
            return template;
        }
    }
}
