using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
namespace VLC_Example
{
    public partial class frmExample : Form
    {
        public frmExample()
        {
            InitializeComponent();
        }

        private void frmExample_Load(object sender, EventArgs e)
        {
            //Lets get our VLC files first.
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows nuget package
            var VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
            var VLC = new VlcControl();
            VLC.BeginInit();
            VLC.VlcLibDirectory = VlcLibDirectory;
            var Options = new string[]
            {
                //Options go here
                "--audio-filter","normvol","--norm-max-level","1.5" 
                //Normalizes Volume as an example
            };
            VLC.VlcMediaplayerOptions = Options;
            VLC.EndInit();
            VLC.Dock = DockStyle.Fill;
            Controls.Add(VLC); //"this" is not required.
            //VLC is now running full screen in the form.
            //You set up controls however you like.
            VLC.SetMedia(new Uri("https://share.epic-domain.com/2018-12-06_06-30-281437ce2a04a2d1077.webm"));
            VLC.Play();
        }
    }
}
