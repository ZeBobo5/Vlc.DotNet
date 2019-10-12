#if !NET35 && !NET40
namespace Vlc.DotNet.Core
{
    using System;

    public interface IDialogsManagement
    {
        /// <summary>
        /// Use this dialog manager to answer libvlc's questions
        /// </summary>
        /// <param name="dialogManager">The dialog manager to be used, or <c>null</c> to remove any dialog manager</param>
        /// <param name="data">Custom parameters to be passed to the dialogs</param>
        void UseDialogManager(IVlcDialogManager dialogManager, IntPtr data = default(IntPtr));
    }
}
#endif