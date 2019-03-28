using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using Vlc.DotNet.Wpf;

namespace Samples.Wpf.Image
{
    public partial class MainWindow : Window
    {
        private VlcVideoSourceProvider sourceProvider;

        public MainWindow()
        {
            InitializeComponent();
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            this.sourceProvider = new VlcVideoSourceProvider(this.Dispatcher);

            this.sourceProvider.CreatePlayer(libDirectory/* pass your player parameters here */);
            this.sourceProvider.MediaPlayer.Play(new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));

            this.Video.SetBinding(System.Windows.Controls.Image.SourceProperty,
                new Binding(nameof(VlcVideoSourceProvider.VideoSource)) {Source = sourceProvider});
            
            this.BackgroundVideo.SetBinding(System.Windows.Controls.Image.SourceProperty,
                new Binding(nameof(VlcVideoSourceProvider.VideoSource)) { Source = sourceProvider });
        }
    }
}
