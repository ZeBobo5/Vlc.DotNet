using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Navigate through DVD Menu.
    /// </summary>
    [LibVlcFunction("libvlc_media_player_navigate")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void Navigate(IntPtr mediaPlayerInstance, NavigateModes navigate);
}
