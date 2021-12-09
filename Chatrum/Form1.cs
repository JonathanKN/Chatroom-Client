using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Chatrum
{
    public partial class Form1 : Form
    {
        public Dictionary<string, Server> servers = new Dictionary<string, Server>();

        private string name = "Johnny";
        private Chatroom_Client_Backend.NetworkClient networkClient;
        private Dictionary<int, string> users = new Dictionary<int, string>();

        public Form1()
        {
            InitializeComponent();
            AddServer(25565, "10.29.139.215", "Esperanto server");
            networkClient = new Chatroom_Client_Backend.NetworkClient(name, servers["Esperanto server"].ip, servers["Esperanto server"].port);
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

        private void ServerMenuBtn_Click(object sender, EventArgs e)
        {
            AddServerMenu.BringToFront();
        }

        private void AddServerBtn_Click(object sender, EventArgs e)
        {
            AddServerMenu.SendToBack();
            //Connect to new server
            //If it works, addserver(new server)
            if (ServerPortInput.Text != null && ServerIPInput.Text != null)
            {
                AddServer(int.Parse(ServerPortInput.Text), ServerIPInput.Text);
            }
            
            ServerPortInput.Text = "";
            ServerIPInput.Text = "";
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

            networkClient.Disconnect();
            networkClient = new Chatroom_Client_Backend.NetworkClient(name, servers[serverText.Text].ip, servers[serverText.Text].port);
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
                networkClient.SendMessage(MessageBox.Text);
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



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MessageBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddServerMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
