using System;
using System.Collections.Generic;
using System.IO;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager : VlcInteropsManager
    {
        private IntPtr myVlcInstance;
        private object myStaticLocker = new object();
        private static Dictionary<DirectoryInfo, VlcRincewindManager> myAllInstance = new Dictionary<DirectoryInfo, VlcRincewindManager>();

        internal VlcRincewindManager(DirectoryInfo dynamicLinkLibrariesPath)
            : base(dynamicLinkLibrariesPath)
        {
        }

        public IntPtr VlcInstance
        {
            get
            {
                lock (myStaticLocker)
                {
                    if (myVlcInstance == IntPtr.Zero)
                    {
                        myVlcInstance = CreateNewInstance(null);
                    }
                    return myVlcInstance;
                }
            }
        }

        public override void Dispose(bool disposing)
        {
            if (myVlcInstance != IntPtr.Zero)
            {
                ReleaseInstance(myVlcInstance);
                myVlcInstance = IntPtr.Zero;
            }
            if (myAllInstance.ContainsValue(this))
            {
                foreach (var kv in myAllInstance)
                {
                    if(kv.Value == this)
                        myAllInstance.Remove(kv.Key);
                }
            }
            base.Dispose(disposing);
        }

        public static VlcRincewindManager GetInstance(DirectoryInfo dynamicLinkLibrariesPath)
        {
            if (!myAllInstance.ContainsKey(dynamicLinkLibrariesPath))
                myAllInstance[dynamicLinkLibrariesPath] = new VlcRincewindManager(dynamicLinkLibrariesPath);
            return myAllInstance[dynamicLinkLibrariesPath];
        }
    }
}