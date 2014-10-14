using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public string GetCompiler()
        {
#if !NET20
            return GetInteropDelegate<GetCompiler>().Invoke().ToStringAnsi();
#else
            return IntPtrExtensions.ToStringAnsi(GetInteropDelegate<GetCompiler>().Invoke());
#endif
        }
    }
}
