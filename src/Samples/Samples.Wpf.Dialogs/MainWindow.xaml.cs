using System;
using System.IO;
using System.Reflection;

namespace Samples.Wpf.Dialogs
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            this.VlcControl.SourceProvider.CreatePlayer(libDirectory/* pass your player parameters here */);
            this.VlcControl.SourceProvider.MediaPlayer.Dialogs.UseDialogManager(new MetroDialogManager(this));

            // The following test URL is used to test authentication, but there is no video behind that...
            //this.VlcControl.SourceProvider.MediaPlayer.Play(new Uri("http://httpbin.org/basic-auth/user/passwd"));

            // The following test URL displays an error dialog saying that the media could not be opened
            this.VlcControl.SourceProvider.MediaPlayer.Play(new Uri("http://127.0.0.1/NonExistentUrl"));
        }
    }
}
