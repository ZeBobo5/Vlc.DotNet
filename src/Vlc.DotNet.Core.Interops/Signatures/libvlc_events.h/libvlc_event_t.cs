using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    [StructLayout(LayoutKind.Explicit)]
    public struct VlcEventArg
    {
        private const int OFFSET_OF_EVENT_TYPE = 0;
        private const int OFFSET_OF_SENDER = OFFSET_OF_EVENT_TYPE + InteropsHelpers.OFFSET_LENGTH_OF_POINTER;
        private const int OFFSET_OF_MEDIA_META_CHANGED = OFFSET_OF_SENDER + InteropsHelpers.OFFSET_LENGTH_OF_POINTER;
        private const int OFFSET_OF_MEDIA_SUBITEM_ADDED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIA_DURATION_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIA_PARSED_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIA_FREED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIA_STATE_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIAPLAYER_BUFFERING = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIAPLAYER_POSITION_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIAPLAYER_TIME_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIAPLAYER_TITLE_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIAPLAYER_SEEKABLE_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIAPLAYER_PAUSABLE_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIAPLAYER_SCRAMBLED_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIAPLAYER_VIDEO_OUT_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIALIST_ITEM_ADDED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIALIST_WILL_ADD_ITEM = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIALIST_ITEM_DELETED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIALIST_WILL_DELETE_ITEM = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIALISTPLAYER_NEXT_ITEM_SET = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIAPLAYER_SNAPSHOT_TAKEN = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIAPLAYER_LENGTH_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_VLM_MEDIA_EVENT = OFFSET_OF_MEDIA_META_CHANGED;
        private const int OFFSET_OF_MEDIAPLAYER_MEDIA_CHANGED = OFFSET_OF_MEDIA_META_CHANGED;

        [FieldOffset(0)]
        public EventTypes type;

        [FieldOffset(InteropsHelpers.OFFSET_LENGTH_OF_POINTER)]
        public IntPtr p_obj;

        #region Media Descriptor

        [FieldOffset(OFFSET_OF_MEDIA_META_CHANGED)]
        public MediaMetaChanged MediaMetaChanged;

        [FieldOffset(OFFSET_OF_MEDIA_SUBITEM_ADDED)]
        public MediaSubItemAdded MediaSubItemAdded;

        [FieldOffset(OFFSET_OF_MEDIA_DURATION_CHANGED)]
        public MediaDurationChanged MediaDurationChanged;

        [FieldOffset(OFFSET_OF_MEDIA_PARSED_CHANGED)]
        public MediaParsedChanged MediaParsedChanged;

        [FieldOffset(OFFSET_OF_MEDIA_FREED)]
        public MediaFreed MediaFreed;

        [FieldOffset(OFFSET_OF_MEDIA_STATE_CHANGED)]
        public MediaStateChanged MediaStateChanged;

        [FieldOffset(OFFSET_OF_MEDIA_STATE_CHANGED)]
        public MediaSubItemTreeAdded MediaSubItemTreeAdded;

        #endregion

        #region Media Instance

        [FieldOffset(OFFSET_OF_MEDIAPLAYER_BUFFERING)]
        public MediaPlayerBuffering MediaPlayerBuffering;

        [FieldOffset(OFFSET_OF_MEDIAPLAYER_POSITION_CHANGED)]
        public MediaPlayerPositionChanged MediaPlayerPositionChanged;

        [FieldOffset(OFFSET_OF_MEDIAPLAYER_TIME_CHANGED)]
        public MediaPlayerTimeChanged MediaPlayerTimeChanged;

        [FieldOffset(OFFSET_OF_MEDIAPLAYER_TITLE_CHANGED)]
        public MediaPlayerTitleChanged MediaPlayerTitleChanged;

        [FieldOffset(OFFSET_OF_MEDIAPLAYER_SEEKABLE_CHANGED)]
        public MediaPlayerSeekableChanged MediaPlayerSeekableChanged;

        [FieldOffset(OFFSET_OF_MEDIAPLAYER_PAUSABLE_CHANGED)]
        public MediaPlayerPausableChanged MediaPlayerPausableChanged;

        [FieldOffset(OFFSET_OF_MEDIAPLAYER_SCRAMBLED_CHANGED)]
        public MediaPlayerScrambledChanged MediaPlayerScrambledChanged;

        [FieldOffset(OFFSET_OF_MEDIAPLAYER_VIDEO_OUT_CHANGED)]
        public MediaPlayerVideoOutChanged MediaPlayerVideoOutChanged;

        #endregion

        #region Media List

        [FieldOffset(OFFSET_OF_MEDIALIST_ITEM_ADDED)]
        public MediaListItemAdded MediaListItemAdded;

        [FieldOffset(OFFSET_OF_MEDIALIST_WILL_ADD_ITEM)]
        public MediaListWillAddItem MediaListWillAddItem;

        [FieldOffset(OFFSET_OF_MEDIALIST_ITEM_DELETED)]
        public MediaListItemDeleted MediaListItemDeleted;

        [FieldOffset(OFFSET_OF_MEDIALIST_WILL_DELETE_ITEM)]
        public MediaListWillDeleteItem MediaListWillDeleteItem;

        #endregion

        [FieldOffset(OFFSET_OF_MEDIALISTPLAYER_NEXT_ITEM_SET)]
        public MediaListPlayerNextItemSet MediaListPlayerNextItemSet;

        [FieldOffset(OFFSET_OF_MEDIAPLAYER_SNAPSHOT_TAKEN)]
        public MediaPlayerSnapshotTaken MediaPlayerSnapshotTaken;

        [FieldOffset(OFFSET_OF_MEDIAPLAYER_LENGTH_CHANGED)]
        public MediaPlayerLengthChanged MediaPlayerLengthChanged;

        [FieldOffset(OFFSET_OF_VLM_MEDIA_EVENT)]
        public VlmMediaEvent VlmMediaEvent;

        [FieldOffset(OFFSET_OF_MEDIAPLAYER_MEDIA_CHANGED)]
        public MediaPlayerMediaChanged MediaPlayerMediaChanged;
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
