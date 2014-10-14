using System;
using System.IO;
using System.Windows.Forms;

namespace Vlc.DotNet.Forms.Samples
{
    public partial class Samples : Form
    {
        public Samples()
        {
            InitializeComponent();
            //vlcRincewindControl1.Play(new FileInfo(@"D:\Mashur & Kevlar - Alone (I Am Robot Flip).mp3"));
            vlcRincewindControl1.Play(new FileInfo(@"D:\# Perso\Vidéos\Game of Thrones S04E10 FASTSUB VOSTFR 720p HTDV x264 - LIBFT.mkv"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void vlcRincewindControl1_PositionChanged(object sender, Core.Rincewind.VlcMediaPlayerPositionChangedEventArgs e)
        {
            //label1.InvokeIfRequired(l => l.Text = "Position: " + e.NewPosition.ToString());
        }
    }
#if !NET20
    public static class ControlExtensions
    {
        public static T InvokeIfRequired<T>(this T source, Action<T> action)
            where T : Control
        {
            if (!source.InvokeRequired)
                action(source);
            else
                source.Invoke(new Action(() => action(source)));
            return source;

        }
    }
#endif
}
