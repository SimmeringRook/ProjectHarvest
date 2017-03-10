using Core;
using Core.DatabaseUtilities;
using Core.DatabaseUtilities.BindingListQueries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Desktop.Helpers
{
    public static class HarvestFormUtility
    {
        /// <summary>
        /// Loads the relevant table for the current TabPage, and rebinds the table to the datagridview
        /// </summary>
        public static void RefreshCurrentTab(TabControl pantryTabs)
        {
            DataGridView gridOnTab = GetDataGridForTabPage(pantryTabs.SelectedTab);
            switch (pantryTabs.SelectedIndex)
            {
                case 0:
                    //Meal Planning stuff goes here
                    //LoadWeek();
                    break;
                case 1:
                    using (HarvestBindingListUtility harvestBindingList = new HarvestBindingListUtility(new InventoryBindingListQuery()))
                        gridOnTab.DataSource = (harvestBindingList.GetBindingList() as BindingList<Inventory>).ToList();
                    break;
                case 2:
                    using (HarvestBindingListUtility harvestBindingList = new HarvestBindingListUtility(new RecipeBindingListQuery()))
                        gridOnTab.DataSource = (harvestBindingList.GetBindingList() as BindingList<Recipe>).ToList();
                    break;
            }
            pantryTabs.SelectedTab.Refresh();
        }

        private static DataGridView GetDataGridForTabPage(TabPage selectedTab)
        {
            foreach (Control control in selectedTab.Controls)
                if (control is TableLayoutPanel)
                    foreach (Control ctrl in control.Controls)
                        if (ctrl is DataGridView)
                            return ctrl as DataGridView;

            return null;
        }

    }
}
