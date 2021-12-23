using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatrum
{
    public class MessageController
    {
        private readonly FlowLayoutPanel messageContainer;
        private readonly SplitContainer splitContainer1;
        private readonly FlowLayoutPanel onlineList;
        private readonly PictureBox pendingMessageIcon;
        private readonly NotifyIcon messageNotifications;

        private byte _pendingMessages;
        private byte pendingMessages
        {
            get => _pendingMessages;
            set
            {
                _pendingMessages = value;
                pendingMessageIcon.Visible = _pendingMessages > 0;
            }
        }

        public MessageController(FlowLayoutPanel messageContainer, FlowLayoutPanel onlineList, SplitContainer splitContainer1, PictureBox pendingMessageIcon, NotifyIcon messageNotifications)
        {
            this.onlineList = onlineList;
            this.messageContainer = messageContainer;
            this.splitContainer1 = splitContainer1;
            this.pendingMessageIcon = pendingMessageIcon;
            this.messageNotifications = messageNotifications;
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

        public void ReceivedMessage(bool isSelf, string sendername, string message, DateTime timestamp)
        {
            if (isSelf)
            {
                pendingMessages--;
            }

            AddMessage(message, sendername, timestamp);
            messageNotifications.BalloonTipTitle = sendername;
            messageNotifications.BalloonTipText = message;
            messageNotifications.ShowBalloonTip(500);

            AddMessage(message, sendername, timestamp);
        }

        private void AddMessage(string message, string sender, DateTime date)
        {
            messageContainer.SuspendLayout();

            Label messageLabel = new Label
            {
                Text = message,
                ForeColor = Color.LightGray,
                Font = new Font("Microsoft Sans Serif", 13),
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 10),
                Width = messageContainer.Width - onlineList.Width - 40
            };
            messageContainer.Controls.Add(messageLabel);

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

            messageContainer.Controls.Add(messageSender);

            messageContainer.Controls.SetChildIndex(messageSender, 0);
            messageContainer.Controls.SetChildIndex(messageLabel, 0);
            messageContainer.ResumeLayout();

            messageContainer.AutoScrollPosition = new Point(splitContainer1.Panel1.Width, int.MaxValue);
        }
    }
}
