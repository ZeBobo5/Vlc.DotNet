namespace Vlc.DotNet.Core.Interops.Signatures
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The delegate type that represent logging functions
    /// </summary>
    /// <param name="data">The data given to libvlc_log_set. In our case, this value will always be <see langword="null" /></param>
    /// <param name="level">The log level</param>
    /// <param name="logContext">The address of the structure that contains information about the log event. <see cref="GetLogContext"/></param>
    /// <param name="format">The format of the log messages</param>
    /// <param name="args">The va_list of printf arguments.</param>
    [LibVlcFunction("libvlc_log_cb")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LogCallback(IntPtr data, VlcLogLevel level, IntPtr logContext, [MarshalAs(UnmanagedType.LPStr)] string format, IntPtr args);
}
