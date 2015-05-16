using System;
using System.Collections.Generic;
using System.IO;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager : VlcInteropsManager
    {
        private VlcInstance myVlcInstance;
        private static readonly Dictionary<DirectoryInfo, VlcManager> myAllInstance = new Dictionary<DirectoryInfo, VlcManager>();

        public string VlcVersion
        {
            get
            {
#if !NET20
                return GetInteropDelegate<GetVersion>().Invoke().ToStringAnsi();
#else
                return IntPtrExtensions.ToStringAnsi(GetInteropDelegate<GetVersion>().Invoke());
#endif
            }
        }

        internal VlcManager(DirectoryInfo dynamicLinkLibrariesPath)
            : base(dynamicLinkLibrariesPath)
        {
        }

        public override void Dispose(bool disposing)
        {
            if (myVlcInstance != null)
                myVlcInstance.Dispose();

            if (myAllInstance.ContainsValue(this))
            {
                foreach (var kv in new Dictionary<DirectoryInfo, VlcManager>(myAllInstance))
                {
                    if(kv.Value == this)
                        myAllInstance.Remove(kv.Key);
                }
            }
            base.Dispose(disposing);
        }

        public static VlcManager GetInstance(DirectoryInfo dynamicLinkLibrariesPath)
        {
            if (!myAllInstance.ContainsKey(dynamicLinkLibrariesPath))
                myAllInstance[dynamicLinkLibrariesPath] = new VlcManager(dynamicLinkLibrariesPath);
            return myAllInstance[dynamicLinkLibrariesPath];
        }
    }
}