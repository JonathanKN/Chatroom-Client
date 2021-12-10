using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Chatrum
{
    public partial class FormMain : Form
    {
        public Dictionary<string, Server> servers = new Dictionary<string, Server>();

        private string name = "Person";
        private Chatroom_Client_Backend.NetworkClient networkClient;
        private Dictionary<int, string> users = new Dictionary<int, string>();

        public FormMain()
        {
            // Denne "metode" må sådan set ikke bruges til andet end initialisering.
            // Derfor bruger man OnLoad i stedet.
            Thread.CurrentThread.CurrentUICulture = Properties.Settings.Default.Language;
            InitializeComponent();
            // Resize logik
            SetStyle(ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AddServer(25565, "", "Esperanto server");
            //networkClient = new Chatroom_Client_Backend.NetworkClient(name, servers["Esperanto server"].ip, servers["Esperanto server"].port);
        }

        public void OnMessage(int userID, string message, long timeStamp)
        {
            AddMessage(message, users[userID], timeStamp);
        }

        public void OnUserIDRecieved(int userID)
        {
            users.Add(userID, "Anonym person");
        }

        public void OnUserInfoRecieved(int userID, string userName)
        {
            users[userID] = userName;
            AddOnlinePerson(userName);
        }

        public void OnUserLeft(int userID)
        {
            RemoveOnlinePerson(users[userID]);
            users.Remove(userID);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsWindow settings = new SettingsWindow(name);
            //settings.Show();
            switch (settings.ShowDialog())
            {
                case DialogResult.Yes:
                    networkClient.ChangeName(settings.name);
                    name = settings.name;
                    break;
                default:
                    // Anything other than yes
                    break;
            }
        }

        private void ServerMenuBtn_Click(object sender, EventArgs e)
        {
            AddServerPrompt prompt = new AddServerPrompt();
            switch (prompt.ShowDialog())
            {
                case DialogResult.Yes:
                    //Connect to new server
                    //If it works, addserver(new server)
                    if (!int.TryParse(prompt.ServerPortInput.Text, out int serverPort))
                    {
                        // Imparsable port.
                        return;
                    }

                    if (!IPAddress.TryParse(prompt.ServerIPInput.Text, out _))
                    {
                        // Invalid IP address.
                        return;
                    }

                    AddServer(serverPort, prompt.ServerIPInput.Text);
                    break;
                default:
                    // Anything other than yes
                    break;
            }
        }

        public void AddServer(int port, string ip, string server = "Ny server")
        {
            Panel serverBox = new Panel();
            Label serverText = new Label();
            serverText.Text = server;
            serverText.Dock = DockStyle.Fill;
            serverText.TextAlign = ContentAlignment.MiddleLeft;
            serverText.Padding = new Padding(12, 0, 0, 0);
            serverText.Font = new Font("Microsoft Sans Serif", 11);

            serverBox.Controls.Add(serverText);

            serverBox.Width = ServerList.Width-17;
            serverBox.Height = 40;
            serverBox.Margin = new Padding(0);

            ServerList.Controls.Add(serverBox);

            if (ServerList.Controls.IndexOf(serverBox) % 2 == 0)
            {
                serverBox.BackColor = Color.DarkGray;
            }
            else
            {
                serverBox.BackColor = Color.Gray;
            }

            serverText.MouseEnter += ServerText_MouseEnter;
            serverText.MouseLeave += ServerText_MouseLeave;
            serverText.MouseClick += ServerText_MouseClick;

            Server s = new Server();
            s.port = port;
            s.ip = ip;
            servers.Add(server, s);
        }

        private void ServerText_MouseEnter(object sender, EventArgs e)
        {
            Label serverText = sender as Label;
            Panel serverBox = serverText.Parent as Panel;
            serverBox.BackColor = Color.FromArgb(serverBox.BackColor.R - 20, serverBox.BackColor.R - 20, serverBox.BackColor.R - 20);
        }

        private void ServerText_MouseLeave(object sender, EventArgs e)
        {
            Label serverText = sender as Label;
            Panel serverBox = serverText.Parent as Panel;
            serverBox.BackColor = Color.FromArgb(serverBox.BackColor.R + 20, serverBox.BackColor.R + 20, serverBox.BackColor.R + 20);
        }

        private void ServerText_MouseClick(object sender, EventArgs e)
        {
            Label serverText = sender as Label;
            if (ServerName.Text == serverText.Text)
            {
                return;
            }

            //networkClient.Disconnect();
            //networkClient = new Chatroom_Client_Backend.NetworkClient(name, serverText.Text, servers[serverText.Text].port);
            ServerName.Text = serverText.Text;
            MessageContainer.Controls.Clear();
        }

        public void AddMessage(string message, string sender, /*DateTime*/ long date)
        {
            MessageContainer.SuspendLayout();
            Label messageLabel = new Label();
            Label senderLebal = new Label();
            Label dateLabel = new Label();

            messageLabel.Text = message;
            senderLebal.Text = sender;
            dateLabel.Text = date.ToString();

            messageLabel.ForeColor = Color.LightGray;
            senderLebal.ForeColor = Color.LightGray;
            dateLabel.ForeColor = Color.Gray;

            messageLabel.Font = new Font("Microsoft Sans Serif", 13);
            senderLebal.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            dateLabel.Font = new Font("Microsoft Sans Serif", 11);

            messageLabel.AutoSize = true;
            senderLebal.AutoSize = true;
            dateLabel.AutoSize = true;

            messageLabel.Margin = new Padding(20, 0, 0, 10);
            messageLabel.Width = MessageContainer.Width - OnlineList.Width - 40;

            FlowLayoutPanel messageSender = new FlowLayoutPanel();
            messageSender.AutoSize = true;
            messageSender.Margin = new Padding(20, 0, 0, 0);
            messageSender.Controls.Add(senderLebal);
            messageSender.Controls.Add(dateLabel);

            MessageContainer.Controls.Add(messageLabel);
            MessageContainer.Controls.Add(messageSender);

            MessageContainer.Controls.SetChildIndex(messageSender, 0);
            MessageContainer.Controls.SetChildIndex(messageLabel, 0);
            MessageContainer.ResumeLayout();


            MessageContainer.AutoScrollPosition = new Point(splitContainer1.Panel1.Width, int.MaxValue);
        }

        public void AddOnlinePerson(string name)
        {
            Label person = new Label();
            person.Text = name;
            person.Name = name;
            person.ForeColor = Color.LightGray;
            person.Font = new Font("Microsoft Sans Serif", 13);
            person.Margin = new Padding(0,0,0,2);
            person.AutoSize = true;
            OnlineList.Controls.Add(person);
        }

        public void RemoveOnlinePerson(string name)
        {
            OnlineList.Controls.Remove(OnlineList.Controls.Find(name, false)[0]);
        }

        private void MessageBox_KeyDown(object sender, KeyEventArgs key)
        {
            if (key.KeyCode == Keys.Enter && MessageBox.TextLength > 0)
            {
                AddMessage(MessageBox.Text, "Johnny", (long)DateTime.Now.Ticks);
                //networkClient.SendMessage(MessageBox.Text);
                MessageBox.Text = "";
            }
        }

        private void MessageBox_Enter(object sender, EventArgs e)
        {
            if (MessageBox.Text == "Skriv din besked her...")
            {
                MessageBox.Text = "";
            }
        }

        private void MessageBox_Leave(object sender, EventArgs e)
        {
            if (MessageBox.Text == "")
            {
                MessageBox.Text = "Skriv din besked her...";
            }
        }

        private void checkBoxClose_CheckedChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxResizeFull_CheckedChanged(object sender, EventArgs e)
        {
            WindowState = checkBoxResizeFull.Checked ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void checkBoxMinimize_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxMinimize.Checked)
            {
                // prevent recursion.
                return;
            }

            WindowState = FormWindowState.Minimized;
            checkBoxMinimize.Checked = false;
        }

        private void panelTopBorderControls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeFunctions.ReleaseCapture();
                NativeFunctions.SendMessage(Handle, NativeFunctions.WM_NCLBUTTONDOWN, NativeFunctions.HT_CAPTION, 0);
            }
        }

    }
}
