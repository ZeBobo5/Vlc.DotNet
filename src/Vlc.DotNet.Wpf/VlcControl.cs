using System;
using System.Windows.Forms.Integration;
using System.Windows.Controls;

namespace Vlc.DotNet.Wpf
{
    public class VlcControl : UserControl, IDisposable
    {
        public Forms.VlcControl MediaPlayer { get; private set; }

        private WindowsFormsHost _host;
        private Border _border;

        public VlcControl()
        {
            _border = new Border();
            _host = new WindowsFormsHost();
            MediaPlayer = new Forms.VlcControl();
            _host.Child = MediaPlayer;
            _border.Child = _host;
            Content = _border;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _border.Child = null;
                    _host.Dispose();
                }
                disposedValue = true;
            }
        }

        ~VlcControl()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}