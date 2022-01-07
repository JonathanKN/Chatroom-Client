using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Chatroom_Client_Backend;
using Bonfire.LogicControllers;
using System.Media;

namespace Bonfire
{
    public partial class FormMain : Form
    {
        public const int BalloonTimeout = 500;

        private readonly string DefaultFormTitle = "Bonfire";
        private readonly ComponentResourceManager resources;
        private readonly Dictionary<int, string> users = new Dictionary<int, string>();
        private ServerEntryInfo connectedServer;
        private string connectedServername;
        private NetworkClient networkClient;

        // UI Logic controllers
        private ServerListController serverListController;
        private MessageController messageController;
        private UserListController userListController;

        public FormMain()
        {
            // Denne "metode" må sådan set ikke bruges til andet end initialisering.
            // Derfor bruger man OnLoad i stedet.
            Thread.CurrentThread.CurrentUICulture = Properties.Settings.Default.Language;
            InitializeComponent();

            // Resize logic
            SetStyle(ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;

            // Language logic
            resources = new ComponentResourceManager(typeof(FormMain));
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            NativeFunctions.ResizableWindow.WndProc(this, ref m);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            NativeFunctions.ResizableWindow.OnPaint(this, e);
        }

        /// <summary>
        /// Initialiserer Controller-klasser, som står for at styre UI.
        /// Starter tråden som lytter efter beskeder, når den er forbundet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            serverListController = new ServerListController(
                true,
                ServerList,
                (info, name) => ConnectToServer(info, name),
                toolTipServerEntry
                );

            messageController = new MessageController(
                MessageContainer,
                pictureBoxPendingMessageIcon,
                notifyIconMain,
                OnlineList.Width,
                ()=> {
                    SoundPlayer messageSound = new SoundPlayer(Properties.Resources.MessageSound);
                    if (WindowState == FormWindowState.Minimized && Properties.Settings.Default.MessageSound)
                    {
                        messageSound.Play();
                    }
                });

            userListController = new UserListController(OnlineList);

            backgroundWorkerMessagePull.RunWorkerAsync();

            // Form title
            Text = DefaultFormTitle;
            labelCustomTitle.Text = DefaultFormTitle;
            
        }

        private void DisconnectServer()
        {
            serverListController.UpdateStatusDisconnectAll();

            DisconnectBtn.Visible = false;
            ServerName.Text = "[Ikke forbundet]";
            connectedServer = null;
            connectedServername = null;
            UnregisterServerEvents(networkClient);
            networkClient?.Disconnect();
            networkClient = null;
        }

        /// <summary>
        /// Forbind til server ved hjælp af navnet på den i serverlisten.
        /// </summary>
        /// <param name="servername">Navnet på serveren.</param>
        private void ConnectToServer(string servername)
        {
            if (!serverListController.TryGetServer(servername, out ServerEntryInfo targetServer))
            {
                Console.WriteLine($"'{servername}' doesn't exist");
                return;
            }

            ConnectToServer(targetServer, servername);
        }

        /// <summary>
        /// Forbind til server ved hjælp af liste-element informationen.
        /// Dvs. IP og port.
        /// </summary>
        /// <param name="targetServer"></param>
        /// <param name="servername"></param>
        private void ConnectToServer(ServerEntryInfo targetServer, string servername)
        {
            // Annuller forbindelses forsøget hvis den allerede er forbundet til serveren.
            if (connectedServer == targetServer)
            {
                Console.WriteLine("Already connected to server");
                return;
            }

            // Frakobl nuværende server, hvis den er forbundet
            if (!(networkClient is null))
            {
                DisconnectServer();
            }

            users.Clear();
            userListController.Clear();
            messageController.ClearMessages();

            networkClient = new NetworkClient(
                Properties.Settings.Default.Nickname,
                targetServer.ip,
                targetServer.port);

            // Lyt efter de event listeners der er opstillet i Patricks API
            networkClient.onConnect += (connected) => FinishedConnectingToServer(targetServer, servername, connected);
            RegisterServerEvents(networkClient);

            ConnectingToServer(targetServer, servername);
            networkClient.Connect();
            DisconnectBtn.Visible = true;
        }

        private void ConnectingToServer(ServerEntryInfo targetServer, string servername)
        {
            Text = $"{DefaultFormTitle} — {servername}";
            ServerName.Text = $"Forbinder til {servername}...";
            serverListController.UpdateServerConnectedStatus(targetServer, CheckState.Indeterminate);
        }

        /// <summary>
        /// Denne kaldes når der er etableret forbindelse til en chatserver.
        /// </summary>
        /// <param name="targetServer"></param>
        /// <param name="servername"></param>
        private void FinishedConnectingToServer(ServerEntryInfo targetServer, string servername, bool success)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // If minified, show balloon message.
                if (WindowState == FormWindowState.Minimized)
                {
                    notifyIconMain.BalloonTipText = success ? $"Forbandt til {servername}" : $"Kunne ikke forbinde til {servername}";
                    notifyIconMain.ShowBalloonTip(BalloonTimeout);
                }

                if (!success)
                {
                    Text = DefaultFormTitle;
                    ServerName.Text = "Forbindelse mislykkedes";
                    serverListController.UpdateServerConnectedStatus(targetServer, CheckState.Unchecked);
                    return;
                }

                serverListController.UpdateServerConnectedStatus(targetServer, CheckState.Checked);
                connectedServer = targetServer;
                connectedServername = servername;

                ServerName.Text = servername;
                messageController.ClearMessages();
                userListController.Clear();
                users.Clear();
            });
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            string previousName = Properties.Settings.Default.Nickname;
            SettingsWindow settings = new SettingsWindow();
            
            switch (settings.ShowDialog())
            {
                case DialogResult.Yes:
                    // Kig efter ændringer i brugernavn
                    string newName = Properties.Settings.Default.Nickname;
                    if (newName != previousName)
                    {
                        networkClient?.ChangeName(newName);
                    }
                    break;
                default:
                    // Anything other than yes
                    break;
            }
        }

        private void ServerMenuBtn_Click(object sender, EventArgs e)
        {
            AddServerPrompt prompt = new AddServerPrompt(serverListController.GetServerNames());
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


        private void MessageBox_KeyDown(object sender, KeyEventArgs key)
        {
            if (key.KeyCode != Keys.Enter)
            {
                return;
            }
            key.Handled = true;
            key.SuppressKeyPress = true;
            SendMessage();
        }

        private void SendMessage()
        {
            if (MessageBox.TextLength == 0 || networkClient is null)
            {
                return;
            }

            if (connectedServer is null)
            {
                messageController.AddLogMessage("Du er ikke forbundet til serveren");
                return;
            }


            string messageText = MessageBox.Text;
            MessageBox.Text = string.Empty;

            messageController.AddOwnMessage(messageText);
            networkClient.SendMessage(messageText);
            messageController.MessageSent();
        }

        private void MessageBox_Enter(object sender, EventArgs e)
        {
            // If text is default, empty box.
            if (MessageBox.Text == resources.GetString($"{nameof(MessageBox)}.Text"))
            {
                MessageBox.Text = string.Empty;
            }
        }

        private void MessageBox_Leave(object sender, EventArgs e)
        {
            // If box is empty, fill box with default text for corresponding language.
            if (MessageBox.Text == string.Empty)
            {
                MessageBox.Text = resources.GetString($"{nameof(MessageBox)}.Text");
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
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                while (true)
                {
                    while (sw.ElapsedMilliseconds < 1000 / 10)
                    {
                        Thread.Sleep(0);
                    }

                    sw.Restart();

                    this.Invoke((MethodInvoker)delegate
                    {
                        networkClient?.Update();
                    });
                }
            }
            catch (Exception)
            {
                throw;
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

        private void contextMenuStripNotifyIcon_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*
            toolStripComboBoxSelectedServer.Items.Clear();
            toolStripComboBoxSelectedServer.Items.Add("(ikke forbundet)");
            toolStripComboBoxSelectedServer.Items.AddRange(serverListController.GetServerNames());*/
        }

        private void toolStripComboBoxSelectedServer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemConnectedServer_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemConnectedServer_DropDownOpening(object sender, EventArgs e)
        {
            toolStripMenuItemConnectedServer.DropDownItems.Clear();
            var emptyServerItem = (ToolStripMenuItem)toolStripMenuItemConnectedServer.DropDownItems.Add("(ikke forbundet)");
            emptyServerItem.Click += toolStripMenuItemDisconnect_Click;

            if (connectedServer is null)
            {
                emptyServerItem.Checked = true;
            }

            foreach (string servername in serverListController.GetServerNames())
            {
                var newServerItem = (ToolStripMenuItem)toolStripMenuItemConnectedServer.DropDownItems.Add(servername);
                newServerItem.Checked = servername == connectedServername;

                newServerItem.Click += toolStripMenuItemServerEntry_Click;
            }
        }

        private void toolStripMenuItemDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectServer();
        }

        private void toolStripMenuItemServerEntry_Click(object sender, EventArgs e)
        {
            var toolstripMenuItem = (ToolStripMenuItem)sender;
            ConnectToServer(toolstripMenuItem.Text);
        }

        private void FormMain_TextChanged(object sender, EventArgs e)
        {
            // Update custom title.
            labelCustomTitle.Text = this.Text;
            notifyIconMain.BalloonTipTitle = this.Text;
            notifyIconMain.Text = this.Text;
        }

        private void labelCustomTitle_MouseDown(object sender, MouseEventArgs e)
        {
            // Bubble up event to parent.
            panelTopBorderControls_MouseDown(sender, e);
        }

        private void lukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisconnectServer();
            Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectServer();
        }

        private void FormMain_Enter(object sender, EventArgs e)
        {
            // Refresh connection with server.
            networkClient?.PingServer();
        }

        // NETWORK EVENT HANDLING BELOW

        private void RegisterServerEvents(NetworkClient networkClient)
        {
            if (networkClient is null)
            {
                return;
            }

            networkClient.onMessage += OnMessage;
            networkClient.onUserInfoReceived += OnUserInfoRecieved;
            networkClient.onUserLeft += OnUserLeft;
            networkClient.onLogMessage += OnLogMessage;
            networkClient.onDisconnect += OnDisconnect;
        }

        private void UnregisterServerEvents(NetworkClient networkClient)
        {
            if (networkClient is null)
            {
                return;
            }

            networkClient.onMessage -= OnMessage;
            networkClient.onUserInfoReceived -= OnUserInfoRecieved;
            networkClient.onUserLeft -= OnUserLeft;
            networkClient.onLogMessage -= OnLogMessage;
            networkClient.onDisconnect -= OnDisconnect;
        }

        private void OnDisconnect()
        {
            if (connectedServer is null)
            {
                networkClient = null;
                return;
            }

            DisconnectServer();
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
                else if (userID == networkClient.ClientID)
                {
                    sendername = Properties.Settings.Default.Nickname;
                }
                else if (!users.TryGetValue(userID, out sendername))
                {
                    sendername = "[Navn ikke fundet]";
                }

                messageController.ReceivedMessage(userID == networkClient.ClientID, sendername, message, timeStamp);
            });
        }

        public void OnUserInfoRecieved((int userID, string userName) e)
        {
            (int userID, string userName) = e;
            this.Invoke((MethodInvoker)delegate
            {
                if (users.TryGetValue(userID, out string oldName))
                {
                    userListController.RemovePerson(oldName);
                }

                users[userID] = userName;
                userListController.AddPerson(userName);
            });
        }

        public void OnUserLeft(int userID)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (!users.TryGetValue(userID, out string username))
                {
                    return;
                }

                userListController.RemovePerson(username);
                users.Remove(userID);
            });
        }

        private void SendMessageBtn_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            userListController.Clear();
            users.Clear();
            messageController.ClearMessages();
            DisconnectServer();
        }

        private void MessageBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
