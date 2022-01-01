using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Chatroom_Client_Backend;
using Chatrum.LogicControllers;

namespace Chatrum
{
    public partial class FormMain : Form
    {
        public const int BalloonTimeout = 500;

        private readonly System.ComponentModel.ComponentResourceManager resources;
        private readonly Dictionary<int, string> users = new Dictionary<int, string>();
        private ServerEntryInfo connectedServer;
        private string connectedServername;
        private NetworkClient networkClient;
        private byte selfID;

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
            resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            NativeFunctions.ResizableWindow.WndProc(this, ref m);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            NativeFunctions.ResizableWindow.OnPaint(this, e);

            //base.OnPaint(e);
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
                ServerList,
                (info, name) => ConnectToServer(info, name),
                toolTipServerEntry
                );

            messageController = new MessageController(
                MessageContainer,
                pictureBoxPendingMessageIcon,
                notifyIconMain,
                splitContainer1,
                OnlineList);

            userListController = new UserListController(OnlineList);

            backgroundWorkerMessagePull.RunWorkerAsync();
            
            // Form title
            Text = "Chatrum";
            labelCustomTitle.Text = "Chatrum";
            
            TestIndstillingerStart();
        }

        /// <summary>
        /// Kaldes når Windows Forms er færdig med at loade.
        /// TODO: Fjern i det endelige program.
        /// </summary>
        private void TestIndstillingerStart()
        {
            serverListController.AddServer(25565, "127.0.0.1", "Esperanto server");
            serverListController.AddServer(25565, "10.29.139.215", "Esperanto server2");
            ConnectToServer("Esperanto server");
        }

        private void DisconnectServer()
        {
            UnregisterServerEvents(networkClient);
            networkClient.Disconnect();
            networkClient = null;
            connectedServer = null;
            connectedServername = null;
        }

        /// <summary>
        /// Forbind til server ved hjælp af navnet på den i serverlisten.
        /// </summary>
        /// <param name="servername">Navnet på serveren.</param>
        private void ConnectToServer(string servername)
        {
            Text = $"Chatrum — {servername}";
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
            // Annuller forbindelses forsøget hvis den allerede er forbundet til serveren
            // TODO: Man kan ikke forbinde hvis man blev disconnected.
            // TODO: Implementér custom sammenligning, da den sammenligner referencen, ikke IP og port.
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

            networkClient = new NetworkClient(
                Properties.Settings.Default.Nickname,
                targetServer.ip,
                targetServer.port);

            // Lyt efter de event listeners der er opstillet i Patricks API
            RegisterServerEvents(networkClient);

            // TODO: Kald først denne når serveren er forbundet, kan først gøres
            // når Patrick har implementeret den manglende 'OnConnected' API.
            // Der findes også en FinishedConnectingToServerTimeout(...), til hvis det sker.
            FinishedConnectingToServerSuccess(targetServer, servername);
        }

        /// <summary>
        /// Denne kaldes når der er etableret forbindelse til en chatserver.
        /// </summary>
        /// <param name="targetServer"></param>
        /// <param name="servername"></param>
        private void FinishedConnectingToServerSuccess(ServerEntryInfo targetServer, string servername)
        {
            connectedServer = targetServer;
            connectedServername = servername;

            ServerName.Text = servername;
            messageController.ClearMessages();

            // If minified, show balloon message.
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIconMain.BalloonTipText = $"Forbandt til {servername}";
                notifyIconMain.ShowBalloonTip(BalloonTimeout);
            }
        }

        private void FinishedConnectingToServerTimeout(ServerEntryInfo targetServer, string servername)
        {
            // If minified, show balloon message.
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIconMain.BalloonTipText = $"Kunne ikke forbinde til {servername}";
                notifyIconMain.ShowBalloonTip(BalloonTimeout);
            }
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
                        networkClient.ChangeName(newName);
                    }
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

        private void MessageBox_KeyDown(object sender, KeyEventArgs key)
        {
            if (key.KeyCode != Keys.Enter || MessageBox.TextLength == 0 || networkClient is null)
            {
                return;
            }

            // TODO: man kan sende beskeder selvom man ikke er forbundet.
            // tænker man kunne lave så den sender en besked som altid siger "Du er ikke forbundet"
            // eller noget i den stil.
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
                        Thread.Sleep(0);

                    sw.Restart();

                    if (networkClient is null)
                    {
                        connectedServer = null;
                        connectedServername = null;
                        continue;
                    }

                    networkClient.Update();
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
                    sendername = Properties.Settings.Default.Nickname;
                }
                else if (!users.TryGetValue(userID, out sendername))
                {
                    sendername = "[Navn ikke fundet]";
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
                if (users.TryGetValue(userID, out string oldName))
                {
                    userListController.RemovePerson(users[userID]);
                }

                users[userID] = userName;
                userListController.AddPerson(userName);
            });
        }

        public void OnUserLeft(int userID)
        {
            this.Invoke((MethodInvoker)delegate
            {
                userListController.RemovePerson(users[userID]);
                users.Remove(userID);
            });
        }
    }
}
