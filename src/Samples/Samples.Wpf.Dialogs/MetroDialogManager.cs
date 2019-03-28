namespace Samples.Wpf.Dialogs
{
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using Vlc.DotNet.Core;
    using Vlc.DotNet.Core.Interops.Signatures;


    /// <summary>
    /// An implementation of <see cref="IVlcDialogManager"/> for Mahapps.Metro
    /// </summary>
    public class MetroDialogManager : IVlcDialogManager
    {
        /// <summary>
        /// The metro window used to display the dialogs
        /// </summary>
        private readonly MetroWindow metroWindow;

        /// <summary>
        /// The controller of the progress dialog that is currently displayed
        /// </summary>
        private ProgressDialogController currentProgressController;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="metroWindow">The metro window on which to display the dialogs</param>
        public MetroDialogManager(MetroWindow metroWindow)
        {
            this.metroWindow = metroWindow;
        }

        /// <summary>
        /// Displays an error dialog with the specified title and text.
        /// </summary>
        /// <param name="userdata">The user data, as given to the <see cref="DialogsManagement.UseDialogManager" /> method.</param>
        /// <param name="title">The dialog title</param>
        /// <param name="text">The dialog message</param>
        /// <returns>A task that is completed when the message is acknowledged by the user.</returns>
        public Task DisplayErrorAsync(IntPtr userdata, string title, string text)
        {
            // Invokes the ShowMessageAsync function on the dispatcher and waits for it to finish asynchronously.
            return this.metroWindow.Dispatcher.InvokeAsync(() => this.metroWindow.ShowMessageAsync(title, text)).Task.Unwrap();
        }
        
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
        public async Task<LoginResult> DisplayLoginAsync(IntPtr userdata, IntPtr dialogId, string title, string text, string username, bool askstore,
            CancellationToken cancellationToken)
        {
            // The login dialog is built into Mahapps.Metro, you just need to call it from the Dispatcher
            var result = await this.metroWindow.Dispatcher.InvokeAsync(() => this.metroWindow.ShowLoginAsync(title, text, new LoginDialogSettings
            {
                InitialUsername = username,
                CancellationToken = cancellationToken,
                RememberCheckBoxVisibility = askstore ? Visibility.Visible : Visibility.Collapsed
            })).Task.Unwrap();

            // Case 1 : The cancellation token has been cancelled. As required by Vlc.DotNet, we must throw TaskCanceledException.
            if (cancellationToken.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }

            // Case 2 : The user has canceled the login dialog
            if (result == null)
            {
                return null;
            }

            // Case 3 : Credentials has been submitted
            return new LoginResult
            {
                Username = string.IsNullOrEmpty(result.Username) ? null : result.Username,
                Password = string.IsNullOrEmpty(result.Password) ? null : result.Password,
                StoreCredentials = result.ShouldRemember
            };
        }

        /// <summary>
        /// Displays a progress dialog.
        /// 
        /// There are two ways you can exit from this method:
        /// - The <see paramref="cancelButton" /> parameter is not <c>null</c> and the user clicked on cancel. The task completes.
        /// - The dialog has been closed by libvlc. The cancellationToken is cancelled. In that case, you must close your dialog and <c>throw new TaskCanceledException</c>
        /// </summary>
        /// <param name="userdata">The user data, as given to the <see cref="DialogsManagement.UseDialogManager" /> method.</param>
        /// <param name="dialogId">The dialog identifier, as given by LibVlc. The same identifier will be used in <see cref="IVlcDialogManager.UpdateProgress"/></param>
        /// <param name="title">The dialog title</param>
        /// <param name="text">The dialog message</param>
        /// <param name="indeterminate">A boolean indicating whether the progress is indeterminate.</param>
        /// <param name="position">The progress position (between 0.0 and 1.0)</param>
        /// <param name="cancelButton">The text to display on the "cancel" button, or <c>null</c> if the progress cannot be cancelled.</param>
        /// <param name="cancellationToken">The token that is cancelled when libvlc asks to cancel the dialog.</param>
        /// <exception cref="TaskCanceledException">When the cancellation token has been cancelled, and the dialog has been closed.</exception>
        /// <returns>The task that completes when the user cancels the dialog. Be careful, you cannot cancel the dialog if <see paramref="cancelButton" /> is null.</returns>
        public async Task DisplayProgressAsync(IntPtr userdata, IntPtr dialogId, string title, string text, bool indeterminate, float position,
            string cancelButton, CancellationToken cancellationToken)
        {
            // TODO : Warning: This code has never been tested... How to produce a progress dialog?

            // Create the progress dialog and store it in this instance. In theory, libvlc can manage several dialogs at the same time, using several dialogId,
            // but in practice, I don't know if that could happen.
            this.currentProgressController = await this.metroWindow.Dispatcher.InvokeAsync(() => this.metroWindow.ShowProgressAsync(title, text, cancelButton != null, new MetroDialogSettings
            {
                NegativeButtonText = cancelButton,
            })).Task.Unwrap();

            try
            {
                // Libvlc returns progress in the range 0-1
                this.currentProgressController.Minimum = 0;
                this.currentProgressController.Maximum = 1;

                // Set the progress in the dispatcher
                if (!indeterminate)
                {
                    await this.metroWindow.Dispatcher.InvokeAsync(() => this.currentProgressController.SetProgress(position)).Task;
                }

                var taskCompletionSource = new TaskCompletionSource<bool>();
                // Case 1 : libvlc asks to close the progress dialog
                var onCancellationTokenCancelled = (Action) (() =>
                {
                    taskCompletionSource.TrySetResult(false);
                });

                // Case 2 : The user has clicked on the cancel button
                this.currentProgressController.Canceled += (sender, args) =>
                {
                    taskCompletionSource.TrySetResult(true);
                };

                using (var registration = cancellationToken.Register(onCancellationTokenCancelled))
                {
                    // Wait for the progress dialog to finish
                    var isCanceledByUser = await taskCompletionSource.Task;

                    // Close the dialog
                    await this.metroWindow.Dispatcher.InvokeAsync(() => this.currentProgressController.CloseAsync()).Task.Unwrap();

                    if (isCanceledByUser)
                    {
                        // Case 1 : Throw the exception as required
                        throw new TaskCanceledException();
                    }
                }
            }
            finally
            {
                this.currentProgressController = null;
            }
        }

        /// <summary>
        /// Updates the previously displayed progress dialog.
        /// </summary>
        /// <param name="userdata">The user data, as given to the <see cref="DialogsManagement.UseDialogManager" /> method.</param>
        /// <param name="dialogId">The dialog identifier, as given by LibVlc. The same identifier was used in <see cref="IVlcDialogManager.DisplayProgress"/></param>
        /// <param name="position">The progress position (between 0.0 and 1.0)</param>
        /// <param name="text">The dialog message</param>
        public void UpdateProgress(IntPtr userdata, IntPtr dialogId, float position, string text)
        {
            this.metroWindow.BeginInvoke(() =>
            {
                this.currentProgressController?.SetMessage(text);
                this.currentProgressController?.SetProgress(position);
            });
        }

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
        public async Task<QuestionAction?> DisplayQuestionAsync(IntPtr userdata, IntPtr dialogId, string title, string text, DialogQuestionType questionType,
            string cancelButton, string action1Button, string action2Button, CancellationToken cancellationToken)
        {
            MessageDialogStyle dialogStyle;
            string negativeButtonText = null;
            string affirmativeButtonText = null;
            string auxiliaryAction1 = null;

            if (action1Button == null && action2Button == null)
            {
                // No button is specified, just a cancel button, but Mahapps has no "NegativeOnly" dialog, let's put cancel on the Ok button
                dialogStyle = MessageDialogStyle.Affirmative;
                affirmativeButtonText = cancelButton;
            }
            else if (action1Button != null && action2Button != null)
            {
                dialogStyle = MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary;
                affirmativeButtonText = action1Button;
                auxiliaryAction1 = action2Button;
                negativeButtonText = cancelButton;
            }
            else if(action1Button != null)
            {
                dialogStyle = MessageDialogStyle.AffirmativeAndNegative;
                affirmativeButtonText = action1Button;
                negativeButtonText = cancelButton;
            }
            else
            {
                // Handle the case where action2 is specified but not action1 . I don't know if this is possible.
                dialogStyle = MessageDialogStyle.AffirmativeAndNegative;
                affirmativeButtonText = action2Button;
                negativeButtonText = cancelButton;
            }
            
            var result = await this.metroWindow.Dispatcher.InvokeAsync(() => this.metroWindow.ShowMessageAsync(title, text, dialogStyle, new MetroDialogSettings
            {
                CancellationToken = cancellationToken,
                AffirmativeButtonText = affirmativeButtonText,
                FirstAuxiliaryButtonText = auxiliaryAction1,
                NegativeButtonText = negativeButtonText
            })).Task.Unwrap();

            // Case 1 : libvlc cancelled the dialog, throw as required
            if (cancellationToken.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }

            // Case 2 : User clicked on "cancel"
            if (result == MessageDialogResult.Canceled || result == MessageDialogResult.Negative || dialogStyle == MessageDialogStyle.Affirmative)
            {
                return null;
            }
            else if (result == MessageDialogResult.FirstAuxiliary)
            {
                return QuestionAction.Action2;
            }
            else if (action1Button == null)
            {
                // Case where only action2 is specified, then the "affirmative" button is Action2
                return QuestionAction.Action2;
            }
            else
            {
                return QuestionAction.Action1;
            }
        }
    }
}