using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
	public sealed partial class VlcManager
    {
        public void AddOptionToMedia(VlcMediaInstance mediaInstance, string option)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            if (string.IsNullOrEmpty(option))
                return;

            using (var handle = Utf8InteropStringConverter.ToUtf8StringHandle(option))
            {
                myLibraryLoader.GetInteropDelegate<AddOptionToMedia>().Invoke(mediaInstance, handle);
            }
        }

        public void AddOptionToMedia(VlcMediaInstance mediaInstance, string[] options)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            options = options ?? new string[0];
            foreach (var option in options)
            {
                AddOptionToMedia(mediaInstance, option);
            }
        }
    }
}
