using System;
using System.Windows.Forms;

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
            Clipboard.SetText(this.williamEmailLabel.Text);
        }
    }
}
