using System;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    public enum EventTypes
      : int
    {
        MediaMetaChanged = 0,
        MediaSubItemAdded,
        MediaDurationChanged,
        MediaParsedChanged,
        MediaFreed,
        MediaStateChanged,
        MediaSubItemTreeAdded,

        MediaPlayerMediaChanged = 0x100,
        MediaPlayerNothingSpecial,
        MediaPlayerOpening,
        MediaPlayerBuffering,
        MediaPlayerPlaying,
        MediaPlayerPaused,
        MediaPlayerStopped,
        MediaPlayerForward,
        MediaPlayerBackward,
        MediaPlayerEndReached,
        MediaPlayerEncounteredError,
        MediaPlayerTimeChanged,
        MediaPlayerPositionChanged,
        MediaPlayerSeekableChanged,
        MediaPlayerPausableChanged,
        MediaPlayerTitleChanged,
        MediaPlayerSnapshotTaken,
        MediaPlayerLengthChanged,
        MediaPlayerVout,
        MediaPlayerScrambledChanged,
        MediaPlayerEsAdded,
        MediaPlayerEsDeleted,
        MediaPlayerEsSelected,
        MediaPlayerCorked,
        MediaPlayerUncorked,
        MediaPlayerMuted,
        MediaPlayerUnmuted,
        MediaPlayerAudioVolume,
        MediaPlayerAudioDevice,
        MediaPlayerChapterChanged,

        MediaListItemAdded = 0x200,
        MediaListWillAddItem,
        MediaListItemDeleted,
        MediaListWillDeleteItem,
        MediaListEndReached,

        MediaListViewItemAdded = 0x300,
        MediaListViewWillAddItem,
        MediaListViewItemDeleted,
        MediaListViewWillDeleteItem,

        MediaListPlayerPlayed = 0x400,
        MediaListPlayerNextItemSet,
        MediaListPlayerStopped,

        [Obsolete("Useless event, it will be triggered only when calling libvlc_media_discoverer_start()")]
        MediaDiscovererStarted = 0x500,
        [Obsolete("Useless event, it will be triggered only when calling libvlc_media_discoverer_stop()")]
        MediaDiscovererEnded,
        RendererDiscovererItemAdded,
        RendererDiscovererItemDeleted,

        VlmMediaAdded = 0x600,
        VlmMediaRemoved,
        VlmMediaChanged,
        VlmMediaInstanceStarted,
        VlmMediaInstanceStopped,
        VlmMediaInstanceStatusInit,
        VlmMediaInstanceStatusOpening,
        VlmMediaInstanceStatusPlaying,
        VlmMediaInstanceStatusPause,
        VlmMediaInstanceStatusEnd,
        VlmMediaInstanceStatusError
    }
}
