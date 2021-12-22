using Chatroom_Client_Backend;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Chatrum
{
    public partial class FormMain : Form
    {
        private string name = "Person";
        private Server recentConnectedServer;
        private NetworkClient networkClient;
        private Dictionary<int, string> users = new Dictionary<int, string>();
        private byte selfID;
        private ServerListController serverListController;
        private MessageController messageController;

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
            serverListController = new ServerListController(ServerList);
            messageController = new MessageController(MessageContainer, OnlineList, splitContainer1, pictureBoxPendingMessageIcon, notifyIconMain);
            
            serverListController.AddServer(25565, "127.0.0.1", "Esperanto server");
            serverListController.AddServer(25565, "10.29.139.215", "Esperanto server2");
            backgroundWorkerMessagePull.RunWorkerAsync();
            ConnectToServer("Esperanto server");
        }

        private void ConnectToServer(string servername)
        {
            if (!serverListController.TryGetServer(servername, out Server targetServer))
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

            networkClient = new NetworkClient(name, targetServer.ip, targetServer.port);

            RegisterServerEvents(networkClient);

            recentConnectedServer = targetServer;

            ServerName.Text = servername;
            messageController.ClearMessages();
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
                    serverListController.AddServer(prompt.Port, prompt.IP, prompt.ServerNickname);
                    break;
                default:
                    // Anything other than yes
                    break;
            }
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

            //AddMessage(MessageBox.Text, name, DateTime.Now);
            networkClient.SendMessage(MessageBox.Text);
            MessageBox.Text = "";
            messageController.MessageSent();
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

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIconMain.Visible = true;
            }
        }

        private void ShowFormAfterMinimized()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIconMain.Visible = false;
        }

        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowFormAfterMinimized();
        }

        private void åbenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormAfterMinimized();
        }


        // NETWORK EVENT HANDLING BELOW


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
                }
                else if (!users.TryGetValue(userID, out sendername))
                {
                    sendername = "[Invalid name]";
                }

                messageController.ReceivedMessage(userID == selfID, sendername, message, timeStamp);
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
    }
}
