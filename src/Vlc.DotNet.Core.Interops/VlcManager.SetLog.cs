using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        /// <summary>
        /// Keeps a reference to the last callback that was given to the <see cref="SetLog"/> method.
        /// This is to avoid garbage collection of the delegate before the function is called.
        /// </summary>
        private LogCallback logCallbackReference;

        public void SetLog(LogCallback callback)
        {
            if (callback == null)
            {
                throw new ArgumentException("Callback for log is not initialized.");
            }

            this.logCallbackReference = callback;
            myLibraryLoader.GetInteropDelegate<SetLog>().Invoke(this.myVlcInstance, this.logCallbackReference, IntPtr.Zero);
        }
    }
}
