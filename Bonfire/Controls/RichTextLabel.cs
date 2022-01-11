using System.Drawing;
using System.Windows.Forms;

namespace Bonfire.Controls
{
    public class RichTextLabel : RichTextBox
    {
        public RichTextLabel()
        {
            base.BorderStyle = BorderStyle.None;
            base.BackColor = Color.FromArgb(74, 74, 74);
            base.TabStop = false;
            base.ReadOnly = true;
            base.WordWrap = true;
            AutoWordSelection = false;
            base.ScrollBars = RichTextBoxScrollBars.None;
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            ContentsResized += RichTextLabel_ContentsResized;
            MouseWheel += RichTextLabel_MouseWheel;
        }

        private void RichTextLabel_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void RichTextLabel_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            //base.Size = new Size(e.NewRectangle.Width, e.NewRectangle.Height + 5);
            base.Height = e.NewRectangle.Height + 5;
        }
    }
}
