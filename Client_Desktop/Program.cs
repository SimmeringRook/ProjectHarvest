using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

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
            ExecuteCommand("SqlLocalDB -s MSSQLLocalDB");
            
            HarvestForm mainForm = null;
            try
            {
                mainForm = new HarvestForm();
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Installation successful, please relaunch Harvest.");
                Core.Utilities.Logging.Logger.Log(ex);
                mainForm.Dispose();
            }
        }

        static void ExecuteCommand(string command)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            var process = Process.Start(processInfo);

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("error>>" + e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
        }

        static bool TableExists()
        {
            string connString = ConfigurationManager.ConnectionStrings["HarvestDatabaseEntities"].ConnectionString;
            bool itWorked = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand testCommand = new SqlCommand("SELECT * FROM Metrics", conn);
                    SqlDataReader reader = testCommand.ExecuteReader();
                    itWorked = reader.Read();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured while trying to retrieve information from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Core.Utilities.Logging.Logger.Log(ex);
            }

            return itWorked;
        }
    }
}
