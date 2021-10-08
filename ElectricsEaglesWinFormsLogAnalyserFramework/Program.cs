using System;
using System.Windows.Forms;

namespace ElectricsEaglesWinFormsLogAnalyserFramework
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


            try
            {
                Application.Run(new Form1());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
