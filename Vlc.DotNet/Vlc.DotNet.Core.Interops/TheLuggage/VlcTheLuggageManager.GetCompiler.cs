using System;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcTheLuggageManager
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
