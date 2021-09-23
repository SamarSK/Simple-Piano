using System;
using System.Windows.Forms;

namespace SimplePiano
{
    static class Program
    {
        /// <summary>
        ///  Simple Piano
        ///  Samuel Tomko, 1. roèník bc. studia, Informatika
        ///  Roèník 2020/2021
        ///  Programovanie 2 NPRG031
        ///  
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
