namespace ProcessScheduling.WinApp
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new App(new AppService()));
        }
    }
}