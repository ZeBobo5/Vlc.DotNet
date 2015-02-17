using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Check if media player is playing.
    /// </summary>
    [LibVlcFunction("libvlc_media_player_is_playing")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int IsPlaying(IntPtr mediaPlayerInstance);
}
