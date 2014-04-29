using System;

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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            MapCrafter mapCrafter = new MapCrafter();
            mapCrafter.simpleWriteTest();
            Properties.Settings.Default.Save();
        }
    }
}
