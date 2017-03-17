using Core;
using System.Windows.Forms;
using Core.DatabaseUtilities.Queries;

namespace Client_Desktop.Helpers
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
            Name.Text = ingredient.Inventory.IngredientName;
            Quantity.Text = ingredient.Amount.ToString();
            using (HarvestUtility harvest = new HarvestUtility(new MetricQuery()))
            {
                Unit.SelectedValue = (harvest.Get(ingredient.InventoryID) as Metric).Measurement;

                harvest.HarvestQuery = new IngredientCategoryQuery();
                Type.SelectedValue = (harvest.Get(ingredient.InventoryID) as IngredientCategory).Category;
            }

            Selected.Checked = false;
        }
    }
}
