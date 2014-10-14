using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures.Rincewind
{
    [StructLayout(LayoutKind.Explicit)]
    public struct VlcEventArg
    {
        [FieldOffset(0)]
        public EventTypes type;

        [FieldOffset(4)]
        public IntPtr p_obj;

        #region Media Descriptor

        [FieldOffset(8)]
        public MediaMetaChanged MediaMetaChanged;

        [FieldOffset(8)]
        public MediaSubitemAdded MediaSubItemAdded;

        [FieldOffset(8)]
        public MediaDurationChanged MediaDurationChanged;

        [FieldOffset(8)]
        public MediaParsedChanged MediaParsedChanged;

        [FieldOffset(8)]
        public MediaFreed MediaFreed;

        [FieldOffset(8)]
        public MediaStateChanged MediaStateChanged;

        [FieldOffset(8)]
        public MediaSubItemTreeAdded MediaSubItemTreeAdded;

        #endregion

        #region Media Instance

        [FieldOffset(8)]
        public MediaPlayerBuffering MediaPlayerBuffering;

        [FieldOffset(8)]
        public MediaPlayerPositionChanged MediaPlayerPositionChanged;

        [FieldOffset(8)]
        public MediaPlayerTimeChanged MediaPlayerTimeChanged;

        [FieldOffset(8)]
        public MediaPlayerTitleChanged MediaPlayerTitleChanged;

        [FieldOffset(8)]
        public MediaPlayerSeekableChanged MediaPlayerSeekableChanged;

        [FieldOffset(8)]
        public MediaPlayerPausableChanged MediaPlayerPausableChanged;

        [FieldOffset(8)]
        public MediaPlayerScrambledChanged MediaPlayerScrambledChanged;

        [FieldOffset(8)]
        public MediaPlayerVideoOutChanged MediaPlayerVideoOutChanged;

        #endregion

        #region Media List

        [FieldOffset(8)]
        public MediaListItemAdded MediaListItemAdded;

        [FieldOffset(8)]
        public MediaListWillAddItem MediaListWillAddItem;

        [FieldOffset(8)]
        public MediaListItemDeleted MediaListItemDeleted;

        [FieldOffset(8)]
        public MediaListWillDeleteItem MediaListWillDeleteItem;

        #endregion

        [FieldOffset(8)]
        public MediaListPlayerNextItemSet MediaListPlayerNextItemSet;

        [FieldOffset(8)]
        public MediaPlayerSnapshotTaken MediaPlayerSnapshotTaken;

        [FieldOffset(8)]
        public MediaPlayerLengthChanged MediaPlayerLengthChanged;

        [FieldOffset(8)]
        public VlmMediaEvent VlmMediaEvent;

        [FieldOffset(8)]
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
