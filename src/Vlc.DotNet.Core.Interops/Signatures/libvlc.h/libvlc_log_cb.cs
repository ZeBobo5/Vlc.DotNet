namespace Vlc.DotNet.Core.Interops.Signatures
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The delegate type that represent logging functions
    /// </summary>
    [LibVlcFunction("libvlc_log_cb")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LogCallback(IntPtr data, VlcLogLevel level, IntPtr ctx, [MarshalAs(UnmanagedType.LPStr)] string format, IntPtr args);
}
