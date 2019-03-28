using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        /// <summary>
        /// Get codec description from media elementary stream.
        ///  LibVLC 3.0.0 and later.
        /// </summary>
        /// <param name="type">The media track type</param>
        /// <param name="codec">The codec 4CC</param>
        /// <returns>The codec description</returns>
        public string GetCodecDescription(MediaTrackTypes type, UInt32 codec)
        {
            if (VlcVersionNumber.Major < 3)
            {
                throw new InvalidOperationException($"You need VLC version 3.0 or higher to be able to use {nameof(GetCodecDescription)}");
            }
            
            var ptr = myLibraryLoader.GetInteropDelegate<GetCodecDescription>().Invoke(type, codec);
            return Utf8InteropStringConverter.Utf8InteropToString(ptr);
        }
    }
}