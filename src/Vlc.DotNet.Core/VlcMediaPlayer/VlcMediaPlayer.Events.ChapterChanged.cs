using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerChapterChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerChapterChangedEventArgs> ChapterChanged;

        private void OnMediaPlayerChapterChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerChapterChanged(args.eventArgsUnion.MediaPlayerChapterChanged.NewChapter);
        }

        public void OnMediaPlayerChapterChanged(int newChapter)
        {
            ChapterChanged?.Invoke(this, new VlcMediaPlayerChapterChangedEventArgs(newChapter));
        }
    }
}