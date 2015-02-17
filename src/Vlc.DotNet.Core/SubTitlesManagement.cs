using System.Collections.Generic;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    internal sealed class SubTitlesManagement : ISubTitlesManagement, IEnumerableManagement<TrackDescription>
    {
        private readonly VlcManager myManager;
        private readonly VlcMediaPlayerInstance myMediaPlayer;

        public SubTitlesManagement(VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance)
        {
            myManager = manager;
            myMediaPlayer = mediaPlayerInstance;
        }

        public int Count
        {
            get { return myManager.GetVideoSpuCount(myMediaPlayer); }
        }

        public IEnumerable<TrackDescription> All
        {
            get
            {
                var module = myManager.GetVideoSpuDescription(myMediaPlayer);
                var result = TrackDescription.GetSubTrackDescription(module);
                myManager.ReleaseTrackDescription(module);
                return result;
            }
        }


        public TrackDescription Current
        {
            get
            {
                var currentId = myManager.GetVideoSpu(myMediaPlayer);
                foreach (var availableSubTitle in All)
                {
                    if (availableSubTitle.ID == currentId)
                        return availableSubTitle;
                }
                return null;
            }
            set { myManager.SetVideoSpu(myMediaPlayer, value.ID); }
        }

        public long Delay
        {
            get { return myManager.GetVideoSpuDelay(myMediaPlayer); }
            set { myManager.SetVideoSpuDelay(myMediaPlayer, value); }
        }
    }
}
