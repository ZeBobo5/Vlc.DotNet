using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed class FilterModuleDescription
    {
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public string LongName { get; private set; }
        public string Help { get; private set; }

        internal FilterModuleDescription(ModuleDescription module)
        {
#if NET20
            Name = IntPtrExtensions.ToStringAnsi(module.Name);
            ShortName = IntPtrExtensions.ToStringAnsi(module.ShortName);
            LongName = IntPtrExtensions.ToStringAnsi(module.LongName);
            Help = IntPtrExtensions.ToStringAnsi(module.Help);
#else
            Name = module.Name.ToStringAnsi();
            ShortName = module.ShortName.ToStringAnsi();
            LongName = module.LongName.ToStringAnsi();
            Help = module.Help.ToStringAnsi();
#endif
        }
    }
}
