using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{

    /// <summary>
    /// CCallback function notification.
    /// </summary>
    [LibVlcFunction("libvlc_callback_t")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void EventCallback(IntPtr args);
}
