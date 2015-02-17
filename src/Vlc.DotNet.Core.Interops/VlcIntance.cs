using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed class VlcIntance : InteropObjectInstance
    {
        private readonly VlcManager myManager;

        internal VlcIntance(VlcManager manager, IntPtr pointer) : base(pointer)
        {
            myManager = manager;
        }

        public override void Dispose(bool disposing)
        {
            if (Pointer != IntPtr.Zero)
                myManager.ReleaseInstance(this);
            base.Dispose(disposing);            
        }

        public static implicit operator IntPtr(VlcIntance instance)
        {
            return instance.Pointer;
        }
    }
}