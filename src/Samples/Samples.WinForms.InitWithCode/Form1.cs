using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace Samples.WinForms.InitWithCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var control = new VlcControl();


            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            control.BeginInit();
            control.VlcLibDirectory = libDirectory;
            control.Dock = DockStyle.Fill;
            control.EndInit();
            this.Controls.Add(control);

            control.Play(new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));
        }
    }
}
