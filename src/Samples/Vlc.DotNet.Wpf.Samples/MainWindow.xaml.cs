using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Vlc.DotNet.Wpf.Samples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VlcControl MyControl;
        public MainWindow()
        {
            InitializeComponent();
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

        private void MediaPlayer_Log(object sender, Core.VlcMediaPlayerLogEventArgs e)
        {
            string message = string.Format("libVlc : {0} {1} @ {2}", e.Level, e.Message, e.Module);
            System.Diagnostics.Debug.WriteLine(message);
        }

        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            if (MyControl == null)
            {
                return;
            }
            MyControl.MediaPlayer.Play(new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));
            //myControl.MediaPlayer.Play(new FileInfo(@"..\..\..\Vlc.DotNet\Samples\Videos\BBB trailer.mov"));
        }

        private void OnForwardButtonClick(object sender, RoutedEventArgs e)
        {
            if (MyControl == null)
            {
                return;
            }
            MyControl.MediaPlayer.Rate = 2;
        }

        private void GetLength_Click(object sender, RoutedEventArgs e)
        {
            if (MyControl == null)
            {
                return;
            }
            GetLength.Content = MyControl.MediaPlayer.Length + " ms";
        }

        private void GetCurrentTime_Click(object sender, RoutedEventArgs e)
        {
            if (MyControl == null)
            {
                return;
            }
            GetCurrentTime.Content = MyControl.MediaPlayer.Time + " ms";
        }

        private void SetCurrentTime_Click(object sender, RoutedEventArgs e)
        {
            if (MyControl == null)
            {
                return;
            }
            MyControl.MediaPlayer.Time = 5000;
            SetCurrentTime.Content = MyControl.MediaPlayer.Time + " ms";
        }

        private void videoBorder_Loaded(object sender, RoutedEventArgs e)
        {
            if (MyControl != null)
            {
                closeVLC();
            }
            initVLC();

        }

        private void videoBorder_Unloaded(object sender, RoutedEventArgs e)
        {
            closeVLC();
        }

        private void closeVLC()
        {
            MyControl.MediaPlayer.VlcLibDirectoryNeeded -= OnVlcControlNeedsLibDirectory;
            MyControl.MediaPlayer.Log -= MediaPlayer_Log;
            MyControl.Dispose();
            MyControl = null;
        }

        private void initVLC()
        {
            MyControl = new VlcControl();
            MyControl.MediaPlayer.VlcLibDirectoryNeeded += OnVlcControlNeedsLibDirectory;
            MyControl.MediaPlayer.EndInit();
            // This can also be called before EndInit
            MyControl.MediaPlayer.Log += MediaPlayer_Log;
            videoBorder.Child = MyControl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}
