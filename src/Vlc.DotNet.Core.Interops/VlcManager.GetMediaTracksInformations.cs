using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public MediaTrackInfosStructure[] GetMediaTracksInformations(VlcMediaInstance mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            var fullBuffer = IntPtr.Zero;
            var cpt = GetInteropDelegate<GetMediaTracksInformations>().Invoke(mediaInstance, out fullBuffer);
            if (cpt <= 0)
                return new MediaTrackInfosStructure[0];
            var result = new MediaTrackInfosStructure[cpt];
            var buffer = fullBuffer;
            for (int index = 0; index < cpt; index++)
            {
                result[index] = (MediaTrackInfosStructure)Marshal.PtrToStructure(buffer, typeof(MediaTrackInfosStructure));
#if X86
                buffer = new IntPtr(buffer.ToInt32() + Marshal.SizeOf(typeof(MediaTrackInfosStructure)));
#else
                buffer = new IntPtr(buffer.ToInt64() + Marshal.SizeOf(typeof(MediaTrackInfosStructure)));
#endif
            }
            Free(fullBuffer);
            return result;
        }
    }
}
