﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager : VlcInteropsManager
    {
        private VlcInstance myVlcInstance;
        private static readonly Dictionary<DirectoryInfo, VlcManager> MyAllInstance = new Dictionary<DirectoryInfo, VlcManager>();

        public string VlcVersion => Utf8InteropStringConverter.Utf8InteropToString(GetInteropDelegate<GetVersion>().Invoke());

        public Version VlcVersionNumber
        {
            get
            {
                var versionString = this.VlcVersion;
                versionString = versionString.Split('-', ' ')[0];

                return new Version(versionString);
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

            lock (MyAllInstance)
            {
                if (MyAllInstance.ContainsValue(this))
                {
                    foreach (var kv in new Dictionary<DirectoryInfo, VlcManager>(MyAllInstance))
                    {
                        if (kv.Value == this)
                            MyAllInstance.Remove(kv.Key);
                    }
                }
            }

            if (this.dialogCallbacksPointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(this.dialogCallbacksPointer);
            }

            base.Dispose(disposing);
        }

        public static VlcManager GetInstance(DirectoryInfo dynamicLinkLibrariesPath)
        {
            lock (MyAllInstance)
            {
                if (!MyAllInstance.ContainsKey(dynamicLinkLibrariesPath))
                    MyAllInstance[dynamicLinkLibrariesPath] = new VlcManager(dynamicLinkLibrariesPath);
                return MyAllInstance[dynamicLinkLibrariesPath];
            }
        }

        private void EnsureVlcInstance()
        {
            if (myVlcInstance == null)
            {
                throw new InvalidOperationException("This VlcManager has not yet been initialized. Call CreateNewInstance to initialize it.");
            }
        }
    }
}