using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer : IDisposable
    {
        private VlcMediaPlayerInstance myMediaPlayerInstance;

        public VlcMediaPlayer(DirectoryInfo vlcLibDirectory)
            : this(VlcManager.GetInstance(vlcLibDirectory))
        {
        }

        public VlcMediaPlayer(DirectoryInfo vlcLibDirectory, string[] options)
            : this(VlcManager.GetInstance(vlcLibDirectory), options)
        {
        }

        internal VlcMediaPlayer(VlcManager manager)
        {
            Manager = manager;
#if DEBUG
            Manager.CreateNewInstance(new[]
            {
                "--extraintf=logger",
                "--verbose=2"
            });
#else
            Manager.CreateNewInstance(new[]
            {
                "--quiet"
            });
#endif
            myMediaPlayerInstance = manager.CreateMediaPlayer();
            RegisterEvents();
            Chapters = new ChapterManagement(manager, myMediaPlayerInstance);
            SubTitles = new SubTitlesManagement(manager, myMediaPlayerInstance);
            Video = new VideoManagement(manager, myMediaPlayerInstance);
            Audio = new AudioManagement(manager, myMediaPlayerInstance);
        }

        internal VlcMediaPlayer(VlcManager manager, string[] options)
        {
            Manager = manager;
            Manager.CreateNewInstance(options);

            myMediaPlayerInstance = manager.CreateMediaPlayer();
            RegisterEvents();
            Chapters = new ChapterManagement(manager, myMediaPlayerInstance);
            SubTitles = new SubTitlesManagement(manager, myMediaPlayerInstance);
            Video = new VideoManagement(manager, myMediaPlayerInstance);
            Audio = new AudioManagement(manager, myMediaPlayerInstance);
        }

        internal VlcManager Manager { get; private set; }

        public IntPtr VideoHostControlHandle
        {
            get { return Manager.GetMediaPlayerVideoHostHandle(myMediaPlayerInstance); }
            set { Manager.SetMediaPlayerVideoHostHandle(myMediaPlayerInstance, value); }
        }

        private void ResetFromMedia()
        {
            UnregisterEvents();
            if (VideoHostControlHandle != IntPtr.Zero)
            {
                var ctrl = Control.FromHandle(VideoHostControlHandle);
                if (ctrl != null && ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new ResetFromMediaCoreDelegate(ResetFromMediaCore), ctrl);
                }
                else
                {
                    ResetFromMediaCore(ctrl);
                }
            }
            else
            {
                ResetFromMediaCore(null);
            }
        }

        private delegate void ResetFromMediaCoreDelegate(Control ctrl);

        private void ResetFromMediaCore(Control ctrl)
        {
            VideoHostControlHandle = IntPtr.Zero;
            var mediaInstance = GetMedia().MediaInstance;
            if (ctrl != null)
                ctrl.GetType().GetMethod("RecreateHandle", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(ctrl, null);
            myMediaPlayerInstance.Pointer = IntPtr.Zero;
            myMediaPlayerInstance = Manager.CreateMediaPlayerFromMedia(mediaInstance);
            RegisterEvents();
            Chapters = new ChapterManagement(Manager, myMediaPlayerInstance);
            SubTitles = new SubTitlesManagement(Manager, myMediaPlayerInstance);
            Video = new VideoManagement(Manager, myMediaPlayerInstance);
            Audio = new AudioManagement(Manager, myMediaPlayerInstance);
            if (ctrl != null)
                VideoHostControlHandle = ctrl.Handle;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (myMediaPlayerInstance == IntPtr.Zero)
                return;
            UnregisterEvents();
            if (IsPlaying())
                Stop();

            if (VlcMedia.LoadedMedias.ContainsKey(this))
            foreach (var loadedMedia in VlcMedia.LoadedMedias[this])
            {
                loadedMedia.Dispose();
            }
            VlcMedia.LoadedMedias[this] = new List<VlcMedia>();

            myMediaPlayerInstance.Dispose();
            Manager.Dispose();
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

        public VlcMedia SetMedia(string mrl, params string[] options)
        {
            return SetMedia(new VlcMedia(this, mrl, options));
        }

        private VlcMedia SetMedia(VlcMedia media)
        {
            var currentMedia = GetMedia();
            if (currentMedia != null && currentMedia.MediaInstance != media.MediaInstance)
                currentMedia.Dispose();
            Manager.SetMediaToMediaPlayer(myMediaPlayerInstance, media.MediaInstance);
            return media;
        }

        public VlcMedia GetMedia()
        {
            var mediaPtr = Manager.GetMediaFromMediaPlayer(myMediaPlayerInstance);
            if (mediaPtr.Pointer != IntPtr.Zero)
                return new VlcMedia(this, mediaPtr);
            return null;
        }

        public void Play()
        {
            Manager.Play(myMediaPlayerInstance);
        }

        public void Pause()
        {
            Manager.Pause(myMediaPlayerInstance);
        }

        public void Stop()
        {
            Manager.Stop(myMediaPlayerInstance);
        }

        public bool IsPlaying()
        {
            return Manager.IsPlaying(myMediaPlayerInstance);
        }

        public bool IsPausable()
        {
            return Manager.IsPausable(myMediaPlayerInstance);
        }

        public void NextFrame()
        {
            Manager.NextFrame(myMediaPlayerInstance);
        }

        public IEnumerable<FilterModuleDescription> GetAudioFilters()
        {
            var module = Manager.GetAudioFilterList();
            ModuleDescriptionStructure nextModule = (ModuleDescriptionStructure)Marshal.PtrToStructure(module, typeof(ModuleDescriptionStructure));
            var result = GetSubFilter(nextModule);
            if (module != IntPtr.Zero)
                Manager.ReleaseModuleDescriptionInstance(module);
            return result;
        }

        private List<FilterModuleDescription> GetSubFilter(ModuleDescriptionStructure module)
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
                ModuleDescriptionStructure nextModule = (ModuleDescriptionStructure)Marshal.PtrToStructure(module.NextModule, typeof(ModuleDescriptionStructure));
                var data = GetSubFilter(nextModule);
                if (data.Count > 0)
                    result.AddRange(data);
            }
            return result;
        }

        public IEnumerable<FilterModuleDescription> GetVideoFilters()
        {
            var module = Manager.GetVideoFilterList();
            ModuleDescriptionStructure nextModule = (ModuleDescriptionStructure)Marshal.PtrToStructure(module, typeof(ModuleDescriptionStructure));
            var result = GetSubFilter(nextModule);
            if (module != IntPtr.Zero)
                Manager.ReleaseModuleDescriptionInstance(module);
            return result;
        }

        public float Position
        {
            get { return Manager.GetMediaPosition(myMediaPlayerInstance); }
            set { Manager.SetMediaPosition(myMediaPlayerInstance, value); }
        }

        public bool CouldPlay
        {
            get { return Manager.CouldPlay(myMediaPlayerInstance); }
        }

        public IChapterManagement Chapters { get; private set; }

        public float Rate
        {
            get { return Manager.GetRate(myMediaPlayerInstance); }
            set { Manager.SetRate(myMediaPlayerInstance, value); }
        }

        public MediaStates State
        {
            get { return Manager.GetMediaPlayerState(myMediaPlayerInstance); }
        }

        public float FramesPerSecond
        {
            get { return Manager.GetFramesPerSecond(myMediaPlayerInstance); }
        }

        public bool IsSeekable
        {
            get { return Manager.IsSeekable(myMediaPlayerInstance); }
        }

        public void Navigate(NavigateModes navigateMode)
        {
            Manager.Navigate(myMediaPlayerInstance, navigateMode);
        }

        public ISubTitlesManagement SubTitles { get; private set; }

        public IVideoManagement Video { get; private set; }

        public IAudioManagement Audio { get; private set; }

        public long Length
        {
            get { return Manager.GetLength(myMediaPlayerInstance); }
        }

        public long Time
        {
            get { return Manager.GetTime(myMediaPlayerInstance); }
            set { Manager.SetTime(myMediaPlayerInstance, value); }
        }

        public int Spu
        {
            get { return Manager.GetVideoSpu(myMediaPlayerInstance); }
            set { Manager.SetVideoSpu(myMediaPlayerInstance, value); }
        }

        public void TakeSnapshot(FileInfo file)
        {
            TakeSnapshot(file, 0, 0);
        }
        public void TakeSnapshot(FileInfo file, uint width, uint height)
        {
            Manager.TakeSnapshot(myMediaPlayerInstance, file, width, height);
        }

        private void RegisterEvents()
        {
            var vlcEventManager = Manager.GetMediaPlayerEventManager(myMediaPlayerInstance);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerBackward, myOnMediaPlayerBackwardInternalEventCallback = OnMediaPlayerBackwardInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerBuffering, myOnMediaPlayerBufferingInternalEventCallback = OnMediaPlayerBufferingInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerEncounteredError, myOnMediaPlayerEncounteredErrorInternalEventCallback = OnMediaPlayerEncounteredErrorInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerEndReached, myOnMediaPlayerEndReachedInternalEventCallback = OnMediaPlayerEndReachedInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerForward, myOnMediaPlayerForwardInternalEventCallback = OnMediaPlayerForwardInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerLengthChanged, myOnMediaPlayerLengthChangedInternalEventCallback = OnMediaPlayerLengthChangedInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerMediaChanged, myOnMediaPlayerMediaChangedInternalEventCallback = OnMediaPlayerMediaChangedInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerOpening, myOnMediaPlayerOpeningInternalEventCallback = OnMediaPlayerOpeningInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerPausableChanged, myOnMediaPlayerPausableChangedInternalEventCallback = OnMediaPlayerPausableChangedInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerPaused, myOnMediaPlayerPausedInternalEventCallback = OnMediaPlayerPausedInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerPlaying, myOnMediaPlayerPlayingInternalEventCallback = OnMediaPlayerPlayingInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerPositionChanged, myOnMediaPlayerPositionChangedInternalEventCallback = OnMediaPlayerPositionChangedInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerScrambledChanged, myOnMediaPlayerScrambledChangedInternalEventCallback = OnMediaPlayerScrambledChangedInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerSeekableChanged, myOnMediaPlayerSeekableChangedInternalEventCallback = OnMediaPlayerSeekableChangedInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerSnapshotTaken, myOnMediaPlayerSnapshotTakenInternalEventCallback = OnMediaPlayerSnapshotTakenInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerStopped, myOnMediaPlayerStoppedInternalEventCallback = OnMediaPlayerStoppedInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerTimeChanged, myOnMediaPlayerTimeChangedInternalEventCallback = OnMediaPlayerTimeChangedInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerTitleChanged, myOnMediaPlayerTitleChangedInternalEventCallback = OnMediaPlayerTitleChangedInternal);
            Manager.AttachEvent(vlcEventManager, EventTypes.MediaPlayerVout, myOnMediaPlayerVideoOutChangedInternalEventCallback = OnMediaPlayerVideoOutChangedInternal);
            vlcEventManager.Dispose();
        }

        private void UnregisterEvents()
        {
            var vlcEventManager = Manager.GetMediaPlayerEventManager(myMediaPlayerInstance);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerBackward, myOnMediaPlayerBackwardInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerBuffering, myOnMediaPlayerBufferingInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerEncounteredError, myOnMediaPlayerEncounteredErrorInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerEndReached, myOnMediaPlayerEndReachedInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerForward, myOnMediaPlayerForwardInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerLengthChanged, myOnMediaPlayerLengthChangedInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerMediaChanged, myOnMediaPlayerMediaChangedInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerOpening, myOnMediaPlayerOpeningInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerPausableChanged, myOnMediaPlayerPausableChangedInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerPaused, myOnMediaPlayerPausedInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerPlaying, myOnMediaPlayerPlayingInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerPositionChanged, myOnMediaPlayerPositionChangedInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerScrambledChanged, myOnMediaPlayerScrambledChangedInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerSeekableChanged, myOnMediaPlayerSeekableChangedInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerSnapshotTaken, myOnMediaPlayerSnapshotTakenInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerStopped, myOnMediaPlayerStoppedInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerTimeChanged, myOnMediaPlayerTimeChangedInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerTitleChanged, myOnMediaPlayerTitleChangedInternalEventCallback);
            Manager.DetachEvent(vlcEventManager, EventTypes.MediaPlayerVout, myOnMediaPlayerVideoOutChangedInternalEventCallback);
            vlcEventManager.Dispose();
        }
    }
}
