using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetTime(IntPtr mediaInstance, long timeInMs)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            GetInteropDelegate<SetTime>().Invoke(mediaInstance, timeInMs);
        }
    }
}