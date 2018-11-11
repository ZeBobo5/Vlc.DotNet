using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        /// <summary>
        /// Sets some meta-information about the application. 
        /// </summary>
        /// <seealso cref="SetUserAgent" />
        /// <param name="id">Java-style application identifier, e.g. "com.acme.foobar"</param>
        /// <param name="version">application version numbers, e.g. "1.2.3"</param>
        /// <param name="icon">application icon name, e.g. "foobar"</param>
        public void SetAppId(string id, string version, string icon)
        {
            using (var idInterop = Utf8InteropStringConverter.ToUtf8StringHandle(id))
            using (var versionInterop = Utf8InteropStringConverter.ToUtf8StringHandle(version))
            using (var iconInterop = Utf8InteropStringConverter.ToUtf8StringHandle(icon))
            {
                GetInteropDelegate<SetAppId>().Invoke(this.myVlcInstance, idInterop, versionInterop, iconInterop);
            }
        }
    }
}
