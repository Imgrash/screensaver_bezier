using System;
using System.Windows.Forms;

namespace screensaver
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                if (args[0].ToLower().Trim().Substring(0, 2) == "/s" || args[0].ToLower().Trim().Substring(0, 2) == "/p")
                {
                    // Отобразить заставку
                    ShowScreenSaver();
                    Application.Run();
                }
                else if (args[0].ToLower().Trim().Substring(0, 2) == "/c")
                {
                    // Отображение окна с настройками заставки
                    Application.Run(new FormConfigure());
                }
            }
            else
            {
                // Отобразить заставку    
                ShowScreenSaver();
                Application.Run();
            }
        }
        // Отображение заставки
        static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                frmMain screensaver = new frmMain();
                screensaver.Show();
            }
        }
    }
}
