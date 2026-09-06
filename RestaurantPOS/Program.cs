using System;
using System.Windows.Forms;
using RestaurantPOS.Forms;

namespace RestaurantPOS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration_Initialize();

            Application.ThreadException += (s, e) =>
            {
                MessageBox.Show("An unexpected error occurred:\n" + e.Exception.Message,
                    "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                MessageBox.Show("A fatal error occurred:\n" + (e.ExceptionObject as Exception)?.Message,
                    "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            Application.Run(new frmLogin());
        }

        private static void ApplicationConfiguration_Initialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
        }
    }
}
