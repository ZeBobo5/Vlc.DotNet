using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Set the subtitle delay.
    /// </summary>
    [LibVlcFunction("libvlc_video_set_spu_delay")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetVideoSpuDelay(IntPtr mediaPlayerInstance, long delay);
}
