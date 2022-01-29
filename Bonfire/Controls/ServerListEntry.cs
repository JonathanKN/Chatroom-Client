using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bonfire
{
    /// <summary>
    /// Custom user control that displays a particular server entry and provides events for user interaction to be handled in <c>ServerListController</c>.
    /// </summary>
    public partial class ServerListEntry : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerListEntry"/> class.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="servername"></param>
        /// <param name="parent"></param>
        public ServerListEntry(int width, string servername, FlowLayoutPanel parent)
        {
            InitializeComponent();
            this.Width = width;
            this.ServernameLabel.Text = servername;
            this.Name = servername;
            parent.ControlRemoved += SiblingControlRemovedOrAdded;
            parent.ControlAdded += SiblingControlRemovedOrAdded;
        }

        public event Action SwitchToServer;

        public event Action RemoveServer;

        public event Action CopyServer;

        public event Action Disconnect;

        public void UpdateConnectedState(bool connectionState)
        {
            // checkBoxConnected.CheckState = connectionState;
            DisconnectBtn.Visible = connectionState;
        }

        private void UpdateAppearenceByParent(FlowLayoutPanel parent)
        {
            // Recolour background depending on index.
            if (parent.Controls.IndexOf(this) % 2 == 0)
            {
                ContainerPanel.BackColor = Color.FromArgb(43, 50, 53);
            }
            else
            {
                ContainerPanel.BackColor = Color.FromArgb(49, 57, 61);
            }
        }

        private void SiblingControlRemovedOrAdded(object sender, ControlEventArgs e)
        {
            UpdateAppearenceByParent((FlowLayoutPanel)sender);
        }

        private void ServernameLabel_Click(object sender, EventArgs e)
        {
            SwitchToServer?.Invoke();
        }

        private void fjernServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveServer?.Invoke();
        }

        private void kopierServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyServer?.Invoke();
        }

        private void ServernameLabel_MouseEnter(object sender, EventArgs e)
        {
            ContainerPanel.BackColor = Color.FromArgb(ContainerPanel.BackColor.R - 20, ContainerPanel.BackColor.G - 20, ContainerPanel.BackColor.B - 20);
        }

        private void ServernameLabel_MouseLeave(object sender, EventArgs e)
        {
            ContainerPanel.BackColor = Color.FromArgb(ContainerPanel.BackColor.R + 20, ContainerPanel.BackColor.G + 20, ContainerPanel.BackColor.B + 20);
        }

        private void ServerListEntry_Load(object sender, EventArgs e)
        {
        }

        private void checkBoxConnected_Click(object sender, EventArgs e)
        {
            ServernameLabel_Click(sender, e);
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            Disconnect?.Invoke();
        }
    }
}
