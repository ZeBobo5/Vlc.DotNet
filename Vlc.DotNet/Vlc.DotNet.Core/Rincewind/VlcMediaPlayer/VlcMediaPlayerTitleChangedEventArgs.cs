using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerTitleChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerTitleChangedEventArgs(string newTitle)
        {
            NewTitle = newTitle;
        }

        public string NewTitle { get; private set; }
    }
}