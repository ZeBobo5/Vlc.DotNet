using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Forms;

namespace Samples.WinForms.MultiplePlayers
{
    public partial class Form1 : Form
    {
        private readonly List<VlcControl> listOfControls = new List<VlcControl>();
        private const string StreamParams = ":network-caching=2000";
        private const string MyVlcLibraryPath = @"C:\Program Files (x86)\VideoLAN\VLC";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            this.AddPlayer();
        }

        private void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            this.RemovePlayer();
        }

        private void AddPlayer()
        {
            lock (listOfControls)
            {
                // Create a player instance.
                var player = new VlcControl();
                HookEvents(player);
                player.VlcLibDirectory = new DirectoryInfo(MyVlcLibraryPath);
                player.EndInit();
                player.Size = new Size(200, 200);

                // Add player to the panel.
                this.panel.Controls.Add(player);

                // Tell the player to play
                player.SetMedia(this.textBox1.Text, Form1.StreamParams);
                player.Play();
                player.Audio.IsMute = true;

                // Add to a list
                listOfControls.Add(player);
            }
        }

        private void RemovePlayer()
        {
            lock (listOfControls)
            {
                if (!listOfControls.Any()) return;

                var player = listOfControls[0];

                // Remove player from the list
                listOfControls.Remove(player);

                // Dispose player
                UnhookEvents(player);
                player.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lock (listOfControls)
            {
                if (!listOfControls.Any()) return;

                var player = listOfControls[0];

                // Call stop to this player.
                player.Stop();
            }
        }
        
        private void HookEvents(VlcControl player)
        {
            player.EndReached += PlayerOnEndReached;
            player.EncounteredError += Player_EncounteredError;
            player.Buffering += PlayerOnBuffering;
            player.Playing += PlayerOnPlaying;
            player.TimeChanged +=  PlayerOnTimeChanged;
            player.Opening += PlayerOnOpening;
        }

        private void UnhookEvents(VlcControl player)
        {
            player.EndReached -= PlayerOnEndReached;
            player.EncounteredError -= Player_EncounteredError;
            player.Buffering -= PlayerOnBuffering;
            player.Playing -= PlayerOnPlaying;
            player.TimeChanged -=  PlayerOnTimeChanged;
            player.Opening -= PlayerOnOpening;
        }

        private void Player_EncounteredError(object sender, VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            // On error, try to restart it.
            Console.WriteLine("Error " + e);

            if (!(sender is VlcControl player)) return;

            Task.Run(() =>
            {
                //player.SetMedia(this.textBox1.Text, " :network-caching=2000");
                player.Play(this.textBox1.Text, Form1.StreamParams);
            });
        }

        private void PlayerOnEndReached(object sender, VlcMediaPlayerEndReachedEventArgs e)
        {
            // On endReached, restart player.
            if (!(sender is VlcControl player)) return;

            Task.Run(() =>
            {
                //player.SetMedia(this.textBox1.Text, " :network-caching=2000");
                player.Play(this.textBox1.Text, Form1.StreamParams);
            });
        }

        private void PlayerOnBuffering(object sender, VlcMediaPlayerBufferingEventArgs e)
        {
            Console.WriteLine("PlayerOnBuffering: " + e.NewCache);
        }

        private void PlayerOnPlaying(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            Console.WriteLine("PlayerOnPlaying");
        }

        private void PlayerOnTimeChanged(object sender, VlcMediaPlayerTimeChangedEventArgs e)
        {
            
        }

        private void PlayerOnOpening(object sender, VlcMediaPlayerOpeningEventArgs e)
        {
            Console.WriteLine("PlayerOnOpening");
        }
    }
}
