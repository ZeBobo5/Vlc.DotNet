using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetKeyInput(VlcMediaPlayerInstance mediaPlayerInstance, bool status)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetKeyInput>().Invoke(mediaPlayerInstance, Convert.ToUInt32(status ? 1 : 0));
        }
    }
}