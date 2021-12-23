using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatrum
{
    public partial class ServerListEntry : UserControl
    {
        public event Action SwitchToServer;
        public event Action RemoveServer;

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
                ContainerPanel.BackColor = Color.Gray;
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

        private void ServernameLabel_MouseEnter(object sender, EventArgs e)
        {
            ContainerPanel.BackColor = Color.FromArgb(ContainerPanel.BackColor.R - 20, ContainerPanel.BackColor.R - 20, ContainerPanel.BackColor.R - 20);
        }

        private void ServernameLabel_MouseLeave(object sender, EventArgs e)
        {
            ContainerPanel.BackColor = Color.FromArgb(ContainerPanel.BackColor.R + 20, ContainerPanel.BackColor.R + 20, ContainerPanel.BackColor.R + 20);
        }
    }
}
