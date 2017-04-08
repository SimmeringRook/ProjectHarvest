using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Desktop
{
    public partial class Recipe : Form
    {
        private int numberOfRows;
        private List<TextBox> ingredientNameTextBox = new List<TextBox>();
        private List<TextBox> qtyTextBox = new List<TextBox>();
        private List<ComboBox> unitCboBox = new List<ComboBox>();
        private List<CheckBox> selectCheckBox = new List<CheckBox>();

        public Recipe()
        {
            InitializeComponent();
            numberOfRows = recipeTableLayout.RowCount;
            AddNewIngredientRow();
            subtractButton.Enabled = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewIngredientRow();
        }

        private void AddNewIngredientRow()
        {
            numberOfRows++;

            recipeTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            TextBox ingredientTemplate = GetTextboxTemplate();
            recipeTableLayout.Controls.Add(GetTextboxTemplate(), 0, numberOfRows - 1);
            ingredientNameTextBox.Add(ingredientTemplate);

            TextBox qtyTemplate = GetTextboxTemplate();
            recipeTableLayout.Controls.Add(GetTextboxTemplate(), 1, numberOfRows - 1);
            qtyTextBox.Add(qtyTemplate);

            ComboBox unitTemplate = GetCboBoxTemplate();
            recipeTableLayout.Controls.Add(GetCboBoxTemplate(), 2, numberOfRows - 1);
            unitCboBox.Add(unitTemplate);

            CheckBox selectTemplate = GetCheckBoxTemplate();
            recipeTableLayout.Controls.Add(GetCheckBoxTemplate(), 3, numberOfRows - 1);
            selectCheckBox.Add(selectTemplate);

            if (numberOfRows > 2)
            {
                subtractButton.Enabled = true;
            }
        }

        private TextBox GetTextboxTemplate()
        {
            return new TextBox();
        }

        private ComboBox GetCboBoxTemplate()
        {
            return new ComboBox();
        }

        private CheckBox GetCheckBoxTemplate()
        {
            return new CheckBox();
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            numberOfRows--;

            for (int i = 0; i < recipeTableLayout.ColumnCount; i++)
            {
                Control controlToRemove = recipeTableLayout.GetControlFromPosition(i, numberOfRows);
                recipeTableLayout.Controls.Remove(controlToRemove);
            }

            recipeTableLayout.RowStyles.RemoveAt(numberOfRows - 1);
            recipeTableLayout.RowCount = numberOfRows - 1;

            ingredientNameTextBox.RemoveAt(ingredientNameTextBox.Count - 1);
            qtyTextBox.RemoveAt(qtyTextBox.Count - 1);
            unitCboBox.RemoveAt(unitCboBox.Count - 1);
            selectCheckBox.RemoveAt(selectCheckBox.Count - 1);

            if (numberOfRows == 2)
            {
                subtractButton.Enabled = false;
            }
        }
    }
}
