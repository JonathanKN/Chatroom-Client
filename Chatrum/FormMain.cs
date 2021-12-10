using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Chatroom_Client_Backend;

namespace Chatrum
{
    public partial class FormMain : Form
    {
        public Dictionary<string, Server> Servers = new Dictionary<string, Server>();

        private string name = "Person";
        private Server recentConnectedServer;
        private Chatroom_Client_Backend.NetworkClient networkClient;
        private Dictionary<int, string> users = new Dictionary<int, string>();
        private byte selfID;

        private byte _pendingMessages;
        private byte pendingMessages {
            get => _pendingMessages;
            set
            {
                _pendingMessages = value;
                pictureBoxPendingMessageIcon.Visible = _pendingMessages > 0;
            }
        }

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
            AddServer(25565, "127.0.0.1", "Esperanto server");
            AddServer(25565, "10.29.139.215", "Esperanto server2");
            backgroundWorkerMessagePull.RunWorkerAsync();
            ConnectToServer("Esperanto server");
        }

        private void ConnectToServer(string servername)
        {
            if (!Servers.TryGetValue(servername, out Server targetServer))
            {
                Console.WriteLine($"'{servername}' doesn't exist");
                return;
            }

            if (recentConnectedServer == targetServer)
            {
                Console.WriteLine("Already connected to server");
                return;
            }

            if (!(networkClient is null))
            {
                UnregisterServerEvents(networkClient);
                networkClient.Disconnect();
            }

            pendingMessages = 0;

            networkClient = new Chatroom_Client_Backend.NetworkClient(
                name, 
                targetServer.ip,
                targetServer.port);
            RegisterServerEvents(networkClient);

            recentConnectedServer = targetServer;

            ServerName.Text = servername;
            MessageContainer.Controls.Clear();
        }

        private void RegisterServerEvents(NetworkClient networkClient)
        {
            networkClient.onMessage += OnMessage;
            networkClient.onUserIDReceived += OnUserIDRecieved;
            networkClient.onUserInfoReceived += OnUserInfoRecieved;
            networkClient.onUserLeft += OnUserLeft;
            networkClient.onLogMessage += OnLogMessage;
        }

        private void UnregisterServerEvents(NetworkClient networkClient)
        {
            networkClient.onMessage -= OnMessage;
            networkClient.onUserIDReceived -= OnUserIDRecieved;
            networkClient.onUserInfoReceived -= OnUserInfoRecieved;
            networkClient.onUserLeft -= OnUserLeft;
            networkClient.onLogMessage -= OnLogMessage;
        }

        private void OnLogMessage((string message, DateTime timeStamp) e)
        {
            (string message, DateTime timeStamp) = e;
            this.Invoke((MethodInvoker)delegate
            {
                OnMessage((0, message, timeStamp));
            });

        }

        public void OnMessage((int userID, string message, DateTime timeStamp) e)
        {
            (int userID, string message, DateTime timeStamp) = e;
            this.Invoke((MethodInvoker)delegate
            {
                string sendername;
                if (userID == 0)
                {
                    sendername = "[Server]";
                }
                else if (userID == selfID)
                {
                    sendername = name;
                    pendingMessages--;
                }
                else if (!users.TryGetValue(userID, out sendername))
                {
                    sendername = "[Invalid name]";
                }

                AddMessage(message, sendername, timeStamp);
            });
        }

        public void OnUserIDRecieved(int userID)
        {
            selfID = (byte)userID;
        }

        public void OnUserInfoRecieved((int userID, string userName) e)
        {
            (int userID, string userName) = e;
            this.Invoke((MethodInvoker)delegate
            {
                // TODO: Dette kommer til at skabe en fejl, når brugerens information
                // bliver opdateret mere end én gang.
                users[userID] = userName;
                AddOnlinePerson(userName);
            });
        }

        public void OnUserLeft(int userID)
        {
            this.Invoke((MethodInvoker)delegate
            {
                RemoveOnlinePerson(users[userID]);
                users.Remove(userID);
            });
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsWindow settings = new SettingsWindow(name);
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
                        Console.WriteLine("Imparsable port");
                        return;
                    }

                    if (!IPAddress.TryParse(prompt.ServerIPInput.Text, out _))
                    {
                        // Invalid IP address.
                        Console.WriteLine("Invalid IP address");
                        return;
                    }

                    AddServer(serverPort, prompt.ServerIPInput.Text, prompt.ServerNicknameInput.Text);
                    break;
                default:
                    // Anything other than yes
                    break;
            }
        }

        public void AddServer(int port, string ip, string servername)
        {
            ServerListEntry listEntry = new ServerListEntry(
                ServerList.Width - 17,
                servername,
                ServerListEntry_Clicked,
                ServerList);

            ServerList.Controls.Add(listEntry);

            Server s = new Server
            {
                port = port,
                ip = ip
            };
            Servers.Add(servername, s);
        }

        private void ServerListEntry_Clicked(string servername)
        {
            ConnectToServer(servername);
        }

        public void AddMessage(string message, string sender, DateTime date)
        {
            MessageContainer.SuspendLayout();

            Label messageLabel = new Label
            {
                Text = message,
                ForeColor = Color.LightGray,
                Font = new Font("Microsoft Sans Serif", 13),
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 10),
                Width = MessageContainer.Width - OnlineList.Width - 40
            };
            MessageContainer.Controls.Add(messageLabel);

            FlowLayoutPanel messageSender = new FlowLayoutPanel
            {
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 0)
            };

            Label senderLabel = new Label
            {
                ForeColor = Color.LightGray,
                Text = sender,
                Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold),
                AutoSize = true
            };
            messageSender.Controls.Add(senderLabel);

            Label dateLabel = new Label
            {
                Text = date.ToString(),
                ForeColor = Color.Gray,
                Font = new Font("Microsoft Sans Serif", 11),
                AutoSize = true
            };
            messageSender.Controls.Add(dateLabel);

            MessageContainer.Controls.Add(messageSender);

            MessageContainer.Controls.SetChildIndex(messageSender, 0);
            MessageContainer.Controls.SetChildIndex(messageLabel, 0);
            MessageContainer.ResumeLayout();

            MessageContainer.AutoScrollPosition = new Point(splitContainer1.Panel1.Width, int.MaxValue);
        }

        public void AddOnlinePerson(string name)
        {
            Label person = new Label
            {
                Text = name,
                Name = $"NameLabel{name}",
                ForeColor = Color.LightGray,
                Font = new Font("Microsoft Sans Serif", 13),
                Margin = new Padding(0, 0, 0, 2),
                AutoSize = true
            };
            OnlineList.Controls.Add(person);
        }

        public void RemoveOnlinePerson(string name)
        {
            OnlineList.Controls.Remove(OnlineList.Controls.Find($"NameLabel{name}", false)[0]);
        }

        private void MessageBox_KeyDown(object sender, KeyEventArgs key)
        {
            if (key.KeyCode != Keys.Enter || MessageBox.TextLength == 0 || networkClient is null)
            {
                return;
            }

            key.Handled = true;
            //AddMessage(MessageBox.Text, name, DateTime.Now);
            networkClient.SendMessage(MessageBox.Text);
            MessageBox.Text = "";
            pendingMessages++;
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
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            NativeFunctions.ReleaseCapture();
            NativeFunctions.SendMessage(Handle, NativeFunctions.WM_NCLBUTTONDOWN, NativeFunctions.HT_CAPTION, 0);
        }

        private void backgroundWorkerMessagePull_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (true)
            {
                while (sw.ElapsedMilliseconds < 1000 / 10)
                    Thread.Sleep(0);
                
                sw.Restart();

                if (networkClient is null)
                {
                    continue;
                }

                networkClient.Update();
            }
        }

        private void panelTopBorderControls_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            checkBoxResizeFull.Checked = !checkBoxResizeFull.Checked;
        }
    }
}
