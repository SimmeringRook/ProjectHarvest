using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HarvestForm mainForm = null;
            try
            {
                mainForm = new HarvestForm();
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Installation successful, please relaunch Harvest.");
                if (ex.InnerException != null)
                {
                    using (StreamWriter writer = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "errorLog.txt")))
                    {
                        string lines = ex.Message;
                        if (ex.InnerException != null)
                        {
                            lines += "\n" + ex.InnerException.Message;
                            if (ex.InnerException.InnerException != null)
                                lines += "\n" + ex.InnerException.InnerException.Message;
                        }
                        writer.WriteLine(lines);
                    }
                }
                mainForm.Dispose();
            }            
        }
    }
}
