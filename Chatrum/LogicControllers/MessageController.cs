using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chatrum.LogicControllers
{
    public class MessageController
    {
        private readonly FlowLayoutPanel messageContainer;
        private readonly PictureBox pendingMessageIcon;
        private readonly NotifyIcon messageNotifications;
        private readonly SplitContainer splitContainer1Layout;
        private readonly Control onlineListLayout;

        private sbyte _pendingMessages;
        private sbyte pendingMessages
        {
            get => _pendingMessages;
            set
            {
                _pendingMessages = value;
                pendingMessageIcon.Visible = _pendingMessages > 0;
            }
        }

        public MessageController(FlowLayoutPanel messageContainer, PictureBox pendingMessageIcon, NotifyIcon messageNotifications, SplitContainer splitContainer1Layout, Control onlineListLayout)
        {
            // TODO: Forstå hvorfor man skal bruge onlineListLayout og splitcontainer1
            // de burde ikke være vigtige. 
            this.messageContainer = messageContainer;
            this.pendingMessageIcon = pendingMessageIcon;
            this.messageNotifications = messageNotifications;
            this.splitContainer1Layout = splitContainer1Layout;
            this.onlineListLayout = onlineListLayout;
        }

        public void MessageSent()
        {
            pendingMessages++;
        }

        public void ClearMessages()
        {
            messageContainer.Controls.Clear();
            pendingMessages = 0;
        }

        public void ReceivedMessage(bool isSelf, string sendername, string message, DateTime date)
        {
            if (isSelf)
            {
                pendingMessages--;

                // Skriv ikke egen besked igen.
                return;
            }

            AddMessage(message, sendername, date);
            string previousTitle = messageNotifications.BalloonTipTitle;
            messageNotifications.BalloonTipTitle = sendername;
            messageNotifications.BalloonTipText = message;
            messageNotifications.ShowBalloonTip(FormMain.BalloonTimeout);
            messageNotifications.BalloonTipTitle = previousTitle;
        }

        public void AddOwnMessage(string message)
        {
            AddMessage(message, Properties.Settings.Default.Nickname, DateTime.Now);
        }

        private void AddMessage(string message, string sender, DateTime date)
        {
            messageContainer.SuspendLayout();

            var messageLabel = new Label
            {
                Text = message,
                ForeColor = Color.LightGray,
                Font = new Font("Microsoft Sans Serif", 13),
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 10),
                Width = messageContainer.Width - onlineListLayout.Width - 40 // TODO: bør ikke være afhængig af onlinelist.
            };
            messageContainer.Controls.Add(messageLabel);

            var messageSender = new FlowLayoutPanel
            {
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 0)
            };

            var senderLabel = new Label
            {
                ForeColor = Color.LightGray,
                Text = sender,
                Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold),
                AutoSize = true
            };
            messageSender.Controls.Add(senderLabel);

            var dateLabel = new Label
            {
                Text = date.ToString(),
                ForeColor = Color.Gray,
                Font = new Font("Microsoft Sans Serif", 11),
                AutoSize = true
            };
            messageSender.Controls.Add(dateLabel);

            messageContainer.Controls.Add(messageSender);

            messageContainer.Controls.SetChildIndex(messageSender, 0);
            messageContainer.Controls.SetChildIndex(messageLabel, 0);
            messageContainer.ResumeLayout();

            messageContainer.AutoScrollPosition = new Point(splitContainer1Layout.Panel1.Width, int.MaxValue);
            messageContainer.Refresh();
        }
    }
}
