using System;
using System.IO;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed partial class VlcMedia : IDisposable
    {
        internal IntPtr MediaInstance { get; private set; }
        private VlcMediaPlayer myVlcMediaPlayer;

        public VlcMedia(VlcMediaPlayer player, FileInfo file, params string[] options)
        {
            MediaInstance = player.Manager.CreateNewMediaFromPath(player.Manager.VlcInstance, file.FullName);
            player.Manager.AddOptionToMedia(MediaInstance, options);
            myVlcMediaPlayer = player;
            myVlcMediaPlayer.Medias.Add(this);
            RegisterEvents();
        }
        public VlcMedia(VlcMediaPlayer player, Uri uri, params string[] options)
        {
            MediaInstance = player.Manager.CreateNewMediaFromLocation(player.Manager.VlcInstance, uri.ToString());
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
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaDurationChanged, myOnMediaDurationChangedInternalEventCallback = new EventCallback(OnMediaDurationChangedInternal));
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaFreed, myOnMediaFreedInternalEventCallback = new EventCallback(OnMediaFreedInternal));
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaMetaChanged, myOnMediaMetaChangedInternalEventCallback = new EventCallback(OnMediaMetaChangedInternal));
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaParsedChanged, myOnMediaParsedChangedInternalEventCallback = new EventCallback(OnMediaParsedChangedInternal));
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaStateChanged, myOnMediaStateChangedInternalEventCallback = new EventCallback(OnMediaStateChangedInternal));
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaSubItemAdded, myOnMediaSubItemAddedInternalEventCallback = new EventCallback(OnMediaSubItemAddedInternal));
            myVlcMediaPlayer.Manager.AttachEvent(eventManager, EventTypes.MediaSubItemTreeAdded, myOnMediaSubItemTreeAddedInternalEventCallback = new EventCallback(OnMediaSubItemTreeAddedInternal));
        }

        private void UnregisterEvents()
        {
            var eventManager = myVlcMediaPlayer.Manager.GetMediaEventManager(MediaInstance);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaDurationChanged, myOnMediaDurationChangedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaFreed, myOnMediaFreedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaMetaChanged, myOnMediaMetaChangedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaParsedChanged, myOnMediaParsedChangedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaStateChanged, myOnMediaStateChangedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaSubItemAdded, myOnMediaSubItemAddedInternalEventCallback);
            myVlcMediaPlayer.Manager.DetachEvent(eventManager, EventTypes.MediaSubItemTreeAdded, myOnMediaSubItemTreeAddedInternalEventCallback);
        }
    }
}
