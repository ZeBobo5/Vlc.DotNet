using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    [StructLayout(LayoutKind.Explicit)]
    public struct VlcEventArg
    {
        [FieldOffset(0)]
        public EventTypes type;

#if X86
        [FieldOffset(4)]
#else
        [FieldOffset(8)]
#endif
        public IntPtr p_obj;

        #region Media Descriptor

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaMetaChanged MediaMetaChanged;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaSubitemAdded MediaSubItemAdded;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaDurationChanged MediaDurationChanged;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaParsedChanged MediaParsedChanged;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaFreed MediaFreed;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaStateChanged MediaStateChanged;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaSubItemTreeAdded MediaSubItemTreeAdded;

        #endregion

        #region Media Instance

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaPlayerBuffering MediaPlayerBuffering;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaPlayerPositionChanged MediaPlayerPositionChanged;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaPlayerTimeChanged MediaPlayerTimeChanged;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaPlayerTitleChanged MediaPlayerTitleChanged;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaPlayerSeekableChanged MediaPlayerSeekableChanged;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaPlayerPausableChanged MediaPlayerPausableChanged;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaPlayerScrambledChanged MediaPlayerScrambledChanged;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaPlayerVideoOutChanged MediaPlayerVideoOutChanged;

        #endregion

        #region Media List

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaListItemAdded MediaListItemAdded;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaListWillAddItem MediaListWillAddItem;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaListItemDeleted MediaListItemDeleted;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaListWillDeleteItem MediaListWillDeleteItem;

        #endregion

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaListPlayerNextItemSet MediaListPlayerNextItemSet;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaPlayerSnapshotTaken MediaPlayerSnapshotTaken;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaPlayerLengthChanged MediaPlayerLengthChanged;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public VlmMediaEvent VlmMediaEvent;

#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(16)]
#endif
        public MediaPlayerMediaChanged MediaPlayerMediaChanged;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaMetaChanged
    {
        public MediaMetadatas MetaType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaSubitemAdded
    {
        public IntPtr NewChild;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaDurationChanged
    {
        public long NewDuration;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaParsedChanged
    {
        public int NewStatus;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaFreed
    {
        public IntPtr MediaInstance;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaStateChanged
    {
        public MediaStates NewState;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaSubItemTreeAdded
    {
        public IntPtr MediaInstance;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerBuffering
    {
        public float NewCache;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerPositionChanged
    {
        public float NewPosition;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerTimeChanged
    {
        public long NewTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerTitleChanged
    {
        //todo : original was int : Check if ok
        public IntPtr NewTitle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerSeekableChanged
    {
        public int NewSeekable;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerPausableChanged
    {
        public int NewPausable;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerScrambledChanged
    {
        public int NewScrambled;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerVideoOutChanged
    {
        public int NewCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaListItemAdded
    {
        public IntPtr MediaInstance;
        public int Index;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaListWillAddItem
    {
        public IntPtr MediaInstance;
        public int Index;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaListItemDeleted
    {
        public IntPtr MediaInstance;
        public int Index;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaListWillDeleteItem
    {
        public IntPtr MediaInstance;
        public int Index;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaListPlayerNextItemSet
    {
        public IntPtr MediaInstance;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerSnapshotTaken
    {
        public IntPtr pszFilename;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerLengthChanged
    {
        public long NewLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VlmMediaEvent
    {
        public IntPtr pszMediaName;
        public IntPtr pszInstanceName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerMediaChanged
    {
        public IntPtr MediaInstance;
    }
}
