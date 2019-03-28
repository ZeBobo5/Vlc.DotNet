using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager : IDisposable
    {
        private readonly VlcLibraryLoader myLibraryLoader;
        private readonly VlcInstance myVlcInstance;

        public string VlcVersion => Utf8InteropStringConverter.Utf8InteropToString(myLibraryLoader.GetInteropDelegate<GetVersion>().Invoke());

        public Version VlcVersionNumber
        {
            get
            {
                var versionString = this.VlcVersion;
                versionString = versionString.Split('-', ' ')[0];

                return new Version(versionString);
            }
        }

        public VlcManager(DirectoryInfo dynamicLinkLibrariesPath, string[] args)
        {
            this.myLibraryLoader = VlcLibraryLoader.GetOrCreateLoader(dynamicLinkLibrariesPath);

            IntPtr[] utf8Args = new IntPtr[args?.Length ?? 0];
            try
            {
                for (var i = 0; i < utf8Args.Length; i++)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(args[i]);
                    var buffer = Marshal.AllocHGlobal(bytes.Length + 1);
                    Marshal.Copy(bytes, 0, buffer, bytes.Length);
                    Marshal.WriteByte(buffer, bytes.Length, 0);
                    utf8Args[i] = buffer;
                }

                myVlcInstance = new VlcInstance(this, myLibraryLoader.GetInteropDelegate<CreateNewInstance>().Invoke(utf8Args.Length, utf8Args));
            }
            finally
            {
                foreach (var arg in utf8Args)
                {
                    if (arg != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(arg);
                    }
                }
            }
        }

        public void Dispose()
        {
            if (this.dialogCallbacksPointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(this.dialogCallbacksPointer);
            }
            myVlcInstance.Dispose();
            VlcLibraryLoader.ReleaseLoader(this.myLibraryLoader);
        }
    }
}