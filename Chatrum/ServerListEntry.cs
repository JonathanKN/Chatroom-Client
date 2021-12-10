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
        private Action<string> switchToServer;

        public ServerListEntry(int width, string servername, Action<string> switchToServer, FlowLayoutPanel parent)
        {
            InitializeComponent();
            this.Width = width;
            this.ServernameLabel.Text = servername;
            this.switchToServer = switchToServer;
            parent.ControlRemoved += SiblingControlRemovedOrAdded;
            parent.ControlAdded += SiblingControlRemovedOrAdded;
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
            switchToServer(ServernameLabel.Text);
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
