using Core;
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

        public IngredientInformation()
        {
            Name = GetTextboxTemplate();
            Quantity = GetTextboxTemplate();
            Unit = GetCboBoxTemplate();
            Type = GetCboBoxTemplate();
            Selected = GetCheckBoxTemplate();
        }

        public Inventory GetInventoryFromControls()
        {
            Inventory item = new Inventory();
            item.IngredientName = Name.Text;
            item.Amount = double.Parse(Quantity.Text);
            item.Measurement = Unit.SelectedItem.ToString();
            item.Category = Type.SelectedItem.ToString();

            return item;
        }

        private TextBox GetTextboxTemplate()
        {
            TextBox template = new TextBox();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            return template;
        }

        private ComboBox GetCboBoxTemplate()
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
    }
}
