using System;

namespace Vlc.DotNet.Core.Interops
{
    public class VlcVersions
    {
        public static VlcVersions EMPTY = new VlcVersions(new Version(0, 0), null);
        /// <summary>
        /// Vlc version 2.0.x.
        /// </summary>
        public static VlcVersions Twoflower = new VlcVersions(new Version(2, 0), "Twoflower");
        /// <summary>
        /// Vlc version 2.1.x.
        /// </summary>
        public static VlcVersions Rincewind = new VlcVersions(new Version(2, 1), "Rincewind");
        /// <summary>
        /// Vlc version 2.2.x.
        /// </summary>
        public static VlcVersions Weatherwax = new VlcVersions(new Version(2, 2), "Weatherwax");

        public Version Version { get; private set; }
        public string Codename { get; private set; }
        internal Type VlcSignatureManager { get; private set; }

        private VlcVersions(Version version, string codename)
        {
            Version = version;
            Codename = codename;
        }

        internal static VlcVersions GetVersion(string version)
        {
            var codename = version.Split(' ')[1];
            if (VlcVersions.Twoflower.Codename.Equals(codename, StringComparison.CurrentCultureIgnoreCase))
                return VlcVersions.Twoflower;
            if (VlcVersions.Rincewind.Codename.Equals(codename, StringComparison.CurrentCultureIgnoreCase))
                return VlcVersions.Rincewind;
            if (VlcVersions.Weatherwax.Codename.Equals(codename, StringComparison.CurrentCultureIgnoreCase))
                return VlcVersions.Weatherwax;
            return VlcVersions.EMPTY;
        }
    }

}
