using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public MediaStatsStructure GetMediaStats(VlcMediaInstance mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            var result = new MediaStatsStructure();
            GetInteropDelegate<GetMediaStats>().Invoke(mediaInstance, out result);
            return result;
        }
    }
}
