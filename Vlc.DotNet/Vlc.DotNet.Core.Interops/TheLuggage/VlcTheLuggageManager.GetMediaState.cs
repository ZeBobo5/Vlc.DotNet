using System;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcTheLuggageManager
    {
        public MediaStates GetMediaState(IntPtr mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            return GetInteropDelegate<GetMediaState>().Invoke(mediaInstance);
        }
    }
}
