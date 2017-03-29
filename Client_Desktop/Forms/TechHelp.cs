using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Core.MealPlanning;
using System.Collections.Generic;
using System;
using Core.Utilities.General;
using Core.Utilities.Database.Queries.Tables;

namespace Client_Desktop
{
    public partial class TechHelp : Form
    {
        public TechHelp()
        {
            InitializeComponent();
        }      

        private void copyThomasButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.thomasEmailLabel.Text);
        }

        private void copyWilliamEmail_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(williamEmailLabel.Text);
        }
    }
}
