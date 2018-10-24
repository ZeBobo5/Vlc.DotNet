using System;
using System.Collections.Generic;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed class VlcMediaInstance : InteropObjectInstance
    {
        private readonly VlcManager myManager;
        private static readonly Dictionary<IntPtr, VlcMediaInstance> AllInstances = new Dictionary<IntPtr, VlcMediaInstance>();

        public static VlcMediaInstance New(VlcManager manager, IntPtr pointer)
        {
            lock (AllInstances)
            {
                AllInstances.TryGetValue(pointer, out var instance);

                if (null == instance)
                {
                    instance = new VlcMediaInstance(manager, pointer);
                    AllInstances.Add(pointer, instance);
                }

                return instance;
            }
        }

        private VlcMediaInstance(VlcManager manager, IntPtr pointer) : base(pointer)
        {
            myManager = manager;
        }

        protected override void Dispose(bool disposing)
        {
            lock (AllInstances)
            {
                AllInstances.Remove(this);
            }
            
            if (Pointer != IntPtr.Zero)
                myManager.ReleaseMedia(this);
            base.Dispose(disposing);
        }

        public static implicit operator IntPtr(VlcMediaInstance instance)
        {
            return instance.Pointer;
        }
    }
}