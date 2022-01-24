using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Bonfire.Controls;

namespace Bonfire.LogicControllers
{
    public class MessageController
    {
        private readonly FlowLayoutPanel messageContainer;
        private readonly PictureBox pendingMessageIcon;
        private readonly NotifyIcon messageNotifications;
        private readonly int onlineListWidth;
        private (string, RichTextLabel, DateTime) recentMessage;

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
        private int unreadMessages;

        public MessageController(FlowLayoutPanel messageContainer, PictureBox pendingMessageIcon, NotifyIcon messageNotifications, int onlineListWidth)
        {
            this.messageContainer = messageContainer;
            this.pendingMessageIcon = pendingMessageIcon;
            this.messageNotifications = messageNotifications;
            this.onlineListWidth = onlineListWidth;
        }

        public void MessageRead()
        {
            unreadMessages = 0;

            // Update message effect.
        }

        public void MessageSent()
        {
            pendingMessages++;
        }

        public void ClearMessages()
        {
            messageContainer.Controls.Clear();
            pendingMessages = 0;
            unreadMessages = 0;
        }

        private void ReceivedMessageEffects()
        {
            if (FormMain.MainForm.isFormFocused)
            {
                return;
            }

            unreadMessages++;
            if (Properties.Settings.Default.MessageSound)
            {
                SoundPlayer messageSound = new SoundPlayer(Properties.Resources.MessageSound);
                messageSound.Play();
            }

            // Flash application.
            NativeFunctions.FlashTaskbar.FlashWindowUntilFocus(FormMain.MainForm);
        }

        public void ReceivedMessage(bool isSelf, string sendername, string message, DateTime date, bool logMessage)
        {
            if (isSelf)
            {
                pendingMessages--;

                // Skriv ikke egen besked igen.
                return;
            }

            ReceivedMessageEffects();

            AddMessage(message, sendername, date, logMessage);
            if (!FormMain.MainForm.isFormFocused)
            {
                bool previousVisibility = messageNotifications.Visible;
                messageNotifications.Visible = true;

                messageNotifications.ShowBalloonTip(
                    FormMain.BalloonTimeout,
                    sendername,
                    message,
                    logMessage ? ToolTipIcon.Info : ToolTipIcon.None);
                messageNotifications.Visible = previousVisibility;
            }
        }

        public void AddOwnMessage(string message)
        {
            AddMessage(message, Properties.Settings.Default.Nickname, DateTime.Now, false);
        }

        public void AddLogMessage(string message)
        {
            AddMessage(message, FormMain.ServerUsername, DateTime.Now, true);
        }

        private void AddMessage(string message, string sender, DateTime date, bool isServer)
        {
            if (recentMessage.Item1 == sender
                && recentMessage.Item3 > date.Subtract(TimeSpan.FromMinutes(2)))
            {
                recentMessage.Item2.AppendText("\n" + message);
                messageContainer.AutoScrollPosition = new Point(1, int.MaxValue);
                messageContainer.Refresh();
                return;
            }

            messageContainer.SuspendLayout();

            /*
            var messageLabel = new Label
            {
                Text = message,
                ForeColor = Color.LightGray,
                Font = new Font("Century Gothic", 13),//new Font("Microsoft Sans Serif", 13),
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 10),
                Width = messageContainer.Width - onlineListWidth - 40
            };*/
            var messageLabel = new RichTextLabel(messageContainer)
            {
                Text = message,
                ForeColor = Color.LightGray,
                BackColor = Color.FromArgb(38, 43, 45),
                Font = new Font("Segoe UI", 13),
                Margin = new Padding(20, 0, 0, 10),
                //Dock = DockStyle.Fill,
                Width = messageContainer.Width - onlineListWidth - 40,
                MinimumSize = new Size(messageContainer.Width - 40, 0),
            };
            messageContainer.Controls.Add(messageLabel);

            var messageSender = new FlowLayoutPanel
            {
                AutoSize = true,
                Margin = new Padding(15, 0, 0, 0),
            };

            var senderLabel = new Label
            {
                Text = sender,
                ForeColor = isServer ? Color.LightGray : Color.DarkOrange,//Color.LightGray,
                Font = new Font("Calibri", 13, FontStyle.Bold),//new Font("Microsoft Sans Serif", 14, FontStyle.Bold),
                AutoSize = true,
            };
            messageSender.Controls.Add(senderLabel);

            var dateLabel = new Label
            {
                Text = date.ToString(),
                ForeColor = Color.Gray,
                Font = new Font("Calibri", 13, FontStyle.Italic),//new Font("Microsoft Sans Serif", 11),
                AutoSize = true,
            };
            messageSender.Controls.Add(dateLabel);

            messageContainer.Controls.Add(messageSender);

            messageContainer.Controls.SetChildIndex(messageSender, 0);
            //messageContainer.Controls.SetChildIndex(mainMessageLayout, 0);
            messageContainer.Controls.SetChildIndex(messageLabel, 0);
            messageContainer.ResumeLayout();

            messageContainer.AutoScrollPosition = new Point(1, int.MaxValue);
            messageContainer.Refresh();

            recentMessage = (sender, messageLabel, date);
        }
    }
}
