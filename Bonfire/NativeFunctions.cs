using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bonfire
{
    /// <summary>
    /// Class containing native interoping functions.
    /// NOTE: Warnings are disabled (via .editorconfig) for this file.
    /// </summary>
    public static class NativeFunctions
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Resizing
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

        // Flashing taskbar icon
        public static class FlashTaskbar
        {
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

            [StructLayout(LayoutKind.Sequential)]
            public struct FLASHWINFO
            {
                public UInt32 cbSize;
                public IntPtr hwnd;
                public UInt32 dwFlags;
                public UInt32 uCount;
                public UInt32 dwTimeout;
            }

            public enum FlashWindow : uint
            {
                /// <summary>
                /// Stop flashing. The system restores the window to its original state.
                /// </summary>    
                FLASHW_STOP = 0,

                /// <summary>
                /// Flash the window caption
                /// </summary>
                FLASHW_CAPTION = 1,

                /// <summary>
                /// Flash the taskbar button.
                /// </summary>
                FLASHW_TRAY = 2,

                /// <summary>
                /// Flash both the window caption and taskbar button.
                /// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
                /// </summary>
                FLASHW_ALL = 3,

                /// <summary>
                /// Flash continuously, until the FLASHW_STOP flag is set.
                /// </summary>
                FLASHW_TIMER = 4,

                /// <summary>
                /// Flash continuously until the window comes to the foreground.
                /// </summary>
                FLASHW_TIMERNOFG = 12,
            }

            public static bool FlashWindowUntilFocus(Form form)
            {
                IntPtr hWnd = form.Handle;
                FLASHWINFO fInfo = new FLASHWINFO();

                fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
                fInfo.hwnd = hWnd;
                fInfo.dwFlags = (uint)(FlashWindow.FLASHW_TIMERNOFG | FlashWindow.FLASHW_TRAY);
                fInfo.uCount = UInt32.MaxValue;
                fInfo.dwTimeout = 0;

                return FlashWindowEx(ref fInfo);
            }
        }
    }
}
