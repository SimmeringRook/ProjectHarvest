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
            this.DialogResult = DialogResult.OK;
        }

        #region Filter
        private void updateButton_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
