using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace JTTT
{
    class CustomLogger
    {
        private string file_path = String.Empty;
        private StreamWriter writer;

        public CustomLogger()
        {
            file_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\logfile.txt";
        }

        public CustomLogger(string log_file_name)
        {
            file_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" +log_file_name;
        }

        private void OpenLogFile()
        {
            writer = File.AppendText(file_path);
            Debug.WriteLine("File opened on: " + file_path);
        }
        
        private void CloseLogFile()
        {
            writer.Flush();
            writer.Close();
        }

        public bool Write(string method, string message)
        {
            try
            {
                OpenLogFile();
                writer.WriteLine("Method: " + method);
                writer.WriteLine("Date  : " + DateTime.Now.ToShortDateString());
                writer.WriteLine("Time  : " + DateTime.Now.ToShortTimeString());
                writer.WriteLine("Message : " + message);
                writer.WriteLine("---------------------------------------------------------------------");

                CloseLogFile();
            }
            catch
            {
                Debug.WriteLine("Error: Couldn't write to log file");
            }
            return true;
        }

        public bool Write(Exception e)
        {
            try
            {
                OpenLogFile();
                writer.WriteLine("Source: " + e.Source);
                writer.WriteLine("Method: " + e.TargetSite.Name);
                writer.WriteLine("Date  : " + DateTime.Now.ToShortDateString());
                writer.WriteLine("Time  : " + DateTime.Now.ToShortTimeString());
                writer.WriteLine("Error : " + e.Message);
                writer.WriteLine("Trace : " + e.StackTrace);
                writer.WriteLine("---------------------------------------------------------------------");

                CloseLogFile();
            }
            catch
            {
                Debug.WriteLine("Error: Couldn't write to log file");
            }
            return true;
        }
    }
}
