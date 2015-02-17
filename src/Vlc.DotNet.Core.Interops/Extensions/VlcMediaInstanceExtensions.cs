using System;
using System.Collections.Generic;
using System.Text;

namespace Vlc.DotNet.Core.Interops
{
    public static class VlcMediaInstanceExtensions
    {
#if NET20
        public static VlcMediaInstance AddOptionToMedia(VlcMediaInstance mediaInstance, VlcManager manager, string option)
#else
        public static VlcMediaInstance AddOptionToMedia(this VlcMediaInstance mediaInstance, VlcManager manager, string option)
#endif
        {
            manager.AddOptionToMedia(mediaInstance, option);
            return mediaInstance;
        }

#if NET20
        public static VlcMediaInstance AddOptionToMedia(VlcMediaInstance mediaInstance, VlcManager manager, string[] option)
#else
        public static VlcMediaInstance AddOptionToMedia(this VlcMediaInstance mediaInstance, VlcManager manager, string[] option)
#endif
        {
            manager.AddOptionToMedia(mediaInstance, option);
            return mediaInstance;
        }
    }
}
