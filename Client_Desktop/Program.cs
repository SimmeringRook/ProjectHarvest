using System;
using System.Data.SqlClient;
using System.Diagnostics;
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
            ExecuteCommand("SqlLocalDB create MSSQLLocalDB -s");

            if (Core.Adapters.HarvestAdapter.Initialize())
            {
                if (TableExists())
                {
                    Application.Run(new HarvestForm());
                }
            }
            else
            {
                MessageBox.Show("An error occured while creating the database, if this issue persists contact the developers.");
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
            bool itWorked = false;

            try
            {
                itWorked = Core.Adapters.HarvestAdapter.TableExists();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to access the Metric Table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Core.Utilities.Logging.Logger.Log(ex);
            }

            return itWorked;
        }
    }
}
