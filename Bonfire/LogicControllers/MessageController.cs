using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Bonfire.LogicControllers
{
    public class MessageController
    {
        private readonly FlowLayoutPanel messageContainer;
        private readonly PictureBox pendingMessageIcon;
        private readonly NotifyIcon messageNotifications;
        private readonly Action playMessageSound;
        private readonly int onlineListWidth;

        private SoundPlayer messageSound;

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

        public MessageController(FlowLayoutPanel messageContainer, PictureBox pendingMessageIcon, NotifyIcon messageNotifications, int onlineListWidth, Action playMessageSound)
        {
            this.messageContainer = messageContainer;
            this.pendingMessageIcon = pendingMessageIcon;
            this.messageNotifications = messageNotifications;
            this.onlineListWidth = onlineListWidth;
            this.playMessageSound = playMessageSound;

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
            playMessageSound();

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

        public void AddLogMessage(string message)
        {
            AddMessage(message, "[Server]", DateTime.Now, true);
        }

        private void AddMessage(string message, string sender, DateTime date, bool isServer=false)
        {
            messageContainer.SuspendLayout();

            var messageLabel = new Label
            {
                Text = message,
                ForeColor = Color.LightGray,
                Font = new Font("Century Gothic", 13),//new Font("Microsoft Sans Serif", 13),
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 10),
                Width = messageContainer.Width - onlineListWidth - 40
            }; 
            messageContainer.Controls.Add(messageLabel);

            var messageSender = new FlowLayoutPanel
            {
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 0)
            };

            var senderLabel = new Label
            {
                ForeColor = Color.DarkOrange,//Color.LightGray,
                Text = sender,
                Font = new Font("Calibri", 14, FontStyle.Bold),//new Font("Microsoft Sans Serif", 14, FontStyle.Bold),
                AutoSize = true
            };
            messageSender.Controls.Add(senderLabel);

            var dateLabel = new Label
            {
                Text = date.ToString(),
                ForeColor = Color.Gray,
                Font = new Font("Calibri", 14, FontStyle.Italic),//new Font("Microsoft Sans Serif", 11),
                AutoSize = true
            };
            messageSender.Controls.Add(dateLabel);

            messageContainer.Controls.Add(messageSender);

            messageContainer.Controls.SetChildIndex(messageSender, 0);
            messageContainer.Controls.SetChildIndex(messageLabel, 0);
            messageContainer.ResumeLayout();

            messageContainer.AutoScrollPosition = new Point(1, int.MaxValue);
            messageContainer.Refresh();
        }
    }
}
