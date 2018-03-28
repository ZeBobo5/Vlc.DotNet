using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerChapterChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerChapterChangedEventArgs> ChapterChanged;

        private void OnMediaPlayerChapterChangedInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaPlayerChapterChanged(args.eventArgsUnion.MediaPlayerChapterChanged.NewChapter);
        }

        public void OnMediaPlayerChapterChanged(int newChapter)
        {
            ChapterChanged?.Invoke(this, new VlcMediaPlayerChapterChangedEventArgs(newChapter));
        }
    }
}