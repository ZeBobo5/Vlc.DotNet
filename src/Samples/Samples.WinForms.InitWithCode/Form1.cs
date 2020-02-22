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
            var libDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"libvlc\" + IntPtr.Size == 4 ? "win-x86" : "win-x64");

            control.BeginInit();
            control.VlcLibDirectory = libDirectory;
            control.Dock = DockStyle.Fill;
            control.EndInit();
            this.Controls.Add(control);

            control.Play(new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));
        }
    }
}
