﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer : IDisposable
    {
        private IntPtr myMediaPlayer;

        public VlcMediaPlayer(DirectoryInfo vlcLibDirectory)
            : this(VlcManager.GetInstance(vlcLibDirectory))
        {
        }

        internal VlcMediaPlayer(VlcManager manager)
        {
            Medias = new Collection<VlcMedia>();
            Manager = manager;
            Manager.CreateNewInstance(null);
            myMediaPlayer = manager.CreateMediaPlayer();
            RegisterEvents();
        }

        internal VlcManager Manager { get; private set; }
        internal Collection<VlcMedia> Medias { get; private set; }

        public IntPtr VideoHostHandle
        {
            get { return IntPtr.Zero; }
            set { Manager.SetMediaPlayerVideoHostHandle(myMediaPlayer, value); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (myMediaPlayer == IntPtr.Zero)
                return;
            if (IsPlaying())
                Stop();
            foreach (var media in Medias)
                media.Dispose();

            UnregisterEvents();
            Manager.ReleaseMediaPlayer(myMediaPlayer);
            myMediaPlayer = IntPtr.Zero;
        }

        ~VlcMediaPlayer()
        {
            Dispose(false);
        }

        public VlcMedia SetMedia(FileInfo file, params string[] options)
        {
            return SetMedia(new VlcMedia(this, file, options));
        }

        public VlcMedia SetMedia(Uri uri, params string[] options)
        {
            return SetMedia(new VlcMedia(this, uri, options));
        }

        public VlcMedia SetMedia(VlcMedia media)
        {
            Manager.SetMediaToMediaPlayer(myMediaPlayer, media.MediaInstance);
            return media;
        }

        public VlcMedia GetMedia()
        {
            var mediaPtr = Manager.GetMediaFromMediaPlayer(myMediaPlayer);
            foreach (var vlcMedia in Medias)
            {
                if (vlcMedia.MediaInstance == mediaPtr)
                    return vlcMedia;
            }
            return new VlcMedia(this, mediaPtr);
        }

        public void Play()
        {
            Manager.Play(myMediaPlayer);
        }

        public float GetRate()
        {
            return Manager.GetRate(myMediaPlayer);
        }

        public void SetRate(float rate)
        {
             Manager.SetRate(myMediaPlayer, rate);
        }

        public void Pause()
        {
            Manager.Pause(myMediaPlayer);
        }

        public void Stop()
        {
            Manager.Stop(myMediaPlayer);
        }

        public bool IsPlaying()
        {
            return Manager.IsPlaying(myMediaPlayer);
        }

        public IEnumerable<FilterModuleDescription> GetAudioFilters()
        {
            //var module = Manager.GetAudioFilterList();
            //var result = GetSubFilter(module);
            //if (module.Name != IntPtr.Zero)
            //    Manager.ReleaseModuleDescriptionInstance(module);
            //return result;
            return null;
        }

        private List<FilterModuleDescription> GetSubFilter(ModuleDescription module)
        {
            var result = new List<FilterModuleDescription>();
            var filterModule = FilterModuleDescription.GetFilterModuleDescription(module);
            if (filterModule == null)
            {
                return result;
            }
            result.Add(filterModule);
            if (module.NextModule != IntPtr.Zero)
            {
                ModuleDescription nextModule = (ModuleDescription)Marshal.PtrToStructure(module.NextModule, typeof(ModuleDescription));
                var data = GetSubFilter(nextModule);
                if (data.Count > 0)
                    result.AddRange(data);
            }
            return result;
        }

        public IEnumerable<FilterModuleDescription> GetVideoFilters()
        {
            var module = Manager.GetVideoFilterList();
            ModuleDescription nextModule = (ModuleDescription)Marshal.PtrToStructure(module, typeof(ModuleDescription));
            var result = GetSubFilter(nextModule);
            if (module != IntPtr.Zero)
                Manager.ReleaseModuleDescriptionInstance(module);
            return result;
        }

        private void RegisterEvents()
        {
            var eventManager = Manager.GetMediaPlayerEventManager(myMediaPlayer);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerBackward, myOnMediaPlayerBackwardInternalEventCallback = OnMediaPlayerBackwardInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerBuffering, myOnMediaPlayerBufferingInternalEventCallback = OnMediaPlayerBufferingInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerEncounteredError, myOnMediaPlayerEncounteredErrorInternalEventCallback = OnMediaPlayerEncounteredErrorInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerEndReached, myOnMediaPlayerEndReachedInternalEventCallback = OnMediaPlayerEndReachedInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerForward, myOnMediaPlayerForwardInternalEventCallback = OnMediaPlayerForwardInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerLengthChanged, myOnMediaPlayerLengthChangedInternalEventCallback = OnMediaPlayerLengthChangedInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerMediaChanged, myOnMediaPlayerMediaChangedInternalEventCallback = OnMediaPlayerMediaChangedInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerOpening, myOnMediaPlayerOpeningInternalEventCallback = OnMediaPlayerOpeningInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerPausableChanged, myOnMediaPlayerPausableChangedInternalEventCallback = OnMediaPlayerPausableChangedInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerPaused, myOnMediaPlayerPausedInternalEventCallback = OnMediaPlayerPausedInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerPlaying, myOnMediaPlayerPlayingInternalEventCallback = OnMediaPlayerPlayingInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerPositionChanged, myOnMediaPlayerPositionChangedInternalEventCallback = OnMediaPlayerPositionChangedInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerScrambledChanged, myOnMediaPlayerScrambledChangedInternalEventCallback = OnMediaPlayerScrambledChangedInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerSeekableChanged, myOnMediaPlayerSeekableChangedInternalEventCallback = OnMediaPlayerSeekableChangedInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerSnapshotTaken, myOnMediaPlayerSnapshotTakenInternalEventCallback = OnMediaPlayerSnapshotTakenInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerStopped, myOnMediaPlayerStoppedInternalEventCallback = OnMediaPlayerStoppedInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerTimeChanged, myOnMediaPlayerTimeChangedInternalEventCallback = OnMediaPlayerTimeChangedInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerTitleChanged, myOnMediaPlayerTitleChangedInternalEventCallback = OnMediaPlayerTitleChangedInternal);
            Manager.AttachEvent(eventManager, EventTypes.MediaPlayerVout, myOnMediaPlayerVideoOutChangedInternalEventCallback = OnMediaPlayerVideoOutChangedInternal);
        }

        private void UnregisterEvents()
        {
            var eventManager = Manager.GetMediaPlayerEventManager(myMediaPlayer);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerBackward, myOnMediaPlayerBackwardInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerBuffering, myOnMediaPlayerBufferingInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerEncounteredError, myOnMediaPlayerEncounteredErrorInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerEndReached, myOnMediaPlayerEndReachedInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerForward, myOnMediaPlayerForwardInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerLengthChanged, myOnMediaPlayerLengthChangedInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerMediaChanged, myOnMediaPlayerMediaChangedInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerOpening, myOnMediaPlayerOpeningInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerPausableChanged, myOnMediaPlayerPausableChangedInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerPaused, myOnMediaPlayerPausedInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerPlaying, myOnMediaPlayerPlayingInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerPositionChanged, myOnMediaPlayerPositionChangedInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerScrambledChanged, myOnMediaPlayerScrambledChangedInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerSeekableChanged, myOnMediaPlayerSeekableChangedInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerSnapshotTaken, myOnMediaPlayerSnapshotTakenInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerStopped, myOnMediaPlayerStoppedInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerTimeChanged, myOnMediaPlayerTimeChangedInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerTitleChanged, myOnMediaPlayerTitleChangedInternalEventCallback);
            Manager.DetachEvent(eventManager, EventTypes.MediaPlayerVout, myOnMediaPlayerVideoOutChangedInternalEventCallback);
        }
    }
}