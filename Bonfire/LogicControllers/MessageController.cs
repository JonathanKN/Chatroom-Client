using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Bonfire.Controls;

namespace Bonfire.LogicControllers
{
    /// <summary>
    /// UI Controller for keeping track and displaying chatmessages, making balloon messages, flashing taskbar icon, and more.
    /// </summary>
    public class MessageController
    {
        private readonly FlowLayoutPanel messageContainer;
        private readonly PictureBox pendingMessageIcon;
        private readonly NotifyIcon messageNotifications;
        private readonly int onlineListWidth;
        private (string, RichTextLabel, DateTime) recentMessage;

        private sbyte _pendingMessages;

        private int unreadMessages;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageController"/> class.
        /// </summary>
        /// <param name="messageContainer"></param>
        /// <param name="pendingMessageIcon"></param>
        /// <param name="messageNotifications"></param>
        /// <param name="onlineListWidth"></param>
        public MessageController(FlowLayoutPanel messageContainer, PictureBox pendingMessageIcon, NotifyIcon messageNotifications, int onlineListWidth)
        {
            this.messageContainer = messageContainer;
            this.pendingMessageIcon = pendingMessageIcon;
            this.messageNotifications = messageNotifications;
            this.onlineListWidth = onlineListWidth;
        }

        private sbyte pendingMessages
        {
            get => _pendingMessages;
            set
            {
                _pendingMessages = value;
                pendingMessageIcon.Visible = _pendingMessages > 0;
            }
        }

        /// <summary>
        /// Called to keep track of which messages are read.
        /// Marks all unseen messages as read.
        /// </summary>
        public void MessageRead()
        {
            unreadMessages = 0;

            // Update message effect.
        }

        /// <summary>
        /// Keeps track of sent messages, and whether they have returned.
        /// </summary>
        public void MessageSent()
        {
            pendingMessages++;
        }

        /// <summary>
        /// Clears the messages.
        /// Primarily used when switching servers.
        /// </summary>
        public void ClearMessages()
        {
            messageContainer.Controls.Clear();
            pendingMessages = 0;
            unreadMessages = 0;
        }

        /// <summary>
        /// Event handler for when a message has been received.
        /// </summary>
        /// <param name="isSelf"></param>
        /// <param name="sendername"></param>
        /// <param name="message"></param>
        /// <param name="date"></param>
        /// <param name="logMessage"></param>
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
            if (!FormMain.MainForm.IsFormFocused)
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

        /// <summary>
        /// Adds ones own message as soon as clicked, instead of waiting for server reciept.
        /// </summary>
        /// <param name="message"></param>
        public void AddOwnMessage(string message)
        {
            AddMessage(message, Properties.Settings.Default.Nickname, DateTime.Now, false);
        }

        /// <summary>
        /// Adds a server log message with special formatting.
        /// </summary>
        /// <param name="message"></param>
        public void AddLogMessage(string message)
        {
            AddMessage(message, FormMain.ServerUsername, DateTime.Now, true);
        }

        private void ReceivedMessageEffects()
        {
            if (FormMain.MainForm.IsFormFocused)
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

            var messageLabel = new RichTextLabel(messageContainer)
            {
                Text = message,
                ForeColor = Color.LightGray,
                BackColor = Color.FromArgb(38, 43, 45),
                Font = new Font("Segoe UI", 13),
                Margin = new Padding(20, 0, 0, 10),
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
                ForeColor = isServer ? Color.LightGray : Color.DarkOrange,
                Font = new Font("Calibri", 13, FontStyle.Bold),
                AutoSize = true,
            };
            messageSender.Controls.Add(senderLabel);

            var dateLabel = new Label
            {
                Text = date.ToString(),
                ForeColor = Color.Gray,
                Font = new Font("Calibri", 13, FontStyle.Italic),
                AutoSize = true,
            };
            messageSender.Controls.Add(dateLabel);

            messageContainer.Controls.Add(messageSender);

            messageContainer.Controls.SetChildIndex(messageSender, 0);
            messageContainer.Controls.SetChildIndex(messageLabel, 0);
            messageContainer.ResumeLayout();

            messageContainer.AutoScrollPosition = new Point(1, int.MaxValue);
            messageContainer.Refresh();

            recentMessage = (sender, messageLabel, date);
        }
    }
}
