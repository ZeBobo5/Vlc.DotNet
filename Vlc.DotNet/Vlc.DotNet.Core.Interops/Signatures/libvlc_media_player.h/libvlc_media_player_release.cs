using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// It will release the media player object. If the media player object has been released, then it should not be used again.
    /// </summary>
    [LibVlcFunction("libvlc_media_player_release")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void ReleaseMediaPlayer(IntPtr mediaPlayerInstance);
}
