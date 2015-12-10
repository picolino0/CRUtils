using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CRUtils
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains("CRUtils") && clsProcess.Id != Process.GetCurrentProcess().Id)
                {
                    MessageBox.Show("An instance of CRUtils is already running");
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
