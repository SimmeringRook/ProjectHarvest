using Core.Adapters;
using Core.Adapters.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Client_Desktop
{
    public partial class RecipePickerForm : Form
    {
        public Recipe SelectedRecipe { get; private set; }
        public RecipePickerForm()
        {
            InitializeComponent();
        }

        private void RecipePickerForm_Load(object sender, EventArgs e)
        {
            selectButton.Enabled = false;
            try
            {
                RecipeGridView.DataSource = HarvestAdapter.Recipes.ToList();
                EnableFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to retrieve information from the database.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Events
        private void selectButton_Click(object sender, EventArgs e)
        {
            if (SelectedRecipe != null)
                this.DialogResult = DialogResult.OK;
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void RecipeGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (RecipeGridView.SelectedRows.Count > 0)
            {
                int rowIndex = RecipeGridView.SelectedRows[0].Index;
                if (rowIndex != -1)
                    SelectedRecipe = (Recipe)RecipeGridView.Rows[rowIndex].DataBoundItem;
                selectButton.Enabled = true;
            }
            else
            {
                SelectedRecipe = null;
                selectButton.Enabled = false;
            }
        }
        #endregion

        #region Filters
        private void EnableFilters()
        {
            if (RecipeGridView.Rows.Count <= 1)
            {
                categoryCombo.Enabled = false;
                servingsCombo.Enabled = false;
            }
            List<string> servings = new List<string>();

            foreach (Recipe recipe in HarvestAdapter.Recipes.OrderBy(r => r.Servings))
                if (!servings.Any(serving => serving.Equals(recipe.Servings.ToString())))
                    servings.Add(recipe.Servings.ToString());

            if (servings.Count <= 1)
                servingsCombo.Enabled = false;
            servingsCombo.Items.AddRange(servings.ToArray());
            servingsCombo.Items.Insert(0, "All");
            servingsCombo.SelectedIndex = servingsCombo.Items.IndexOf("All");

            categoryCombo.Items.AddRange(HarvestAdapter.RecipeCategories.ToArray());
            categoryCombo.Items.Insert(0, "All");
            categoryCombo.SelectedIndex = categoryCombo.Items.IndexOf("All");
        }
        private void FilterGridView()
        {
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[RecipeGridView.DataSource];
            currencyManager.SuspendBinding();

            bool categoryFilterActive = (categoryCombo.SelectedIndex > 0);
            bool servingsFilterActive = (servingsCombo.SelectedIndex > 0);

            foreach (DataGridViewRow row in RecipeGridView.Rows)
            {
                if (categoryFilterActive && servingsFilterActive)
                    row.Visible = (row.Cells[2].Value.Equals(categoryCombo.SelectedItem.ToString()) && row.Cells[1].Value.Equals(Convert.ToDouble(servingsCombo.SelectedItem)));
                else if (categoryFilterActive)
                    row.Visible = (row.Cells[2].Value.Equals(categoryCombo.SelectedItem.ToString()));
                else if (servingsFilterActive)
                    row.Visible = (row.Cells[1].Value.Equals(Convert.ToDouble(servingsCombo.SelectedItem)));
                else
                    row.Visible = true;
            }

            currencyManager.ResumeBinding();
        }
        private void categoryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGridView();
        }

        private void servingsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGridView();
        }
        #endregion
    }
}
