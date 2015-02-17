using System.Collections.Generic;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed class VideoTracksManagement : ITracksManagement
    {
        private readonly VlcManager myManager;
        private readonly VlcMediaPlayerInstance myMediaPlayer;

        internal VideoTracksManagement(VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance)
        {
            myManager = manager;
            myMediaPlayer = mediaPlayerInstance;
        }

        public int Count
        {
            get { return myManager.GetVideoTracksCount(myMediaPlayer); }
        }

        public TrackDescription Current
        {
            get
            {
                var currentId = myManager.GetVideoTrack(myMediaPlayer);
                foreach (var track in All)
                {
                    if (track.ID == currentId)
                        return track;
                }
                return null;
            }
            set { myManager.SetVideoTrack(myMediaPlayer, value.ID); }
        }

        public IEnumerable<TrackDescription> All
        {
            get
            {
                var module = myManager.GetVideoTracksDescriptions(myMediaPlayer);
                var result = TrackDescription.GetSubTrackDescription(module);
                myManager.ReleaseTrackDescription(module);
                return result;
            }
        }
    }
}
