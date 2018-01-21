using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        private DialogCallbacks? dialogCallbacks;

        private IntPtr dialogCallbacksPointer;

        /// <summary>
        /// Register callbacks in order to handle VLC dialogs. LibVLC 3.0.0 and later.
        /// </summary>
        public void SetDialogCallbacks(DialogCallbacks? callbacks, IntPtr data)
        {
            EnsureVlcInstance();

            if (VlcVersionNumber.Major < 3)
            {
                throw new InvalidOperationException($"You need VLC version 3.0 or higher to be able to use {nameof(SetDialogCallbacks)}");
            }

            if (this.dialogCallbacks.HasValue)
            {
                Marshal.FreeHGlobal(this.dialogCallbacksPointer);
                this.dialogCallbacksPointer = IntPtr.Zero;
            }

            this.dialogCallbacks = callbacks;
            if (this.dialogCallbacks.HasValue)
            {
#if NET20 || NET35 || NET40 || NET45
                this.dialogCallbacksPointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(DialogCallbacks)));
#else
                this.dialogCallbacksPointer = Marshal.AllocHGlobal(Marshal.SizeOf<DialogCallbacks>());
#endif
                Marshal.StructureToPtr(this.dialogCallbacks.Value, this.dialogCallbacksPointer, false);
            }

            GetInteropDelegate<SetDialogCallbacks>().Invoke(this.myVlcInstance, this.dialogCallbacksPointer, data);
        }

        /// <summary>
        /// Associate an opaque pointer with the dialog id
        /// </summary>
        public void SetDialogContext(IntPtr dialogId, IntPtr data)
        {
            EnsureVlcInstance();

            if (VlcVersionNumber.Major < 3)
            {
                throw new InvalidOperationException($"You need VLC version 3.0 or higher to be able to use {nameof(SetDialogContext)}");
            }

            GetInteropDelegate<SetDialogContext>().Invoke(dialogId, data);
        }


        /// <summary>
        /// Return the opaque pointer associated with the dialog id
        /// </summary>
        public IntPtr GetDialogContext(IntPtr dialogId)
        {
            EnsureVlcInstance();

            if (VlcVersionNumber.Major < 3)
            {
                throw new InvalidOperationException($"You need VLC version 3.0 or higher to be able to use {nameof(GetDialogContext)}");
            }

            return GetInteropDelegate<GetDialogContext>().Invoke(dialogId);
        }

        /// <summary>
        /// Post a login answer
        /// 
        /// After this call, p_id won't be valid anymore
        /// </summary>
        /// <returns>0 on success, or -1 on error</returns>
        public int PostLogin(IntPtr dialogId, Utf8StringHandle username, Utf8StringHandle password, bool store)
        {
            EnsureVlcInstance();

            if (VlcVersionNumber.Major < 3)
            {
                throw new InvalidOperationException($"You need VLC version 3.0 or higher to be able to use {nameof(PostLogin)}");
            }

            return GetInteropDelegate<PostLogin>().Invoke(dialogId, username.DangerousGetHandle(), password.DangerousGetHandle(), store);
        }

        /// <summary>
        /// Post a question answer
        /// 
        /// After this call, p_id won't be valid anymore
        /// </summary>
        /// <returns>0 on success, or -1 on error</returns>
        public int PostAction(IntPtr dialogId, int action)
        {
            EnsureVlcInstance();

            if (VlcVersionNumber.Major < 3)
            {
                throw new InvalidOperationException($"You need VLC version 3.0 or higher to be able to use {nameof(PostAction)}");
            }

            return GetInteropDelegate<PostAction>().Invoke(dialogId, action);
        }

        /// <summary>
        /// Dismiss a dialog
        /// 
        /// After this call, p_id won't be valid anymore
        /// </summary>
        /// <returns>0 on success, or -1 on error</returns>
        public int DismissDialog(IntPtr dialogId)
        {
            EnsureVlcInstance();

            if (VlcVersionNumber.Major < 3)
            {
                throw new InvalidOperationException($"You need VLC version 3.0 or higher to be able to use {nameof(DismissDialog)}");
            }

            return GetInteropDelegate<DismissDialog>().Invoke(dialogId);
        }
    }
}
