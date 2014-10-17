using System;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcTheLuggageManager
    {
        public void ParseMedia(IntPtr mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            GetInteropDelegate<ParseMedia>().Invoke(mediaInstance);
        }
    }
}
