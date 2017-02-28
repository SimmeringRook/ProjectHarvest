using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Desktop
{
    public partial class RecipePickerForm : Form
    {
        public Recipe SelectedRecipe { get; private set; }
        public RecipePickerForm()
        {
            InitializeComponent();

            using (HarvestEntities context = new HarvestEntities())
            {
                context.Recipe.Load();
                dataGridView1.DataSource = context.Recipe.Local.ToBindingList();
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            //int index = dataGridView1.SelectedRows[0].Index;
            int rowCount = dataGridView1.Rows.Count;
            SelectedRecipe = (Recipe) dataGridView1.Rows[selectedIndex].DataBoundItem;
            this.DialogResult = DialogResult.OK;
        }

        #region Filter
        private void updateButton_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private int selectedIndex = 0;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            selectedIndex = dataGridView1.CurrentCell.RowIndex;
        }
    }
}
