using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Vlc.DotNet.Forms.Samples
{
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();
            //vlcRincewindControl1.Play(new FileInfo(@"D:\Mashur & Kevlar - Alone (I Am Robot Flip).mp3"));
            //vlcRincewindControl1.Play(new FileInfo(@"D:\# Perso\Vidéos\Game of Thrones S04E10 FASTSUB VOSTFR 720p HTDV x264 - LIBFT.mkv"));
        }

        private void OnVlcControlNeedLibDirectory(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
                return;
            //if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
            //    e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\Vlc\x86\Rincewind\"));
            //else
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\Vlc\x64\Rincewind\"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vlcRincewindControl1.Play(new FileInfo(@"D:\# Perso\Vidéos\Game of Thrones S04E10 FASTSUB VOSTFR 720p HTDV x264 - LIBFT.mkv"));
        }
    }
}
