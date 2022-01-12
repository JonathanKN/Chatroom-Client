using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bonfire.Controls
{
    public class RichTextLabel : RichTextBox
    {
        private FlowLayoutPanel messagePanel;

        public RichTextLabel(FlowLayoutPanel messagePanel)
        {
            this.messagePanel = messagePanel;
            BorderStyle = BorderStyle.None;
            BackColor = Color.FromArgb(74, 74, 74);
            TabStop = false;
            ReadOnly = true;
            Cursor = Cursors.Arrow;
            WordWrap = true;
            AutoWordSelection = false;
            ScrollBars = RichTextBoxScrollBars.None;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            ContentsResized += RichTextLabel_ContentsResized;
            MouseWheel += RichTextLabel_MouseWheel;
            MouseDown += RichTextLabel_Mouse;
            MouseUp += RichTextLabel_Mouse;
        }

        private void RichTextLabel_Mouse(object sender, MouseEventArgs e)
        {
            AutoWordSelection = true;
            AutoWordSelection = false;
            HideCaret(this.Handle);
        }

        protected override void OnEnter(EventArgs e)
        {
            HideCaret(this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            // WM_SETCURSOR
            if (m.Msg == 0x0020)
            {
                Cursor.Current = this.Cursor;
            }else
            {
                base.WndProc(ref m);
            }
        }

        [DllImport("user32.dll")]
        private static extern int HideCaret(IntPtr hwnd);

        private void RichTextLabel_MouseWheel(object sender, MouseEventArgs e)
        {
            int newValue = messagePanel.VerticalScroll.Value - e.Delta;
            newValue = Math.Max(Math.Min(newValue, messagePanel.VerticalScroll.Maximum), messagePanel.VerticalScroll.Minimum);
            messagePanel.VerticalScroll.Value = newValue;
            messagePanel.PerformLayout();
        }

        private void RichTextLabel_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            //base.Size = new Size(e.NewRectangle.Width, e.NewRectangle.Height + 5);
            base.Height = e.NewRectangle.Height + 5;
        }
    }
}
