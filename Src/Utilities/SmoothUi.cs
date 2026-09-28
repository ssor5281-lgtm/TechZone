using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TechZone.Utilities
{
    public static class SmoothUi
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WmSetredraw = 11;

        /// <summary>
        /// Call this once when your app starts (in Program.cs)
        /// </summary>
        public static void EnableGlobalSmooth()
        {
            // Nothing needed here — the real magic is the extension methods below
        }

        // Extension for any Form / UserControl / Panel
        public static void BeginSmoothUpdate(this Control control)
        {
            SendMessage(control.Handle, WmSetredraw, false, 0);
        }

        public static void EndSmoothUpdate(this Control control, bool refresh = true)
        {
            SendMessage(control.Handle, WmSetredraw, true, 0);
            if (refresh)
                control.Refresh();
        }
    }
}