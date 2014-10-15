using System;
using System.Collections.Generic;
using System.IO;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager : VlcInteropsManager
    {
        private IntPtr myVlcInstance;
        private readonly object myStaticLocker = new object();
        private static readonly Dictionary<DirectoryInfo, VlcRincewindManager> myAllInstance = new Dictionary<DirectoryInfo, VlcRincewindManager>();

        public VlcVersions VlcVersion
        {
            get
            {
#if !NET20
                return VlcVersions.GetVersion(GetInteropDelegate<GetVersion>().Invoke().ToStringAnsi());
#else
                return VlcVersions.GetVersion(IntPtrExtensions.ToStringAnsi(GetInteropDelegate<GetVersion>().Invoke()));
#endif
            }
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

        internal VlcRincewindManager(DirectoryInfo dynamicLinkLibrariesPath)
            : base(dynamicLinkLibrariesPath)
        {
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