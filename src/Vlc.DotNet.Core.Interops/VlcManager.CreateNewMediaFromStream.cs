using System;
#if !NET35
using System.Collections.Concurrent;
#endif
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        private static readonly CallbackOpenMediaDelegate CallbackOpenMediaDelegate = CallbackOpenMedia;
        private static readonly CallbackReadMediaDelegate CallbackReadMediaDelegate = CallbackReadMedia;
        private static readonly CallbackSeekMediaDelegate CallbackSeekMediaDelegate = CallbackSeekMedia;
        private static readonly CallbackCloseMediaDelegate CallbackCloseMediaDelegate = CallbackCloseMedia;

#if NET35
        private static readonly Dictionary<IntPtr, StreamData> DicStreams = new Dictionary<IntPtr, StreamData>();
#else
        private static readonly ConcurrentDictionary<IntPtr, StreamData> DicStreams = new ConcurrentDictionary<IntPtr, StreamData>();
#endif
        private static int streamIndex = 0;

        public VlcMediaInstance CreateNewMediaFromStream(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (VlcVersionNumber.Major < 3)
            {
                throw new InvalidOperationException("You need VLC version 3.0 or higher to be able to use CreateNewMediaFromStream");
            }

            IntPtr opaque = AddStream(stream);

            if (opaque == IntPtr.Zero)
                return null;

            var result = VlcMediaInstance.New(this, myLibraryLoader.GetInteropDelegate<CreateNewMediaFromCallbacks>().Invoke(
                myVlcInstance,
                CallbackOpenMediaDelegate,
                CallbackReadMediaDelegate,
                stream.CanSeek ? CallbackSeekMediaDelegate : null,
                CallbackCloseMediaDelegate,
                opaque
                ));

            return result;
        }

        private static int CallbackOpenMedia(IntPtr opaque, ref IntPtr pData, out ulong szData)
        {
            pData = opaque;

            try
            {
                var streamData = GetStream(opaque);

                try
                {
                    szData = (ulong)streamData.Stream.Length;
                }
                catch (Exception)
                {
                    // byte length of the bitstream or UINT64_MAX if unknown
                    szData = ulong.MaxValue;
                }

                if (streamData.Stream.CanSeek)
                {
                    streamData.Stream.Seek(0L, SeekOrigin.Begin);
                }

                return 0;
            }
            catch (Exception)
            {
                szData = 0UL;
                return -1;
            }
        }

        private static int CallbackReadMedia(IntPtr opaque, IntPtr ipbuf, uint len)
        {
            try
            {
                var streamData = GetStream(opaque);
                int read;

                lock (streamData)
                {
                    var canRead = Math.Min((int)len, streamData.Buffer.Length);
                    read = streamData.Stream.Read(streamData.Buffer, 0, canRead);
                    Marshal.Copy(streamData.Buffer, 0, ipbuf, read);
                }

                return read;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static int CallbackSeekMedia(IntPtr opaque, UInt64 offset)
        {
            try
            {
                var streamData = GetStream(opaque);
                streamData.Stream.Seek((long)offset, SeekOrigin.Begin);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static void CallbackCloseMedia(IntPtr opaque)
        {
            try
            {
                RemoveStream(opaque);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private static IntPtr AddStream(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            IntPtr handle;

            lock (DicStreams)
            {
                streamIndex++;

                handle = new IntPtr(streamIndex);
                DicStreams[handle] = new StreamData()
                {
                    Buffer = new byte[0x100_0000],
                    Handle = handle,
                    Stream = stream
                };
            }

            return handle;
        }

        private static StreamData GetStream(IntPtr handle)
        {
#if NET35
            lock (DicStreams)
            {
                if (!DicStreams.ContainsKey(handle))
                {
                    return null;
                }

                return DicStreams[handle];
            }
#else
            StreamData result;

            if (!DicStreams.TryGetValue(handle, out result))
            {
                return null;
            }

            return result;
#endif
        }

        private static void RemoveStream(IntPtr handle)
        {
#if NET35
            lock (DicStreams)
            {
                if (DicStreams.ContainsKey(handle))
                {
                    DicStreams.Remove(handle);
                }
            }
#else
            StreamData result;
            DicStreams.TryRemove(handle, out result);
#endif
        }
    }
}