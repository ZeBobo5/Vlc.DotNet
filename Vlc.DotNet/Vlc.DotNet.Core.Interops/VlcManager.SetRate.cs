using System;
using System.Runtime.InteropServices;
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public bool SetRate(IntPtr mediaInstance, float rate)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            bool blah= GetInteropDelegate<SetRate>().Invoke(mediaInstance, rate) == 0;

            return blah;
        }
    }
}
