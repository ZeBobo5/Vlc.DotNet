using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;
using Vlc.DotNet.Forms;

using System.Linq;
using System.Collections.Generic;

namespace Samples.WinForms.Advanced
{
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();

            if (myVlcControl.Audio != null)
            {
                var outputs = myVlcControl.Audio.Outputs;
                if (outputs != null)
                {

                    myCbxAudioOutputs.DataSource = new List<AudioOutputDescription>(outputs.All);
                    myCbxAudioOutputs.DisplayMember = "Description";
                    myCbxAudioOutputs.Enabled = true;
                    myCbxAudioOutputs.SelectedIndex = -1;
                    myCbxAudioOutputs.SelectedValueChanged += (o, a) =>
                    {
                        var val = myCbxAudioOutputs.SelectedValue;
                        if (val != null)
                        {
                            var output = val as AudioOutputDescription;
                            if (output != null)
                            {
                                outputs.Current = output;
                            }
                        }
                    };

                }
            }
        }

        /// <summary>
        /// When the Vlc control needs to find the location of the libvlc.dll.
        /// You could have set the VlcLibDirectory in the designer, but for this sample, we are in AnyCPU mode, and we don't know the process bitness.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnVlcControlNeedLibDirectory(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new FolderBrowserDialog();
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
            myVlcControl.Play(new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));
            //myVlcControl.Play(new FileInfo(@"..\..\..\Vlc.DotNet\Samples\Videos\BBB trailer.mov"));
        }

        private void OnButtonStopClicked(object sender, EventArgs e)
        {
            myVlcControl.Stop();
        }

        private void OnButtonPauseClicked(object sender, EventArgs e)
        {
            myVlcControl.Pause();
        }

        private void OnVlcMediaLengthChanged(object sender, VlcMediaPlayerLengthChangedEventArgs e)
        {
            myLblMediaLength.InvokeIfRequired(l => l.Text = TimeSpan.FromMilliseconds(e.NewLength).ToString(@"hh\:mm\:ss"));
        }

        private void OnVlcTimeChanged(object sender, VlcMediaPlayerTimeChangedEventArgs e)
        {
            myLblVlcPosition.InvokeIfRequired(l => l.Text = TimeSpan.FromMilliseconds(e.NewTime).ToString(@"hh\:mm\:ss"));
        }

        private void OnVlcPaused(object sender, VlcMediaPlayerPausedEventArgs e)
        {
            myLblState.InvokeIfRequired(l => l.Text = "Paused");
        }

        private void OnVlcStopped(object sender, VlcMediaPlayerStoppedEventArgs e)
        {
            myLblState.InvokeIfRequired(l => l.Text = "Stopped");

            myCbxAspectRatio.InvokeIfRequired(c =>
            {
                c.Text = string.Empty;
                c.Enabled = false;
            });
            ControlExtensions.InvokeIfRequired(myLblAudioCodec, c => c.Text = "Codec: ");
            ControlExtensions.InvokeIfRequired(myLblAudioChannels, c => c.Text = "Channels: ");
            ControlExtensions.InvokeIfRequired(myLblAudioRate, c => c.Text = "Rate: ");
            ControlExtensions.InvokeIfRequired(myLblVideoCodec, c => c.Text = "Codec: ");
            ControlExtensions.InvokeIfRequired(myLblVideoHeight, c => c.Text = "Height: ");
            ControlExtensions.InvokeIfRequired(myLblVideoWidth, c => c.Text = "Width: ");
        }

        private void OnVlcPlaying(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            myLblState.InvokeIfRequired(l => l.Text = "Playing");

            myLblAudioCodec.InvokeIfRequired(l => l.Text = "Codec: ");
            myLblAudioChannels.InvokeIfRequired(l => l.Text = "Channels: ");
            myLblAudioRate.InvokeIfRequired(l => l.Text = "Rate: ");
            myLblVideoCodec.InvokeIfRequired(l => l.Text = "Codec: ");
            myLblVideoHeight.InvokeIfRequired(l => l.Text = "Height: ");
            myLblVideoWidth.InvokeIfRequired(l => l.Text = "Width: ");

            var mediaInformations = myVlcControl.GetCurrentMedia().Tracks;
            foreach (var mediaInformation in mediaInformations)
            {
                if (mediaInformation.Type == MediaTrackTypes.Audio)
                {
                    myLblAudioCodec.InvokeIfRequired(l => l.Text += FourCCConverter.FromFourCC(mediaInformation.CodecFourcc));
                    var audioTrack = mediaInformation.TrackInfo as AudioTrack;
                    myLblAudioChannels.InvokeIfRequired(l => l.Text += audioTrack?.Channels.ToString() ?? "null");
                    myLblAudioRate.InvokeIfRequired(l => l.Text += audioTrack?.Rate.ToString() ?? "null");
                }
                else if (mediaInformation.Type == MediaTrackTypes.Video)
                {
                    myLblVideoCodec.InvokeIfRequired(l => l.Text += FourCCConverter.FromFourCC(mediaInformation.CodecFourcc));
                    var videoTrack = mediaInformation.TrackInfo as VideoTrack;
                    myLblVideoHeight.InvokeIfRequired(l => l.Text += videoTrack?.Height.ToString() ?? "null");
                    myLblVideoWidth.InvokeIfRequired(l => l.Text += videoTrack?.Width.ToString() ?? "null");
                }
                else if (mediaInformation.Type == MediaTrackTypes.Text)
                {
                    myLblVideoCodec.InvokeIfRequired(l => l.Text += FourCCConverter.FromFourCC(mediaInformation.CodecFourcc));
                    var subtitleTrack = mediaInformation.TrackInfo as SubtitleTrack;
                    myLblVideoHeight.InvokeIfRequired(l => l.Text += subtitleTrack?.Encoding);
                }
            }

            myCbxAspectRatio.InvokeIfRequired(c =>
            {
                c.Text = myVlcControl.Video.AspectRatio;
                c.Enabled = true;
            });
        }

        private void myCbxAspectRatio_TextChanged(object sender, EventArgs e)
        {
            myVlcControl.Video.AspectRatio = myCbxAspectRatio.Text;
            ResizeVlcControl();
        }

        private void Sample_SizeChanged(object sender, EventArgs e)
        {
            ResizeVlcControl();
        }

        void ResizeVlcControl()
        {
            if (!string.IsNullOrEmpty(myCbxAspectRatio.Text))
            {
                var ratio = myCbxAspectRatio.Text.Split(':');
                int width, height;
                if (ratio.Length == 2 && int.TryParse(ratio[0], out width) && int.TryParse(ratio[1], out height))
                    myVlcControl.Width = myVlcControl.Height * width / height;
            }
        }

        private void OnVlcMediaPlayerLog(object sender, VlcMediaPlayerLogEventArgs e)
        {
            string message = string.Format("libVlc : {0} {1} @ {2}", e.Level, e.Message, e.Module);
            System.Diagnostics.Debug.WriteLine(message);
        }

        private void myVlcControl_MouseEnter(object sender, EventArgs e)
        {
            myLblMouseOnCtl.Text = "Mouse On VlcControl: On";
        }

        private void myVlcControl_MouseLeave(object sender, EventArgs e)
        {
            myLblMouseOnCtl.Text = "Mouse On VlcControl: Off";
        }

        private void myVlcControl_KeyDown(object sender, KeyEventArgs e)
        {
            myLblKeyDown.Text = "Key Down: true";
        }

        private void myVlcControl_KeyUp(object sender, KeyEventArgs e)
        {
            myLblKeyDown.Text = "Key Down: false";
        }

        private void myVlcControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            myLblKeyCode.Text = "Key: " + e.KeyChar.ToString();
        }

        private void myVlcControl_MouseClick(object sender, MouseEventArgs e)
        {
            myVlcControl.Focus();            
        }

        private void myVlcControl_MouseDown(object sender, MouseEventArgs e)
        {
            myLblMouseState.Text = "Mouse State: Button Down";
        }

        private void myVlcControl_MouseUp(object sender, MouseEventArgs e)
        {
            myLblMouseState.Text = "Mouse State: Button Up";
        }

        private void myBtnDisableMouseEvents_Click(object sender, EventArgs e)
        {
            myVlcControl.Video.IsMouseInputEnabled = false;
            myVlcControl.Video.IsKeyInputEnabled = false;

        }

        private void myBtnEnableMouseEvents_Click(object sender, EventArgs e)
        {
            myVlcControl.Video.IsMouseInputEnabled= true;
            myVlcControl.Video.IsKeyInputEnabled = true;
        }
    }
}
