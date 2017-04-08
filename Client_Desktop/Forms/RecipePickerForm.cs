using Core.Adapters.Objects;
using System;
using System.Windows.Forms;

namespace Client_Desktop
{
    public partial class RecipePickerForm : Form
    {
        public Recipe SelectedRecipe { get; private set; }
        public RecipePickerForm()
        {
            InitializeComponent();

            RecipeGridView.DataSource = Core.Adapters.HarvestAdapter.Recipes;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
                SelectedRecipe = (Recipe) RecipeGridView.Rows[selectedIndex].DataBoundItem;
            this.DialogResult = DialogResult.OK;
        }

        #region Filter
        private void updateButton_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private int selectedIndex = -1;
        private void RecipeGridView_SelectionChanged(object sender, EventArgs e)
        {
            selectedIndex = RecipeGridView.CurrentCell.RowIndex;
        }
    }
}
