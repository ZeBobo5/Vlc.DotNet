using System;
using System.Collections.Generic;
using System.IO;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcTheLuggageManager : VlcInteropsManager
    {
        private IntPtr myVlcInstance;
        private readonly object myStaticLocker = new object();
        private static readonly Dictionary<DirectoryInfo, VlcTheLuggageManager> myAllInstance = new Dictionary<DirectoryInfo, VlcTheLuggageManager>();

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

        internal VlcTheLuggageManager(DirectoryInfo dynamicLinkLibrariesPath)
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
                foreach (var kv in new Dictionary<DirectoryInfo, VlcTheLuggageManager>(myAllInstance))
                {
                    if(kv.Value == this)
                        myAllInstance.Remove(kv.Key);
                }
            }
            base.Dispose(disposing);
        }

        public static VlcTheLuggageManager GetInstance(DirectoryInfo dynamicLinkLibrariesPath)
        {
            if (!myAllInstance.ContainsKey(dynamicLinkLibrariesPath))
                myAllInstance[dynamicLinkLibrariesPath] = new VlcTheLuggageManager(dynamicLinkLibrariesPath);
            return myAllInstance[dynamicLinkLibrariesPath];
        }
    }
}