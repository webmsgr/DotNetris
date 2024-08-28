using System.Security.Cryptography.X509Certificates;
using System.Text;
using DotNetris.Configuration;
using DotNetris.Network;
using DotNetris.Network.Server;

namespace DotNetris
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Configuration.Configuration.Init();
            Application.Run(new MainMenuForm());
        }

        
    }
}