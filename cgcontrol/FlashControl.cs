using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CGPreviewControl
{
    public class FlashControl : AxShockwaveFlashObjects.AxShockwaveFlash
    {
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_LBUTTONDBLCLK = 0x0203; 
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;                      

        public new event MouseEventHandler DoubleClick;
        public new event MouseEventHandler MouseDown;
        public new event MouseEventHandler MouseUp;
        public new event MouseEventHandler MouseMove;

        public FlashControl()
            : base()
        {
        }

        protected override void WndProc(ref Message m) // Override's the WndProc and disables Flash activex's default right-click menu and if exists shows the attached ContextMenuStrip.
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                if (this.MouseDown != null) this.MouseDown(this, new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, Cursor.Position.X, Cursor.Position.Y, 0));
            }
            else if (m.Msg == WM_LBUTTONUP)
            {
                if (this.MouseUp != null) this.MouseUp(this, new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, Cursor.Position.X, Cursor.Position.Y, 0));
            }
            else if (m.Msg == WM_MOUSEMOVE)
            {
                if (this.MouseMove != null) this.MouseMove(this, new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, Cursor.Position.X, Cursor.Position.Y, 0));
            }
            else if (m.Msg == WM_RBUTTONDOWN)
            {
                if (this.ContextMenuStrip != null) this.ContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
                m.Result = IntPtr.Zero;
                return;
            }
            else if (m.Msg == WM_LBUTTONDBLCLK)
            {
                if (this.DoubleClick != null) this.DoubleClick(this, new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 2, Cursor.Position.X, Cursor.Position.Y, 0));
                m.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);
        }
    }
}
