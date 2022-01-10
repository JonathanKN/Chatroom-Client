using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bonfire
{
    public partial class ServerListEntry : UserControl
    {
        public event Action SwitchToServer;
        public event Action RemoveServer;
        public event Action CopyServer;

        public ServerListEntry(int width, string servername, FlowLayoutPanel parent)
        {
            InitializeComponent();
            this.Width = width;
            this.ServernameLabel.Text = servername;
            parent.ControlRemoved += SiblingControlRemovedOrAdded;
            parent.ControlAdded += SiblingControlRemovedOrAdded;
        }

        public void UpdateConnectedState(CheckState connectionState)
        {
            checkBoxConnected.CheckState = connectionState;
        }

        private void UpdateAppearenceByParent(FlowLayoutPanel parent)
        {
            // Recolour background depending on index.
            if (parent.Controls.IndexOf(this) % 2 == 0)
            {
                ContainerPanel.BackColor = Color.DarkGray;
            }
            else
            {
                ContainerPanel.BackColor = Color.FromArgb(255, 150, 150, 150);
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
            ContainerPanel.BackColor = Color.FromArgb(ContainerPanel.BackColor.R - 20, ContainerPanel.BackColor.R - 20, ContainerPanel.BackColor.R - 20);
        }

        private void ServernameLabel_MouseLeave(object sender, EventArgs e)
        {
            ContainerPanel.BackColor = Color.FromArgb(ContainerPanel.BackColor.R + 20, ContainerPanel.BackColor.R + 20, ContainerPanel.BackColor.R + 20);
        }

        private void ServerListEntry_Load(object sender, EventArgs e)
        {
        }

        private void checkBoxConnected_Click(object sender, EventArgs e)
        {
            ServernameLabel_Click(sender, e);
        }
    }
}
