using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Forms;

namespace Samples.WinForms.MultiplePlayers
{
    public partial class Form1 : Form
    {
        // List of controls used to store those controls that will be playing
        private readonly List<VlcControl> listOfControls = new List<VlcControl>();

        // Extra parameters to pass to the viewer media. I found a 2 seconds buffer cache makes playing much more stable.
        private const string StreamParams = ":network-caching=2000";

        // My path to VLC folder. You can Set your own.
        private string vlcLibraryPath;

        // Count number of clicks on any player.
        private int numberOfClicks;

        /// <summary>
        /// Initializes a new instance of the Form1 class
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            vlcLibraryPath = Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64");
        }

        /// <summary>
        /// Button Add player handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAddPlayer_Click(object sender, EventArgs e)
        {
            await AddPlayerAsync();
        }

        /// <summary>
        /// Button Remove player handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            await RemovePlayerAsync();
        }

        /// <summary>
        /// Button to stop the first player of the list. Just for testing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            lock (listOfControls)
            {
                listOfControls.FirstOrDefault()?.Stop();
            }
        }

        /// <summary>
        /// Add one player to the panel asynchronously.
        /// </summary>
        /// <returns></returns>
        private async Task AddPlayerAsync()
        {
            await Task.Run(() =>
            {
                AutoResetEvent uiUpdated = new AutoResetEvent(false);
                var player = new VlcControl
                {
                    VlcLibDirectory = new DirectoryInfo(this.vlcLibraryPath), 
                    Size = new Size(200, 200)
                };

                panel.BeginInvoke( (MethodInvoker) delegate
                {
                    panel.Controls.Add(player);
                    player.EndInit();
                    uiUpdated.Set();
                });

                uiUpdated.WaitOne();
                
                lock (listOfControls)
                {
                    // Add to a list
                    listOfControls.Add(player);
                }

                HookEvents(player);

                // If any of the following 2 elements is true, then the vlc player itself will capture input from the user.
                // and then, the mouse click event won't fire.
                player.Video.IsMouseInputEnabled = false;
                player.Video.IsKeyInputEnabled = false;
                player.Audio.IsMute = true;

                // Tell the player to play
                player.SetMedia(textBox1.Text, StreamParams);
                player.Play();
            });
        }

        /// <summary>
        /// Removes the first player of the list asynchronously.
        /// </summary>
        /// <returns></returns>
        private async Task RemovePlayerAsync()
        {
            await Task.Run(() =>
            {
                AutoResetEvent uiUpdated = new AutoResetEvent(false);
                
                lock (listOfControls)
                {
                    // Do nothing if nothing to remove
                    if (!listOfControls.Any()) return;

                    // Pick the first player in the panel.
                    var player = listOfControls[0];

                    // Unhook events of the player
                    UnhookEvents(player);

                    // Remove player from the Panel in the Ui thread.
                    panel.BeginInvoke( (MethodInvoker) delegate
                    {
                        // Remove the control player.
                        panel.Controls.Remove(player);

                        // Set I have finished.
                        uiUpdated.Set();
                    });

                    // wait for the panel to remove the player from the ui on its thread.
                    uiUpdated.WaitOne();
                    
                    // Remove player from the list
                    listOfControls.Remove(player);

                    // Only left to dispose the player, let the player do it on its own thread when it needs to.
                    panel.BeginInvoke( (MethodInvoker) delegate
                    {
                        player.Dispose();
                    });
                }
            });
        }
        
        /// <summary>
        /// Hook to some events of the given player.
        /// </summary>
        private void HookEvents(VlcControl player)
        {
            // hook to whatever you need, but remember to unhook it too.
            player.EndReached += PlayerOnEndReached;
            player.EncounteredError += Player_EncounteredError;
            player.Buffering += PlayerOnBuffering;
            player.Playing += PlayerOnPlaying;
            player.TimeChanged +=  PlayerOnTimeChanged;
            player.Opening += PlayerOnOpening;
            player.MouseClick += PlayerOnMouseClick;
        }

        /// <summary>
        /// Unhook to some events of the given player.
        /// </summary>
        private void UnhookEvents(VlcControl player)
        {
            player.EndReached -= PlayerOnEndReached;
            player.EncounteredError -= Player_EncounteredError;
            player.Buffering -= PlayerOnBuffering;
            player.Playing -= PlayerOnPlaying;
            player.TimeChanged -=  PlayerOnTimeChanged;
            player.Opening -= PlayerOnOpening;
            player.MouseClick -= PlayerOnMouseClick;
        }
        
        /// <summary>
        /// Event handler for mouse click on player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerOnMouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(@"Click = " + numberOfClicks++);
            
        }

        /// <summary>
        /// Event handler for error on player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player_EncounteredError(object sender, VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            // On error, try to restart it.
            Console.WriteLine(@"Error " + e);

            if (!(sender is VlcControl player)) return;

            Task.Run(() =>
            {
                //player.SetMedia(this.textBox1.Text, " :network-caching=2000");
                player.Play(textBox1.Text, StreamParams);
            });
        }

        /// <summary>
        /// Event handler for end reached on player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerOnEndReached(object sender, VlcMediaPlayerEndReachedEventArgs e)
        {
            // On endReached, restart player.
            if (!(sender is VlcControl player)) return;

            Task.Run(() =>
            {
                //player.SetMedia(this.textBox1.Text, " :network-caching=2000");
                player.Play(textBox1.Text, StreamParams);
            });
        }

        /// <summary>
        /// Event handler for player buffering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerOnBuffering(object sender, VlcMediaPlayerBufferingEventArgs e)
        {
            Console.WriteLine(@"PlayerOnBuffering: " + e.NewCache);
        }

        /// <summary>
        /// Event handler for player start playing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerOnPlaying(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            Console.WriteLine(@"PlayerOnPlaying");
        }

        /// <summary>
        /// Event handler for Time changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerOnTimeChanged(object sender, VlcMediaPlayerTimeChangedEventArgs e)
        {
            // I don't print this to keep console "clean".
            //Console.WriteLine(@"PlayerOnPlaying");
        }

        /// <summary>
        /// Event handler for player opening.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerOnOpening(object sender, VlcMediaPlayerOpeningEventArgs e)
        {
            Console.WriteLine(@"PlayerOnOpening");
        }
    }
}
