using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bonfire
{
    public static class NativeFunctions
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static class ResizableWindow
        {
            private const int
                HTLEFT = 10,
                HTRIGHT = 11,
                HTTOP = 12,
                HTTOPLEFT = 13,
                HTTOPRIGHT = 14,
                HTBOTTOM = 15,
                HTBOTTOMLEFT = 16,
                HTBOTTOMRIGHT = 17;

            const int cornerSize = 50; // you can rename this variable if you like

            public static void OnPaint(Form _this, PaintEventArgs e)
            {
                Rectangle Top = new Rectangle(cornerSize, 0, _this.ClientSize.Width - cornerSize, cornerSize);
                Rectangle Left = new Rectangle(0, cornerSize, cornerSize, _this.ClientSize.Height - cornerSize);
                Rectangle Bottom = new Rectangle(cornerSize, _this.ClientSize.Height - cornerSize, _this.ClientSize.Width - cornerSize, cornerSize);
                Rectangle Right = new Rectangle(_this.ClientSize.Width - cornerSize, cornerSize, cornerSize, _this.ClientSize.Height - cornerSize);

                e.Graphics.FillRectangle(Brushes.Green, Top);
                e.Graphics.FillRectangle(Brushes.Green, Left);
                e.Graphics.FillRectangle(Brushes.Green, Right);
                e.Graphics.FillRectangle(Brushes.Green, Bottom);
            }

            public static void WndProc(Form _this, ref Message message)
            {
                if (message.Msg != 0x84) // WM_NCHITTEST
                {
                    return;
                }

                Rectangle Top = new Rectangle(cornerSize, 0, _this.ClientSize.Width - cornerSize, cornerSize);
                Rectangle Left = new Rectangle(0, cornerSize, cornerSize, _this.ClientSize.Height - cornerSize);
                Rectangle Bottom = new Rectangle(cornerSize, _this.ClientSize.Height - cornerSize, _this.ClientSize.Width - cornerSize, cornerSize);
                Rectangle Right = new Rectangle(_this.ClientSize.Width - cornerSize, cornerSize, cornerSize, _this.ClientSize.Height - cornerSize);

                Rectangle TopLeft = new Rectangle(0, 0, cornerSize, cornerSize);
                Rectangle TopRight = new Rectangle(_this.ClientSize.Width - cornerSize, 0, cornerSize, cornerSize);
                Rectangle BottomLeft = new Rectangle(0, _this.ClientSize.Height - cornerSize, cornerSize, cornerSize);
                Rectangle BottomRight = new Rectangle(_this.ClientSize.Width - cornerSize, _this.ClientSize.Height - cornerSize, cornerSize, cornerSize);

                var cursor = _this.PointToClient(Cursor.Position);
                cursor.X = Math.Max(Math.Min(cursor.X, _this.ClientSize.Width - 1), 0);
                cursor.Y = Math.Max(Math.Min(cursor.Y, _this.ClientSize.Height - 1), 0);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }
    }
}
