using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Bonfire
{
    /// <summary>
    /// A form used for adding new servers.
    /// </summary>
    public partial class AddServerPrompt : Form
    {
        private readonly string[] reservedServernames;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddServerPrompt"/> class.
        /// </summary>
        /// <param name="reservedServernames"></param>
        public AddServerPrompt(string[] reservedServernames)
        {
            Thread.CurrentThread.CurrentUICulture = PreferenceHelper.LoadedLanguage;
            InitializeComponent();

            this.reservedServernames = reservedServernames;
            this.AcceptButton = AddServerBtn;
            this.CancelButton = buttonClose;
            labelInvalidIP.Visible = false;
            labelInvalidPort.Visible = false;
            labelInvalidServerNickname.Visible = false;
        }

        /// <summary>
        /// Gets the entered IP/hostname value.
        /// </summary>
        public string IP { get; private set; }

        /// <summary>
        /// Gets the entered port value.
        /// </summary>
        public ushort Port { get; private set; }

        /// <summary>
        /// Gets the server nickname.
        /// </summary>
        public string ServerNickname { get; private set; }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddServerPrompt_Load(object sender, EventArgs e)
        {
        }

        private void AddServerBtn_Click(object sender, EventArgs e)
        {
            labelInvalidPort.Visible = !ushort.TryParse(ServerPortInput.Text, out ushort port);
            Port = port;

            labelInvalidServerNickname.Visible = reservedServernames.Contains(ServerNicknameInput.Text);

            if (labelInvalidPort.Visible || labelInvalidIP.Visible || labelInvalidServerNickname.Visible)
            {
                return;
            }

            IP = ServerIPInput.Text;
            if (ServerNicknameInput.Text == string.Empty)
            {
                ServerNickname = IP;
            }
            else
            {
                ServerNickname = ServerNicknameInput.Text;
            }

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
