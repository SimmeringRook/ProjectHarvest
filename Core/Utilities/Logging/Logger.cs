using System;
using System.Collections.Generic;
using System.IO;

namespace Core.Utilities.Logging
{
    public static class Logger
    {
        /*
            MessageBox.Show("An error occured while trying to retrieve information from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Core.Utilities.Logging.Logger.Log(ex);
         */
        private static string _ErrorLogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Harvest_Error_Log.txt");

        public static void Log(Exception ex)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_ErrorLogPath, true))
                {
                    writer.WriteLine(DateTime.Now);

                    Exception lastException;
                    foreach (string message in GetAllMessages(ex, out lastException))
                        writer.WriteLine(message);

                    writer.WriteLine("--Stack Trace--");
                    writer.WriteLine(lastException.StackTrace);
                    writer.WriteLine("\n");
                }
            }
            catch(Exception fatalException)
            {
                System.Windows.Forms.MessageBox.Show("An error occured while trying to record information about errors. Please take a screenshot of the following message and send it to one of the developers.", "Error Log Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                string message = "";
                Exception lastException;
                foreach (string s in GetAllMessages(fatalException, out lastException))
                    message += s + "\n";
                System.Windows.Forms.MessageBox.Show(message + "/nStack Trace:/n" + lastException.StackTrace, "Send this to the developers", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private static List<string> GetAllMessages(this Exception ex, out Exception lastException)
        {
            List<string> messages = new List<string>();
            Exception innerException = ex;
            do
            {
                if (!string.IsNullOrEmpty(innerException.Message))
                    messages.Add(innerException.Message);

                lastException = innerException;
                innerException = innerException.InnerException;
            }
            while (innerException != null);

            return messages;
        }
    }
}
