using System;

namespace Vlc.DotNet.Core.TheLuggage
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