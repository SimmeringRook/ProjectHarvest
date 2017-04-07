using System.Windows.Forms;
using System.Linq;
using Core.Utilities.Database.Queries.Tables;

namespace Core.Utilities.General
{
    public class IngredientInformation
    {
        public TextBox Name;
        public Label NameLabel;
        public TextBox Quantity;
        public ComboBox Unit;
        public ComboBox Type;
        public CheckBox Selected;

        public IngredientInformation()
        {
            Name = GetTextboxTemplate();
            NameLabel = GetLabelTemplate();
            Quantity = GetTextboxTemplate();
            Unit = GetUnitComboTemplate();
            
            Type = GetCategoryComboTemplate();
            Selected = GetCheckBoxTemplate();
        }

        public Inventory GetInventoryFromControls()
        {
            Inventory item = new Inventory();
            item.IngredientName = Name.Text;
            item.Amount = double.Parse(Quantity.Text);
            item.Measurement = Unit.SelectedValue.ToString();
            item.Category = Type.SelectedValue.ToString();
            return item;
        }

        private TextBox GetTextboxTemplate()
        {
            TextBox template = new TextBox();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            return template;
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

        public void LoadExistingData(RecipeIngredient ingredient)
        {
            Quantity.Text = ingredient.Amount.ToString();

            int index = -1;
            foreach (Metric unit in Unit.Items)
                if (unit.Measurement.Equals(ingredient.Measurement))
                   index = Unit.Items.IndexOf(unit);
            Unit.SelectedItem = Unit.Items[index];     

            using (HarvestTableUtility harvest = new HarvestTableUtility(new InventoryQuery()))
            {
                Name.Text = (harvest.Get(ingredient.InventoryID) as Inventory).IngredientName;

                harvest.HarvestQuery = new IngredientCategoryQuery();
                Type.SelectedValue = (harvest.Get(ingredient.InventoryID) as IngredientCategory).Category;
            }

            Selected.Checked = false;
        }
    }
}
