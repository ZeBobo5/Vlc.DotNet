#if !NET35 && !NET40
namespace Vlc.DotNet.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Vlc.DotNet.Core.Interops.Signatures;
    using Vlc.DotNet.Core.Interops;

    public class DialogsManagement : IDialogsManagement
    {
        private readonly VlcManager myManager;
        private readonly VlcMediaPlayerInstance myMediaPlayer;

        private IVlcDialogManager currentDialogManager;

        private Dictionary<IntPtr, CancellationTokenSource> openDialogsCancellationTokens = new Dictionary<IntPtr, CancellationTokenSource>();

        public DialogsManagement(VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance)
        {
            myManager = manager;
            myMediaPlayer = mediaPlayerInstance;
        }

        public void UseDialogManager(IVlcDialogManager dialogManager, IntPtr data = default(IntPtr))
        {
            foreach (var cts in this.openDialogsCancellationTokens.Values)
            {
                if (!cts.IsCancellationRequested)
                {
                    cts.Cancel();
                }
            }

            this.currentDialogManager = dialogManager;
            if (dialogManager == null)
            {
                this.openDialogsCancellationTokens = null;
                this.myManager.SetDialogCallbacks(null, data);
            }
            else
            {
                this.openDialogsCancellationTokens = new Dictionary<IntPtr, CancellationTokenSource>();
                this.myManager.SetDialogCallbacks(new DialogCallbacks
                {
                    DisplayError = this.OnDisplayError,
                    DisplayLogin = this.OnDisplayLogin,
                    DisplayQuestion = this.OnDisplayQuestion,
                    DisplayProgress = this.OnDisplayProgress,
                    UpdateProgress = this.OnUpdateProgress,
                    Cancel = this.OnCancel
                }, data);
            }
        }

        private void OnDisplayError(IntPtr userdata, IntPtr title, IntPtr text)
        {
            string strTitle = Utf8InteropStringConverter.Utf8InteropToString(title);
            string strText = Utf8InteropStringConverter.Utf8InteropToString(text);
            Task.Run(() => this.currentDialogManager?.DisplayErrorAsync(userdata, strTitle, strText));
        }

        private void OnDisplayLogin(IntPtr userdata, IntPtr dialogid, IntPtr title, IntPtr text, IntPtr defaultusername, bool askstore)
        {
            string strTitle = Utf8InteropStringConverter.Utf8InteropToString(title);
            string strText = Utf8InteropStringConverter.Utf8InteropToString(text);
            string strUsername = Utf8InteropStringConverter.Utf8InteropToString(defaultusername);
            var cts = new CancellationTokenSource();
            this.openDialogsCancellationTokens.Add(dialogid,cts);
            Task.Run(() => this.currentDialogManager.DisplayLoginAsync(userdata, dialogid, strTitle, strText, strUsername, askstore, cts.Token))
                .ContinueWith(task =>
                {
                    if (task.IsCompleted && task.Result != null)
                    {
                        using (var usr = Utf8InteropStringConverter.ToUtf8StringHandle(task.Result.Username))
                        using (var pass = Utf8InteropStringConverter.ToUtf8StringHandle(task.Result.Password))
                        {
                            this.myManager.PostLogin(dialogid, usr, pass, task.Result.StoreCredentials);
                        }
                    }
                    else if(!task.IsCanceled)
                    {
                        this.myManager.DismissDialog(dialogid);
                    }

                    this.openDialogsCancellationTokens.Remove(dialogid);
                });
        }

        private void OnDisplayQuestion(IntPtr userdata, IntPtr dialogid, IntPtr title, IntPtr text, DialogQuestionType questiontype, IntPtr cancel, IntPtr action1, IntPtr action2)
        {
            string strTitle = Utf8InteropStringConverter.Utf8InteropToString(title);
            string strText = Utf8InteropStringConverter.Utf8InteropToString(text);
            string strCancelButton = Utf8InteropStringConverter.Utf8InteropToString(cancel);
            string strAction1Button = Utf8InteropStringConverter.Utf8InteropToString(action1);
            string strAction2Button = Utf8InteropStringConverter.Utf8InteropToString(action2);
            var cts = new CancellationTokenSource();
            this.openDialogsCancellationTokens.Add(dialogid, cts);
            Task.Run(() => this.currentDialogManager.DisplayQuestionAsync(userdata, dialogid, strTitle, strText, questiontype, strCancelButton, strAction1Button, strAction2Button, cts.Token))
                .ContinueWith((Action<Task<QuestionAction?>>)(task =>
                {
                    if (task.IsCompleted && task.Result != null)
                    {
                        this.myManager.PostAction(dialogid, (int)task.Result.Value);
                    }
                    else if (!task.IsCanceled)
                    {
                        this.myManager.DismissDialog(dialogid);
                    }

                    this.openDialogsCancellationTokens.Remove(dialogid);
                }));
        }

        private void OnDisplayProgress(IntPtr userdata, IntPtr dialogid, IntPtr title, IntPtr text, bool indeterminate, float position, IntPtr cancel)
        {
            string strTitle = Utf8InteropStringConverter.Utf8InteropToString(title);
            string strText = Utf8InteropStringConverter.Utf8InteropToString(text);
            string strCancelButton = Utf8InteropStringConverter.Utf8InteropToString(cancel);
            var cts = new CancellationTokenSource();
            this.openDialogsCancellationTokens.Add(dialogid, cts);
            Task.Run(() => this.currentDialogManager.DisplayProgressAsync(userdata, dialogid, strTitle, strText, indeterminate, position, strCancelButton, cts.Token))
                .ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        this.myManager.DismissDialog(dialogid);
                    }

                    this.openDialogsCancellationTokens.Remove(dialogid);
                });
        }

        private void OnUpdateProgress(IntPtr userdata, IntPtr dialogid, float position, IntPtr text)
        {
            string strText = Utf8InteropStringConverter.Utf8InteropToString(text);
            Task.Run(() => this.currentDialogManager.UpdateProgress(userdata, dialogid, position, strText));
        }

        private void OnCancel(IntPtr userdata, IntPtr dialogid)
        {
            if (this.openDialogsCancellationTokens.TryGetValue(dialogid, out var cts))
            {
                cts.Cancel();
            }
        }
    }
}
#endif