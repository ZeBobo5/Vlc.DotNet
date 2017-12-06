using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Vlc.DotNet.Wpf.Samples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DirectoryInfo vlcLibDirectory;
        private VlcControl control;

        public MainWindow()
        {
            InitializeComponent();
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (IntPtr.Size == 4)
            {
                vlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\lib\x86\"));
            }
            else
            {
                vlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\lib\x64\"));
            }
        }
        
        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            this.control?.Dispose();
            this.control = new VlcControl();
            this.control.MediaPlayer.VlcLibDirectory = this.vlcLibDirectory;
            this.control.MediaPlayer.EndInit();

            this.ControlContainer.Content = this.control;

            // This can also be called before EndInit
            this.control.MediaPlayer.Log += (_, args) =>
            {
                string message = string.Format("libVlc : {0} {1} @ {2}", args.Level, args.Message, args.Module);
                System.Diagnostics.Debug.WriteLine(message);
            };
            control.MediaPlayer.Play(new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));
            //control.MediaPlayer.Play(new FileInfo(@"..\..\..\Vlc.DotNet\Samples\Videos\BBB trailer.mov"));
        }

        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            this.control?.MediaPlayer.Stop(); // This isn't strictly needed if Dispose() is called, but this is a demo...
            this.control?.Dispose();
            this.control = null;
        }

        private void OnForwardButtonClick(object sender, RoutedEventArgs e)
        {
            if(this.control == null)
            {
                return;
            }

            this.control.MediaPlayer.Rate = 2;
        }

        private void GetLength_Click(object sender, RoutedEventArgs e)
        {
            if (this.control == null)
            {
                return;
            }

            GetLength.Content = this.control.MediaPlayer.Length + " ms";
        }

        private void GetCurrentTime_Click(object sender, RoutedEventArgs e)
        {
            if (this.control == null)
            {
                return;
            }

            GetCurrentTime.Content = this.control.MediaPlayer.Time + " ms";
        }

        private void SetCurrentTime_Click(object sender, RoutedEventArgs e)
        {
            if (this.control == null)
            {
                return;
            }

            this.control.MediaPlayer.Time = 5000;
            SetCurrentTime.Content = this.control.MediaPlayer.Time + " ms";
        }
    }
}
