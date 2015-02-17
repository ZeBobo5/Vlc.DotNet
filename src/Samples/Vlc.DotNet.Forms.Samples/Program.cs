using System;
using System.Reflection;
using System.Windows.Forms;

namespace Vlc.DotNet.Forms.Samples
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
            Application.Run(new Sample());
        }
    }
}
