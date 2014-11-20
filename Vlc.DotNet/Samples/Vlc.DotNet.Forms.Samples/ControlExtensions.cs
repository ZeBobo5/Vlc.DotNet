using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Vlc.DotNet.Forms.Samples
{
    public static class ControlExtensions
    {
#if !NET20
        public static T InvokeIfRequired<T>(this T source, Action<T> action)
            where T : Control
        {
            try
            {
                if (!source.InvokeRequired)
                    action(source);
                else
                    source.Invoke(new Action(() => action(source)));
                return source;
            }
            catch (Exception ex)
            {
                Debug.Write("Error on 'InvokeIfRequired': {0}", ex.Message);
            }
        }
#else
        delegate void InvokeIfRequiredDelegate(Control ctrl, Action<Control> action);

        public static void InvokeIfRequired(Control ctrl, Action<Control> action)
        {
            try
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new InvokeIfRequiredDelegate(ControlExtensions.InvokeIfRequired), ctrl, action);
                }
                else
                {
                    action(ctrl);
                }
            }
            catch(Exception ex)
            {
                Debug.Write("Error on 'InvokeIfRequired': {0}", ex.Message);
            }
        }
#endif
    }
}
