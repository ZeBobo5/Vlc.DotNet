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
            myRincewindControl.MediaPlayer.VlcLibDirectoryNeeded += OnVlcControlNeedLibDirectory;
        }

        private void OnVlcControlNeedLibDirectory(object sender, Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
                return;
            if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\Vlc\x86\Rincewind\"));
            else
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\Vlc\x64\Rincewind\"));
        }

        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            myRincewindControl.MediaPlayer.Play(new FileInfo(@"D:\# Perso\Vidéos\Game of Thrones S04E10 FASTSUB VOSTFR 720p HTDV x264 - LIBFT.mkv"));
        }
    }
}
