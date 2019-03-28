using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetVideoCropGeometry(VlcMediaPlayerInstance mediaPlayerInstance, string cropGeometry)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");

            using (var cropGeometryInterop = Utf8InteropStringConverter.ToUtf8StringHandle(cropGeometry))
            {
                myLibraryLoader.GetInteropDelegate<SetVideoCropGeometry>()
                    .Invoke(mediaPlayerInstance, cropGeometryInterop);
            }
        }
    }
}
