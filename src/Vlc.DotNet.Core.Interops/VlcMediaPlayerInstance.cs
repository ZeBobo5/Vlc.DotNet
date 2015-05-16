using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed class VlcMediaPlayerInstance : InteropObjectInstance
    {
        private readonly VlcManager myManager;

        internal VlcMediaPlayerInstance(VlcManager manager, IntPtr pointer) : base(pointer)
        {
            myManager = manager;
        }

        protected override void Dispose(bool disposing)
        {
            if (Pointer != IntPtr.Zero)
                myManager.ReleaseMediaPlayer(this);
            base.Dispose(disposing);
        }

        public static implicit operator IntPtr(VlcMediaPlayerInstance instance)
        {
            return instance != null
                ? instance.Pointer
                : IntPtr.Zero;
        }
    }
}