using System;
using System.Windows.Forms;

namespace DwarvenRealms
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
            Application.Run(new MainGui());
            Properties.Settings.Default.Save();
        }
    }
}
