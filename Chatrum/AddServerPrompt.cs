using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Chatrum
{
    public partial class AddServerPrompt : Form
    {
        public string IP;
        public short Port;
        public string ServerNickname;

        public AddServerPrompt()
        {
            Thread.CurrentThread.CurrentUICulture = Properties.Settings.Default.Language;
            InitializeComponent();
            this.AcceptButton = AddServerBtn;
            this.CancelButton = buttonClose;
            labelInvalidIP.Visible = false;
            labelInvalidPort.Visible = false;
            labelInvalidServerNickname.Visible = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddServerPrompt_Load(object sender, EventArgs e)
        {

        }

        private void AddServerBtn_Click(object sender, EventArgs e)
        {
            labelInvalidPort.Visible = !short.TryParse(ServerPortInput.Text, out Port);
            labelInvalidIP.Visible = !IPAddress.TryParse(ServerIPInput.Text, out _);

            if (labelInvalidPort.Visible || labelInvalidIP.Visible || labelInvalidServerNickname.Visible)
            {
                return;
            }

            IP = ServerIPInput.Text;
            ServerNickname = ServerNicknameInput.Text;

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void AddServerPrompt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeFunctions.ReleaseCapture();
                NativeFunctions.SendMessage(Handle, NativeFunctions.WM_NCLBUTTONDOWN, NativeFunctions.HT_CAPTION, 0);
            }
        }
    }
}
