using System;
using System.IO;
using System.Reflection;
using System.Windows;
using Vlc.DotNet.Forms;

namespace Samples.Wpf.Minimal.UsingWinForms
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var control = new VlcControl();
            this.WindowsFormsHost.Child = control;


            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            DirectoryInfo libDirectory;
            // Default libraries are stored here, but they are old, don't use them.
            // We need a better way to install them, see https://github.com/ZeBobo5/Vlc.DotNet/issues/288
            if (IntPtr.Size == 4)
                libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\..\..\lib\x86\"));
            else
                libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\..\..\lib\x64\"));

            control.BeginInit();
            control.VlcLibDirectory = libDirectory;
            control.EndInit();

            control.Play(new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));
        }
    }
}
