using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VlcEventArg
    {
        public EventTypes type;

        public IntPtr p_obj;

        public VlcEventArgUnion eventArgsUnion;

        [StructLayout(LayoutKind.Explicit)]
        public struct VlcEventArgUnion
        {
            #region Media Descriptor

            [FieldOffset(0)]
            public MediaMetaChanged MediaMetaChanged;

            [FieldOffset(0)]
            public MediaSubItemAdded MediaSubItemAdded;

            [FieldOffset(0)]
            public MediaDurationChanged MediaDurationChanged;

            [FieldOffset(0)]
            public MediaParsedChanged MediaParsedChanged;

            [FieldOffset(0)]
            public MediaFreed MediaFreed;

            [FieldOffset(0)]
            public MediaStateChanged MediaStateChanged;

            [FieldOffset(0)]
            public MediaSubItemTreeAdded MediaSubItemTreeAdded;

            #endregion

            #region Media Instance

            [FieldOffset(0)]
            public MediaPlayerBuffering MediaPlayerBuffering;

            [FieldOffset(0)]
            public MediaPlayerChapterChanged MediaPlayerChapterChanged;

            [FieldOffset(0)]
            public MediaPlayerPositionChanged MediaPlayerPositionChanged;

            [FieldOffset(0)]
            public MediaPlayerTimeChanged MediaPlayerTimeChanged;

            [FieldOffset(0)]
            public MediaPlayerTitleChanged MediaPlayerTitleChanged;

            [FieldOffset(0)]
            public MediaPlayerSeekableChanged MediaPlayerSeekableChanged;

            [FieldOffset(0)]
            public MediaPlayerPausableChanged MediaPlayerPausableChanged;

            [FieldOffset(0)]
            public MediaPlayerScrambledChanged MediaPlayerScrambledChanged;

            [FieldOffset(0)]
            public MediaPlayerVideoOutChanged MediaPlayerVideoOutChanged;

            #endregion

            #region Media List

            [FieldOffset(0)]
            public MediaListItemAdded MediaListItemAdded;

            [FieldOffset(0)]
            public MediaListWillAddItem MediaListWillAddItem;

            [FieldOffset(0)]
            public MediaListItemDeleted MediaListItemDeleted;

            [FieldOffset(0)]
            public MediaListWillDeleteItem MediaListWillDeleteItem;

            #endregion

            [FieldOffset(0)]
            public MediaListPlayerNextItemSet MediaListPlayerNextItemSet;

            [FieldOffset(0)]
            public MediaPlayerSnapshotTaken MediaPlayerSnapshotTaken;

            [FieldOffset(0)]
            public MediaPlayerLengthChanged MediaPlayerLengthChanged;

            [FieldOffset(0)]
            public VlmMediaEvent VlmMediaEvent;

            [FieldOffset(0)]
            public MediaPlayerMediaChanged MediaPlayerMediaChanged;

            [FieldOffset(0)]
            public MediaPlayerEsChanged MediaPlayerEsChanged;

            [FieldOffset(0)]
            public MediaPlayerAudioVolume MediaPlayerAudioVolume;

            [FieldOffset(0)]
            public MediaPlayerAudioDevice MediaPlayerAudioDevice;

            [FieldOffset(0)]
            public RendererDiscovererItemAdded RendererDiscovererItemAdded;

            [FieldOffset(0)]
            public RendererDiscovererItemDeleted RendererDiscovererItemDeleted;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaMetaChanged
    {
        public MediaMetadatas MetaType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaSubItemAdded
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
    public struct MediaPlayerChapterChanged
    {
        public int NewChapter;
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
        public int NewTitle;
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

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerEsChanged
    {
        public MediaTrackTypes TrackType;
        public int Id;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerAudioVolume
    {
        public float volume;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlayerAudioDevice
    {
        public IntPtr pszDevice;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RendererDiscovererItemAdded
    {
        public IntPtr item;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RendererDiscovererItemDeleted
    {
        public IntPtr item;
    }
}
