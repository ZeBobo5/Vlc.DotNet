using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetVideoSpu(VlcMediaPlayerInstance mediaPlayerInstance, TrackDescriptionStructure trackDescription)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            SetVideoSpu(mediaPlayerInstance, trackDescription.Id);
        }

        public void SetVideoSpu(VlcMediaPlayerInstance mediaPlayerInstance, int id)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            GetInteropDelegate<SetVideoSpu>().Invoke(mediaPlayerInstance, id);
        }

        public void SetVideoSubtitle(VlcMediaPlayerInstance mediaPlayerInstance, string filepath)
        {
            var pathHandle = System.Runtime.InteropServices.GCHandle.Alloc(System.Text.Encoding.UTF8.GetBytes(filepath), System.Runtime.InteropServices.GCHandleType.Pinned);

            SetVideoSubtitle(mediaPlayerInstance, pathHandle.AddrOfPinnedObject());
            pathHandle.Free();
        }

        private void SetVideoSubtitle(VlcMediaPlayerInstance mediaPlayerInstance, IntPtr filepath)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            GetInteropDelegate<SetSubtitleFile>().Invoke(mediaPlayerInstance, filepath);
        }
    }
}
