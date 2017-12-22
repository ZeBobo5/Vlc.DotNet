using System;

namespace Vlc.DotNet.Core
{
    public sealed class VlcMediaPlayerTitleChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerTitleChangedEventArgs(int newTitle)
        {
            NewTitle = newTitle;
        }

        public int NewTitle { get; private set; }
    }
}