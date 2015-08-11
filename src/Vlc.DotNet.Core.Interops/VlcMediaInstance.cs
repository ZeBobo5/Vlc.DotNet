using System;
using System.Collections.Generic;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed class VlcMediaInstance : InteropObjectInstance
    {
        private readonly VlcManager myManager;

        private static List<VlcMediaInstance> allInstances = new List<VlcMediaInstance>();

        public static VlcMediaInstance New(VlcManager manager, IntPtr pointer)
        {
            var instance = allInstances.Find(delegate(VlcMediaInstance i)
            {
                return i == pointer;
            });
            if (null == instance)
            {
                instance = new VlcMediaInstance(manager, pointer);
                allInstances.Add(instance);
            }
            return instance;
        }

        private VlcMediaInstance(VlcManager manager, IntPtr pointer) : base(pointer)
        {
            myManager = manager;
        }

        protected override void Dispose(bool disposing)
        {
            allInstances.Remove(this);
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