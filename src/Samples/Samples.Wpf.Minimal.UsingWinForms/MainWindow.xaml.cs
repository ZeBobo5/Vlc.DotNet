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
            // Default installation path of VideoLAN.LibVLC.Windows
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            control.BeginInit();
            control.VlcLibDirectory = libDirectory;
            control.EndInit();

            control.Play(new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));
        }
    }
}
