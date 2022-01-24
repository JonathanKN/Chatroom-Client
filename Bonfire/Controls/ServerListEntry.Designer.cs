
namespace Bonfire
{
    partial class ServerListEntry
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.ServernameLabel = new System.Windows.Forms.Label();
			this.contextMenuStripServerList = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.fjernServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kopierServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ContainerPanel = new System.Windows.Forms.Panel();
			this.DisconnectBtn = new System.Windows.Forms.Button();
			this.toolTipServerEntry = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenuStripServerList.SuspendLayout();
			this.ContainerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ServernameLabel
			// 
			this.ServernameLabel.BackColor = System.Drawing.Color.Transparent;
			this.ServernameLabel.ContextMenuStrip = this.contextMenuStripServerList;
			this.ServernameLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ServernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ServernameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ServernameLabel.ForeColor = System.Drawing.Color.LightGray;
			this.ServernameLabel.Location = new System.Drawing.Point(0, 0);
			this.ServernameLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ServernameLabel.Name = "ServernameLabel";
			this.ServernameLabel.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.ServernameLabel.Size = new System.Drawing.Size(150, 40);
			this.ServernameLabel.TabIndex = 0;
			this.ServernameLabel.Text = "label1";
			this.ServernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ServernameLabel.Click += new System.EventHandler(this.ServernameLabel_Click);
			this.ServernameLabel.MouseEnter += new System.EventHandler(this.ServernameLabel_MouseEnter);
			this.ServernameLabel.MouseLeave += new System.EventHandler(this.ServernameLabel_MouseLeave);
			// 
			// contextMenuStripServerList
			// 
			this.contextMenuStripServerList.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStripServerList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fjernServerToolStripMenuItem,
            this.kopierServerToolStripMenuItem});
			this.contextMenuStripServerList.Name = "contextMenuStripServerList";
			this.contextMenuStripServerList.Size = new System.Drawing.Size(143, 48);
			// 
			// fjernServerToolStripMenuItem
			// 
			this.fjernServerToolStripMenuItem.Name = "fjernServerToolStripMenuItem";
			this.fjernServerToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.fjernServerToolStripMenuItem.Text = "Fjern server";
			this.fjernServerToolStripMenuItem.Click += new System.EventHandler(this.fjernServerToolStripMenuItem_Click);
			// 
			// kopierServerToolStripMenuItem
			// 
			this.kopierServerToolStripMenuItem.Name = "kopierServerToolStripMenuItem";
			this.kopierServerToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.kopierServerToolStripMenuItem.Text = "Kopier server";
			this.kopierServerToolStripMenuItem.Click += new System.EventHandler(this.kopierServerToolStripMenuItem_Click);
			// 
			// ContainerPanel
			// 
			this.ContainerPanel.Controls.Add(this.DisconnectBtn);
			this.ContainerPanel.Controls.Add(this.ServernameLabel);
			this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
			this.ContainerPanel.Margin = new System.Windows.Forms.Padding(0);
			this.ContainerPanel.Name = "ContainerPanel";
			this.ContainerPanel.Size = new System.Drawing.Size(150, 40);
			this.ContainerPanel.TabIndex = 1;
			// 
			// DisconnectBtn
			// 
			this.DisconnectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DisconnectBtn.BackColor = System.Drawing.Color.Transparent;
			this.DisconnectBtn.BackgroundImage = global::Bonfire.Properties.Resources.Exit_icon1;
			this.DisconnectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.DisconnectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.DisconnectBtn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.DisconnectBtn.FlatAppearance.BorderSize = 0;
			this.DisconnectBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.DisconnectBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.DisconnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DisconnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.DisconnectBtn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.DisconnectBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DisconnectBtn.Location = new System.Drawing.Point(118, 4);
			this.DisconnectBtn.Name = "DisconnectBtn";
			this.DisconnectBtn.Size = new System.Drawing.Size(28, 32);
			this.DisconnectBtn.TabIndex = 3;
			this.DisconnectBtn.UseVisualStyleBackColor = false;
			this.DisconnectBtn.Visible = false;
			this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
			// 
			// ServerListEntry
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ContainerPanel);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "ServerListEntry";
			this.Size = new System.Drawing.Size(150, 40);
			this.Load += new System.EventHandler(this.ServerListEntry_Load);
			this.contextMenuStripServerList.ResumeLayout(false);
			this.ContainerPanel.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ContainerPanel;
        public System.Windows.Forms.Label ServernameLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripServerList;
        private System.Windows.Forms.ToolStripMenuItem fjernServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kopierServerToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipServerEntry;
        private System.Windows.Forms.Button DisconnectBtn;
    }
}
