using System;
using System.IO;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMedia : IDisposable
    {
        private readonly VlcMediaPlayer myVlcMediaPlayer;

        public VlcMedia(VlcMediaPlayer player, FileInfo file, params string[] options)
        {
            MediaInstance = player.Manager.CreateNewMediaFromPath(file.FullName);
            player.Manager.AddOptionToMedia(MediaInstance, options);
            myVlcMediaPlayer = player;
            myVlcMediaPlayer.Medias.Add(this);
            RegisterEvents();
        }

        public VlcMedia(VlcMediaPlayer player, Uri uri, params string[] options)
        {
            MediaInstance = player.Manager.CreateNewMediaFromLocation(uri.ToString());
            player.Manager.AddOptionToMedia(MediaInstance, options);
            myVlcMediaPlayer = player;
            myVlcMediaPlayer.Medias.Add(this);
            RegisterEvents();
        }

        internal VlcMedia(VlcMediaPlayer player, IntPtr ptr)
        {
            MediaInstance = ptr;
            myVlcMediaPlayer = player;
            myVlcMediaPlayer.Medias.Add(this);
            RegisterEvents();
        }

        internal IntPtr MediaInstance { get; private set; }

        public string Mrl
        {
            get { return myVlcMediaPlayer.Manager.GetMediaMrl(MediaInstance); }
        }

        public MediaStates State
        {
            get { return myVlcMediaPlayer.Manager.GetMediaState(MediaInstance); }
        }

        public TimeSpan Duration
        {
            get { return new TimeSpan(myVlcMediaPlayer.Manager.GetMediaDuration(MediaInstance) * 10000); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (MediaInstance != IntPtr.Zero)
            {
                UnregisterEvents();
                myVlcMediaPlayer.Manager.ReleaseMedia(MediaInstance);
                MediaInstance = IntPtr.Zero;
            }
        }

        ~VlcMedia()
        {
            Dispose(false);
        }

        public VlcMedia Clone()
        {
            var cloned = myVlcMediaPlayer.Manager.CloneMedia(MediaInstance);
            if (cloned != IntPtr.Zero)
                return new VlcMedia(myVlcMediaPlayer, cloned);
            return null;
        }

        private void RegisterEvents()
        {
            var eventManager = myVlcMediaPlayer.Manager.GetMediaEventManager(MediaInstance);
            //myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaDurationChanged, myOnMediaDurationChangedInternalEventCallback = OnMediaDurationChangedInternal);
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaFreed, myOnMediaFreedInternalEventCallback = OnMediaFreedInternal);
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaMetaChanged, myOnMediaMetaChangedInternalEventCallback = OnMediaMetaChangedInternal);
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaParsedChanged, myOnMediaParsedChangedInternalEventCallback = OnMediaParsedChangedInternal);
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaStateChanged, myOnMediaStateChangedInternalEventCallback = OnMediaStateChangedInternal);
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaSubItemAdded, myOnMediaSubItemAddedInternalEventCallback = OnMediaSubItemAddedInternal);
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaSubItemTreeAdded, myOnMediaSubItemTreeAddedInternalEventCallback = OnMediaSubItemTreeAddedInternal);
        }

        private void UnregisterEvents()
        {
            var eventManager = myVlcMediaPlayer.Manager.GetMediaEventManager(MediaInstance);
            //myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaDurationChanged, myOnMediaDurationChangedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaFreed, myOnMediaFreedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaMetaChanged, myOnMediaMetaChangedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaParsedChanged, myOnMediaParsedChangedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaStateChanged, myOnMediaStateChangedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaSubItemAdded, myOnMediaSubItemAddedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaSubItemTreeAdded, myOnMediaSubItemTreeAddedInternalEventCallback);
        }
    }
}