using System.Windows.Forms.Integration;

namespace Vlc.DotNet.Wpf
{
    public class VlcControl : WindowsFormsHost
    {
        public Forms.VlcControl MediaPlayer { get; }

        public VlcControl()
        {
            MediaPlayer = new Forms.VlcControl();
            this.Child = MediaPlayer; 
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Child = null;
                this.MediaPlayer.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}