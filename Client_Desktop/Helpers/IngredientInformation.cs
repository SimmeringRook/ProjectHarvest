using Core;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System;
using Core.DatabaseUtilities;

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
            Unit.SelectedIndex = RecipeIngredientUtility.GetIngredientUnitIndex(ingredient);

            //Type = GetCategoryComboTemplate();
            Selected.Checked = false;
        }
    }
}
