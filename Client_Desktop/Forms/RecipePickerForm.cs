using Core;
using Core.Utilities.Database.Queries.BindingLists;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Client_Desktop
{
    public partial class RecipePickerForm : Form
    {
        public Recipe SelectedRecipe { get; private set; }
        public RecipePickerForm()
        {
            InitializeComponent();

            using (HarvestBindingListUtility harvestBindingList = new HarvestBindingListUtility(new RecipeBindingListQuery()))
                RecipeGridView.DataSource = harvestBindingList.GetBindingList() as BindingList<Recipe>;
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
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            selectedIndex = RecipeGridView.CurrentCell.RowIndex;
        }
    }
}
