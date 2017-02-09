using Core.RecipeMangement;
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
    public partial class PantryForm : Form
    {
        public PantryForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*  TODO:
             *  Any pre-exit operations that need to be conducted should be called either in here,
             *  or overide the Dispose().
             *  
             *  Ex: Ensure all changes to the inventory have been commited to the database before exit;
             *      or prompt user, warning of unsaved changes.
             */ 
            this.Dispose();
        }

        private void PantryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'harvestDataSet.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.harvestDataSet.Inventory);

        }
    }
}
