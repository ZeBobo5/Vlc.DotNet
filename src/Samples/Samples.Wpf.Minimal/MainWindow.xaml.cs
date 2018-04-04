using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Samples.Wpf.Minimal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            this.VlcControl.SourceProvider.CreatePlayer(libDirectory/* pass your player parameters here */);
            this.VlcControl.SourceProvider.MediaPlayer.Play(new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));
        }
    }
}
