using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// The level of the dialog to be displayed.
    /// </summary>
    public enum DialogQuestionType : int
    {
        Normal = 0,
        Warning,
        Critical
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ErrorDialogCallback(IntPtr userData, IntPtr title, IntPtr text);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LoginDialogCallback(IntPtr userData, IntPtr dialogId, IntPtr title, IntPtr text, IntPtr defaultUserName, bool askStore);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void QuestionDialogCallback(IntPtr userData, IntPtr dialogId, IntPtr title, IntPtr text, DialogQuestionType questionType, IntPtr cancel, IntPtr action1, IntPtr action2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ProgressDialogCallback(IntPtr userData, IntPtr dialogId, IntPtr title, IntPtr text, bool indeterminate, float position, IntPtr cancel);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CancelDialogCallback(IntPtr userData, IntPtr dialogId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void UpdateProgressDialogCallback(IntPtr userData, IntPtr dialogId, float position, IntPtr text);

    [StructLayout(LayoutKind.Sequential)]
    public struct DialogCallbacks
    {
        /// <summary>
        /// Called when an error message needs to be displayed
        /// </summary>
        public ErrorDialogCallback DisplayError;

        /// <summary>
        /// Called when a login dialog needs to be displayed
        /// 
        /// You can interact with this dialog by calling libvlc_dialog_post_login()
        /// to post an answer or libvlc_dialog_dismiss() to cancel this dialog.
        /// </summary>
        /// <remarks>To receive this callback, libvlc_dialog_cbs.pf_cancel should not be NULL</remarks>
        public LoginDialogCallback DisplayLogin;

        /// <summary>
        /// Called when a question dialog needs to be displayed
        /// 
        /// You can interact with this dialog by calling libvlc_dialog_post_action()
        /// to post an answer or libvlc_dialog_dismiss() to cancel this dialog.
        /// </summary>
        /// <remarks>To receive this callback, libvlc_dialog_cbs.pf_cancel should not be NULL</remarks>
        public QuestionDialogCallback DisplayQuestion;

        /// <summary>
        /// Called when a progress dialog needs to be displayed
        /// 
        /// If cancellable (psz_cancel != NULL), you can cancel this dialog by
        /// calling libvlc_dialog_dismiss()
        /// </summary>
        /// <remarks>To receive this callback, libvlc_dialog_cbs.pf_cancel should not be NULL</remarks>
        public ProgressDialogCallback DisplayProgress;

        /// <summary>
        /// Called when a displayed dialog needs to be cancelled
        /// 
        /// The implementation must call libvlc_dialog_dismiss() to really release
        /// the dialog.
        /// </summary>
        public CancelDialogCallback Cancel;

        /// <summary>
        /// Called when a progress dialog needs to be updated
        /// </summary>
        public UpdateProgressDialogCallback UpdateProgress;
    }

    /// <summary>
    /// Register callbacks in order to handle VLC dialogs. LibVLC 3.0.0 and later.
    /// </summary>
    [LibVlcFunction("libvlc_dialog_set_callbacks")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetDialogCallbacks(IntPtr instance, /*ref DialogCallbacks?*/ IntPtr callbacks, IntPtr data);

    /// <summary>
    /// Associate an opaque pointer with the dialog id
    /// </summary>
    [LibVlcFunction("libvlc_dialog_set_context")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetDialogContext(IntPtr dialogId, IntPtr data);

    /// <summary>
    /// Return the opaque pointer associated with the dialog id
    /// </summary>
    [LibVlcFunction("libvlc_dialog_get_context")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr GetDialogContext(IntPtr dialogId);

    /// <summary>
    /// Post a login answer
    /// 
    /// After this call, p_id won't be valid anymore
    /// </summary>
    /// <returns>0 on success, or -1 on error</returns>
    [LibVlcFunction("libvlc_dialog_post_login")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int PostLogin(IntPtr dialogId, IntPtr username, IntPtr password, bool store);

    /// <summary>
    /// Post a question answer
    /// 
    /// After this call, p_id won't be valid anymore
    /// </summary>
    /// <returns>0 on success, or -1 on error</returns>
    [LibVlcFunction("libvlc_dialog_post_action")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int PostAction(IntPtr dialogId, int action);

    /// <summary>
    /// Dismiss a dialog
    /// 
    /// After this call, p_id won't be valid anymore
    /// </summary>
    /// <returns>0 on success, or -1 on error</returns>
    [LibVlcFunction("libvlc_dialog_dismiss")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int DismissDialog(IntPtr dialogId);
}
