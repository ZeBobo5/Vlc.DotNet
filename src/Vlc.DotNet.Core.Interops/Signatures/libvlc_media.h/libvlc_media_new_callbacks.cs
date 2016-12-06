using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Callback prototype to open a custom bitstream input media.
    /// NoteL: The same media item can be opened multiple times. Each time, this callback is invoked. It should allocate and initialize any instance-specific resources, then store them in *datap. The instance resources can be freed in the libvlc_media_close_cb callback.
    /// </summary>
    /// <param name="opaque">private pointer as passed to CallbackOpenMediaDelegate()</param>
    /// <param name="pData">storage space for a private data pointer [OUT]</param>
    /// <param name="szData">byte length of the bitstream or UINT64_MAX if unknown [OUT]</param>
    /// <returns>0 on success, non-zero on error. In case of failure, the other callbacks will not be invoked and any value stored in *datap and *sizep is discarded.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate Int32 CallbackOpenMediaDelegate(IntPtr opaque, out IntPtr pData, out UInt64 szData);
    //typedef int(* libvlc_media_open_cb)(void* opaque, void** datap, uint64_t * sizep)

    /// <summary>
    /// Callback prototype to read data from a custom bitstream input media.
    /// Note: If no data is immediately available, then the callback should sleep.
    /// Warning: The application is responsible for avoiding deadlock situations. In particular, the callback should return an error if playback is stopped; if it does not return, then libvlc_media_player_stop() will never return.
    /// </summary>
    /// <param name="opaque">private pointer as set by the CallbackOpenMediaDelegate() callback</param>
    /// <param name="buf">start address of the buffer to read data into</param>
    /// <param name="len">bytes length of the buffer</param>
    /// <returns>strictly positive number of bytes read, 0 on end-of-stream, or -1 on non-recoverable error</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr CallbackReadMediaDelegate(IntPtr opaque, IntPtr buf, UIntPtr len);
    //internal delegate IntPtr CallbackReadMediaDelegate(IntPtr opaque, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] buf, UIntPtr len);
    //typedef ssize_t(* libvlc_media_read_cb)(void* opaque, unsigned char* buf, size_t len)

    /// <summary>
    /// Callback prototype to seek a custom bitstream input media.
    /// </summary>
    /// <param name="opaque">private pointer as set by the CallbackOpenMediaDelegate() callback</param>
    /// <param name="offset">absolute byte offset to seek to</param>
    /// <returns>0 on success, -1 on error</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate Int32 CallbackSeekMediaDelegate(IntPtr opaque, UInt64 offset);
    //typedef int(* libvlc_media_seek_cb)(void* opaque, uint64_t offset)

    /// <summary>
    /// Callback prototype to close a custom bitstream input media.
    /// </summary>
    /// <param name="opaque">private pointer as set by the CallbackOpenMediaDelegate() callback</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void CallbackCloseMediaDelegate(IntPtr opaque);
    //typedef void(* libvlc_media_close_cb)(void* opaque)

    /// <summary>
    /// Create a media with custom callbacks to read the data from.
    /// Note: If open_cb is NULL, the opaque pointer will be passed to read_cb, seek_cb and close_cb, and the stream size will be treated as unknown.
    /// The callbacks may be called asynchronously (from another thread). A single stream instance need not be reentrant. However the open_cb needs to be reentrant if the media is used by multiple player instances.
    /// Warning: The callbacks may be used until all or any player instances that were supplied the media item are stopped.
    /// </summary>
    /// <returns>Return the newly created media or NULL on error.</returns>
    [LibVlcFunction("libvlc_media_new_callbacks")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr CreateNewMediaFromCallbacks(IntPtr mediaPlayerInstance,
        CallbackOpenMediaDelegate open_cb,
        CallbackReadMediaDelegate read_cb,
        CallbackSeekMediaDelegate seek_cb,
        CallbackCloseMediaDelegate close_cb,
        IntPtr opaque);
}
