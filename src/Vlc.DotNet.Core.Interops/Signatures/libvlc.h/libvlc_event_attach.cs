using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Register for an event notification.
    /// </summary>
    /// <param name="eventManagerInstance">Event manager to which you want to attach to.</param>
    /// <param name="eventType">The desired event to which we want to listen.</param>
    /// <param name="callback">The function to call when i_event_type occurs.</param>
    /// <param name="userData">User provided data to carry with the event.</param>
    /// <returns>Return 0 on success, ENOMEM on error.</returns>
    [LibVlcFunction("libvlc_event_attach")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int AttachEvent(IntPtr eventManagerInstance, EventTypes eventType, EventCallback callback, IntPtr userData);
}
