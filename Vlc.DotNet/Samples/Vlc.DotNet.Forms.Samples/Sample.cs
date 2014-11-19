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
        }

        private void OnVlcControlNeedLibDirectory(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
                return;
            if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\Vlc\x86\Rincewind\"));
            else
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\Vlc\x64\Rincewind\"));

            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void OnButtonPlayClicked(object sender, EventArgs e)
        {
            myVlcRincewindControl.Play(new FileInfo(@"..\..\..\Vlc.DotNet\Samples\Videos\BBB trailer.mov"));
        }

        private void OnButtonStopClicked(object sender, EventArgs e)
        {
            myVlcRincewindControl.Stop();
        }

        private void OnButtonPauseClicked(object sender, EventArgs e)
        {
            myVlcRincewindControl.Pause();
        }

        private void OnVlcMediaLengthChanged(object sender, Core.VlcMediaPlayerLengthChangedEventArgs e)
        {
#if !NET20
            myLblMediaLength.InvokeIfRequired(l => l.Text = new DateTime(new TimeSpan((long) e.NewLength).Ticks).ToString("T"));
#endif
        }

        private void OnVlcPositionChanged(object sender, Core.VlcMediaPlayerPositionChangedEventArgs e)
        {
            var position = myVlcRincewindControl.GetCurrentMedia().Duration.Ticks * e.NewPosition;
#if !NET20
            myLblVlcPosition.InvokeIfRequired(l => l.Text = new DateTime((long)position).ToString("T"));
#else
            ControlExtensions.InvokeIfRequired(myLblVlcPosition, c => c.Text = new DateTime((long)position).ToString("T"));
#endif
        }

        private void OnVlcPaused(object sender, Core.VlcMediaPlayerPausedEventArgs e)
        {
#if !NET20
            myLblState.InvokeIfRequired(l => l.Text = "Paused");
#else
            ControlExtensions.InvokeIfRequired(myLblState, c => c.Text = "Paused");
#endif
        }

        private void OnVlcStopped(object sender, Core.VlcMediaPlayerStoppedEventArgs e)
        {
#if !NET20
            myLblState.InvokeIfRequired(l => l.Text = "Stopped");
#else
            ControlExtensions.InvokeIfRequired(myLblState, c => c.Text = "Stopped");
#endif
        }

        private void OnVlcPlaying(object sender, Core.VlcMediaPlayerPlayingEventArgs e)
        {
#if !NET20
            myLblState.InvokeIfRequired(l => l.Text = "Playing");
#else
            ControlExtensions.InvokeIfRequired(myLblState, c => c.Text = "Playing");
#endif
        }

    }
}
