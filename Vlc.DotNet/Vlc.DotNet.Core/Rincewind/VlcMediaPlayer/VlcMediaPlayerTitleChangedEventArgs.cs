using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerTitleChangedEventArgs : EventArgs
    {
        public string NewTitle { get; private set; }

        public VlcMediaPlayerTitleChangedEventArgs(string newTitle)
        {
            NewTitle = newTitle;
        }
    }
}
