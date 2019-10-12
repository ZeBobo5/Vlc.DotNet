#if !NET35 && !NET40

namespace Vlc.DotNet.Core
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Vlc.DotNet.Core.Interops.Signatures;

    public class LoginResult
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool StoreCredentials { get; set; }
    }

    public enum QuestionAction : int
    {
        Action1 = 1,
        Action2
    }

    /// <summary>
    /// The interface that you must implement in your code to handle dialogs
    /// </summary>
    public interface IVlcDialogManager
    {
        /// <summary>
        /// Displays an error dialog with the specified title and text.
        /// </summary>
        /// <param name="userdata">The user data, as given to the <see cref="DialogsManagement.UseDialogManager" /> method.</param>
        /// <param name="title">The dialog title</param>
        /// <param name="text">The dialog message</param>
        /// <returns>A task that is completed when the message is acknowledged by the user.</returns>
        Task DisplayErrorAsync(IntPtr userdata, string title, string text);

        /// <summary>
        /// Displays a login dialog.
        /// 
        /// There are three ways you can exit from this method:
        /// - The user has filled the login dialog and clicked OK. The task completes with a <see cref="LoginResult"/>
        /// - The user has cancelled the login dialog. The task completes with a <c>null</c> result
        /// - The dialog has been closed by libvlc. The cancellationToken is cancelled. In that case, you must close your dialog and <c>throw new TaskCanceledException</c>
        /// </summary>
        /// <param name="userdata">The user data, as given to the <see cref="DialogsManagement.UseDialogManager" /> method.</param>
        /// <param name="dialogId">The dialog identifier, as given by LibVlc</param>
        /// <param name="title">The dialog title</param>
        /// <param name="text">The dialog message</param>
        /// <param name="username">The default username to be displayed in the login box</param>
        /// <param name="askstore">A boolean indicating whether a checkbox "save credentials" should be displayed on the login dialog.</param>
        /// <param name="cancellationToken">The token that is cancelled when libvlc asks to cancel the dialog.</param>
        /// <exception cref="TaskCanceledException">When the cancellation token has been cancelled, and the dialog has been closed.</exception>
        /// <returns>The login information that the user has submitted, or <c>null</c> if (s)he clicked on "cancel"</returns>
        Task<LoginResult> DisplayLoginAsync(IntPtr userdata, IntPtr dialogId, string title, string text, string username, bool askstore, CancellationToken cancellationToken);

        /// <summary>
        /// Displays a question dialog.
        /// 
        /// There are three ways you can exit from this method:
        /// - The user has clicked on one of the two action buttons. The task completes with a <see cref="QuestionAction"/>
        /// - The user has cancelled the question dialog. The task completes with a <c>null</c> result
        /// - The dialog has been closed by libvlc. The cancellationToken is cancelled. In that case, you must close your dialog and <c>throw new TaskCanceledException</c>
        /// </summary>
        /// <param name="userdata">The user data, as given to the <see cref="DialogsManagement.UseDialogManager" /> method.</param>
        /// <param name="dialogId">The dialog identifier, as given by LibVlc</param>
        /// <param name="title">The dialog title</param>
        /// <param name="text">The dialog message</param>
        /// <param name="questionType">The kind of question</param>
        /// <param name="cancelButton">The text that is displayed on the button that cancels</param>
        /// <param name="action1Button">The text that is displayed on the first action button (or <c>null</c> if this button is not displayed)</param>
        /// <param name="action2Button">The text that is displayed on the second action button (or <c>null</c> if this button is not displayed)</param>
        /// <param name="cancellationToken">The token that is cancelled when libvlc asks to cancel the dialog.</param>
        /// <exception cref="TaskCanceledException">When the cancellation token has been cancelled, and the dialog has been closed.</exception>
        /// <returns>The action selected by the user, or <c>null</c> if (s)he clicked on "cancel"</returns>
        Task<QuestionAction?> DisplayQuestionAsync(IntPtr userdata, IntPtr dialogId, string title, string text,
            DialogQuestionType questionType, string cancelButton, string action1Button, string action2Button, CancellationToken cancellationToken);

        /// <summary>
        /// Displays a progress dialog.
        /// 
        /// There are two ways you can exit from this method:
        /// - The <see paramref="cancelButton" /> parameter is not <c>null</c> and the user clicked on cancel. The task completes.
        /// - The dialog has been closed by libvlc. The cancellationToken is cancelled. In that case, you must close your dialog and <c>throw new TaskCanceledException</c>
        /// </summary>
        /// <param name="userdata">The user data, as given to the <see cref="DialogsManagement.UseDialogManager" /> method.</param>
        /// <param name="dialogId">The dialog identifier, as given by LibVlc. The same identifier will be used in <see cref="UpdateProgress"/></param>
        /// <param name="title">The dialog title</param>
        /// <param name="text">The dialog message</param>
        /// <param name="indeterminate">A boolean indicating whether the progress is indeterminate.</param>
        /// <param name="position">The progress position (between 0.0 and 1.0)</param>
        /// <param name="cancelButton">The text to display on the "cancel" button, or <c>null</c> if the progress cannot be cancelled.</param>
        /// <param name="cancellationToken">The token that is cancelled when libvlc asks to cancel the dialog.</param>
        /// <exception cref="TaskCanceledException">When the cancellation token has been cancelled, and the dialog has been closed.</exception>
        /// <returns>The task that completes when the user cancels the dialog. Be careful, you cannot cancel the dialog if <see paramref="cancelButton" /> is null.</returns>
        Task DisplayProgressAsync(IntPtr userdata, IntPtr dialogId, string title, string text,
            bool indeterminate, float position, string cancelButton, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the previously displayed progress dialog.
        /// </summary>
        /// <param name="userdata">The user data, as given to the <see cref="DialogsManagement.UseDialogManager" /> method.</param>
        /// <param name="dialogId">The dialog identifier, as given by LibVlc. The same identifier was used in <see cref="DisplayProgress"/></param>
        /// <param name="position">The progress position (between 0.0 and 1.0)</param>
        /// <param name="text">The dialog message</param>
        void UpdateProgress(IntPtr userdata, IntPtr dialogId, float position, string text);
    }
}

#endif