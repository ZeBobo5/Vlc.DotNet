using System;
using System.Collections.Generic;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed class VlcMediaInstance : InteropObjectInstance
    {
        private readonly VlcManager myManager;
        static readonly Dictionary<IntPtr, int> sInstanceCount
            = new Dictionary<IntPtr, int>();

        internal VlcMediaInstance(VlcManager manager, IntPtr pointer)
            : base(pointer)
        {
            myManager = manager;
            if (pointer != IntPtr.Zero)
            {
                // keep a reference count for the media instance
                if (!sInstanceCount.ContainsKey(pointer))
                    sInstanceCount[pointer] = 0;
                else
                    sInstanceCount[pointer] = sInstanceCount[pointer] + 1;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Pointer != IntPtr.Zero)
            {
                // only release the instance if no more references
                if (sInstanceCount[this.Pointer] > 0)
                {
                    sInstanceCount[this.Pointer] = sInstanceCount[this.Pointer] - 1;
                    if (sInstanceCount[this.Pointer] == 0)
                        myManager.ReleaseMedia(this);
                }
            }
            base.Dispose(disposing);
        }

        public static implicit operator IntPtr(VlcMediaInstance instance)
        {
            return instance.Pointer;
        }
    }
}