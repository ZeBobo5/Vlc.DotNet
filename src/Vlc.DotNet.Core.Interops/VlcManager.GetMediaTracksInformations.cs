using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        [Obsolete("Use GetMediaTracks instead")]
        public MediaTrackInfosStructure[] GetMediaTracksInformations(VlcMediaInstance mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            IntPtr fullBuffer;
            var cpt = myLibraryLoader.GetInteropDelegate<GetMediaTracksInformations>().Invoke(mediaInstance, out fullBuffer);
            if (cpt <= 0)
                return new MediaTrackInfosStructure[0];
            var result = new MediaTrackInfosStructure[cpt];
            var buffer = fullBuffer;
            for (int index = 0; index < cpt; index++)
            {
                result[index] = MarshalHelper.PtrToStructure<MediaTrackInfosStructure>(buffer);
                buffer = IntPtr.Size == 4
                    ? new IntPtr(buffer.ToInt32() + MarshalHelper.SizeOf<MediaTrackInfosStructure>())
                    : new IntPtr(buffer.ToInt64() + MarshalHelper.SizeOf<MediaTrackInfosStructure>());
            }
            Free(fullBuffer);
            return result;
        }
    }
}
