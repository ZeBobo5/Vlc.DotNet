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
        public MainWindow()
        {
            InitializeComponent();
            MyControl.MediaPlayer.VlcLibDirectoryNeeded += OnVlcControlNeedsLibDirectory;
            MyControl.MediaPlayer.EndInit();

            // This can also be called before EndInit
            this.MyControl.MediaPlayer.Log += (sender, args) =>
            {
                string message = string.Format("libVlc : {0} {1} @ {2}", args.Level, args.Message, args.Module);
                System.Diagnostics.Debug.WriteLine(message);
            };
        }

        private void OnVlcControlNeedsLibDirectory(object sender, Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (IntPtr.Size == 4)
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\lib\x86\"));
            else
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\lib\x64\"));
        }

        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            MyControl.MediaPlayer.Play(new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));
            //myControl.MediaPlayer.Play(new FileInfo(@"..\..\..\Vlc.DotNet\Samples\Videos\BBB trailer.mov"));
        }

        private void OnForwardButtonClick(object sender, RoutedEventArgs e)
        {
            MyControl.MediaPlayer.Rate = 2;
        }

        private void GetLength_Click(object sender, RoutedEventArgs e)
        {
            GetLength.Content = MyControl.MediaPlayer.Length + " ms";
        }

        private void GetCurrentTime_Click(object sender, RoutedEventArgs e)
        {
            GetCurrentTime.Content = MyControl.MediaPlayer.Time + " ms";
        }

        private void SetCurrentTime_Click(object sender, RoutedEventArgs e)
        {
            MyControl.MediaPlayer.Time = 5000;
            SetCurrentTime.Content = MyControl.MediaPlayer.Time + " ms";
        }
    }
}
