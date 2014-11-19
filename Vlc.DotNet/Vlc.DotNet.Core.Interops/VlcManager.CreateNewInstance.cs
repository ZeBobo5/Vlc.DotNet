using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public IntPtr CreateNewInstance(string[] args)
        {
            if (args == null)
                args = new string[0];
            return GetInteropDelegate<CreateNewInstance>().Invoke(args.Length, args);
        }
    }
}
