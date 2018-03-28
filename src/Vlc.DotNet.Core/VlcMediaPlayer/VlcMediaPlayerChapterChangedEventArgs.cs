using System;

namespace Vlc.DotNet.Core
{
    public class VlcMediaPlayerChapterChangedEventArgs : EventArgs
    {
        private int NewChapter { get; }

        public VlcMediaPlayerChapterChangedEventArgs(int newChapter)
        {
            this.NewChapter = newChapter;
        }
    }
}