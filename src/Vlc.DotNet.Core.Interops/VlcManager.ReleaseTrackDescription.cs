using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void ReleaseTrackDescription(TrackDescriptionStructure trackDescription)
        {
            GetInteropDelegate<ReleaseTrackDescription>().Invoke(trackDescription);
        }
    }
}
