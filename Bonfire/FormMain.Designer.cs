
namespace Bonfire
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ServerMenuBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BonfireLogo = new System.Windows.Forms.Panel();
            this.ServerList = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.MessageContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.OnlineList = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSendMessageButton = new System.Windows.Forms.Button();
            this.pictureBoxPendingMessageIcon = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.ServerNameHeader = new System.Windows.Forms.Panel();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.ServerName = new System.Windows.Forms.Label();
            this.panelTopBorderControls = new System.Windows.Forms.Panel();
            this.labelCustomTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanelWindowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxMinimize = new System.Windows.Forms.CheckBox();
            this.checkBoxResizeFull = new System.Windows.Forms.CheckBox();
            this.checkBoxClose = new System.Windows.Forms.CheckBox();
            this.backgroundWorkerMessagePull = new System.ComponentModel.BackgroundWorker();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.åbenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemConnectedServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lukToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipServerEntry = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPendingMessageIcon)).BeginInit();
            this.panel4.SuspendLayout();
            this.ServerNameHeader.SuspendLayout();
            this.panelTopBorderControls.SuspendLayout();
            this.flowLayoutPanelWindowButtons.SuspendLayout();
            this.contextMenuStripNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(113)))), ((int)(((byte)(110)))));
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MessageContainer);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.ServerNameHeader);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel5);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.BonfireLogo);
            this.splitContainer2.Panel1.Controls.Add(this.ServerList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonSettings);
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel5.Controls.Add(this.ServerMenuBtn);
            this.panel5.Name = "panel5";
            // 
            // ServerMenuBtn
            // 
            this.ServerMenuBtn.BackColor = System.Drawing.Color.Transparent;
            this.ServerMenuBtn.BackgroundImage = global::Bonfire.Properties.Resources.TilføjServerKnap;
            resources.ApplyResources(this.ServerMenuBtn, "ServerMenuBtn");
            this.ServerMenuBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ServerMenuBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.GrayText;
            this.ServerMenuBtn.FlatAppearance.BorderSize = 0;
            this.ServerMenuBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ServerMenuBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ServerMenuBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ServerMenuBtn.Name = "ServerMenuBtn";
            this.ServerMenuBtn.UseVisualStyleBackColor = false;
            this.ServerMenuBtn.Click += new System.EventHandler(this.ServerMenuBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Bonfire.Properties.Resources.Bonfire_text;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // BonfireLogo
            // 
            this.BonfireLogo.BackgroundImage = global::Bonfire.Properties.Resources.New_Bonfire;
            resources.ApplyResources(this.BonfireLogo, "BonfireLogo");
            this.BonfireLogo.Name = "BonfireLogo";
            // 
            // ServerList
            // 
            resources.ApplyResources(this.ServerList, "ServerList");
            this.ServerList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ServerList.Name = "ServerList";
            this.ServerList.TabStop = true;
            // 
            // buttonSettings
            // 
            resources.ApplyResources(this.buttonSettings, "buttonSettings");
            this.buttonSettings.BackColor = System.Drawing.Color.DarkGray;
            this.buttonSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSettings.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // MessageContainer
            // 
            resources.ApplyResources(this.MessageContainer, "MessageContainer");
            this.MessageContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.MessageContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.MessageContainer.Name = "MessageContainer";
            this.MessageContainer.MouseEnter += new System.EventHandler(this.MessageContainer_MouseEnter);
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.panel3.Controls.Add(this.OnlineList);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Name = "panel3";
            // 
            // OnlineList
            // 
            resources.ApplyResources(this.OnlineList, "OnlineList");
            this.OnlineList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OnlineList.Name = "OnlineList";
            this.OnlineList.TabStop = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Name = "label2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel2.Controls.Add(this.buttonSendMessageButton);
            this.panel2.Controls.Add(this.pictureBoxPendingMessageIcon);
            this.panel2.Controls.Add(this.panel4);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // buttonSendMessageButton
            // 
            resources.ApplyResources(this.buttonSendMessageButton, "buttonSendMessageButton");
            this.buttonSendMessageButton.BackColor = System.Drawing.Color.Transparent;
            this.buttonSendMessageButton.BackgroundImage = global::Bonfire.Properties.Resources.sendIkon;
            this.buttonSendMessageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSendMessageButton.FlatAppearance.BorderSize = 0;
            this.buttonSendMessageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonSendMessageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonSendMessageButton.Name = "buttonSendMessageButton";
            this.buttonSendMessageButton.UseVisualStyleBackColor = false;
            this.buttonSendMessageButton.Click += new System.EventHandler(this.SendMessageBtn_Click);
            // 
            // pictureBoxPendingMessageIcon
            // 
            resources.ApplyResources(this.pictureBoxPendingMessageIcon, "pictureBoxPendingMessageIcon");
            this.pictureBoxPendingMessageIcon.Name = "pictureBoxPendingMessageIcon";
            this.pictureBoxPendingMessageIcon.TabStop = false;
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.panel4.Controls.Add(this.MessageBox);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Name = "panel4";
            // 
            // MessageBox
            // 
            resources.ApplyResources(this.MessageBox, "MessageBox");
            this.MessageBox.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("MessageBox.AutoCompleteCustomSource")});
            this.MessageBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.MessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.TextChanged += new System.EventHandler(this.MessageBox_TextChanged);
            this.MessageBox.Enter += new System.EventHandler(this.MessageBox_Enter);
            this.MessageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyDown);
            this.MessageBox.Leave += new System.EventHandler(this.MessageBox_Leave);
            // 
            // ServerNameHeader
            // 
            this.ServerNameHeader.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ServerNameHeader.Controls.Add(this.DisconnectBtn);
            this.ServerNameHeader.Controls.Add(this.ServerName);
            resources.ApplyResources(this.ServerNameHeader, "ServerNameHeader");
            this.ServerNameHeader.Name = "ServerNameHeader";
            // 
            // DisconnectBtn
            // 
            resources.ApplyResources(this.DisconnectBtn, "DisconnectBtn");
            this.DisconnectBtn.BackColor = System.Drawing.Color.Transparent;
            this.DisconnectBtn.BackgroundImage = global::Bonfire.Properties.Resources.Exit_icon1;
            this.DisconnectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DisconnectBtn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.DisconnectBtn.FlatAppearance.BorderSize = 0;
            this.DisconnectBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DisconnectBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DisconnectBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.UseVisualStyleBackColor = false;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // ServerName
            // 
            resources.ApplyResources(this.ServerName, "ServerName");
            this.ServerName.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.ServerName.Name = "ServerName";
            // 
            // panelTopBorderControls
            // 
            resources.ApplyResources(this.panelTopBorderControls, "panelTopBorderControls");
            this.panelTopBorderControls.BackColor = System.Drawing.SystemColors.Control;
            this.panelTopBorderControls.Controls.Add(this.labelCustomTitle);
            this.panelTopBorderControls.Controls.Add(this.flowLayoutPanelWindowButtons);
            this.panelTopBorderControls.Name = "panelTopBorderControls";
            this.panelTopBorderControls.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelTopBorderControls_MouseDoubleClick);
            this.panelTopBorderControls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBorderControls_MouseDown);
            // 
            // labelCustomTitle
            // 
            resources.ApplyResources(this.labelCustomTitle, "labelCustomTitle");
            this.labelCustomTitle.Name = "labelCustomTitle";
            this.labelCustomTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelCustomTitle_MouseDown);
            // 
            // flowLayoutPanelWindowButtons
            // 
            this.flowLayoutPanelWindowButtons.Controls.Add(this.checkBoxMinimize);
            this.flowLayoutPanelWindowButtons.Controls.Add(this.checkBoxResizeFull);
            this.flowLayoutPanelWindowButtons.Controls.Add(this.checkBoxClose);
            resources.ApplyResources(this.flowLayoutPanelWindowButtons, "flowLayoutPanelWindowButtons");
            this.flowLayoutPanelWindowButtons.Name = "flowLayoutPanelWindowButtons";
            // 
            // checkBoxMinimize
            // 
            resources.ApplyResources(this.checkBoxMinimize, "checkBoxMinimize");
            this.checkBoxMinimize.Name = "checkBoxMinimize";
            this.checkBoxMinimize.UseVisualStyleBackColor = true;
            this.checkBoxMinimize.CheckedChanged += new System.EventHandler(this.checkBoxMinimize_CheckedChanged);
            // 
            // checkBoxResizeFull
            // 
            resources.ApplyResources(this.checkBoxResizeFull, "checkBoxResizeFull");
            this.checkBoxResizeFull.Name = "checkBoxResizeFull";
            this.checkBoxResizeFull.UseVisualStyleBackColor = true;
            this.checkBoxResizeFull.CheckedChanged += new System.EventHandler(this.checkBoxResizeFull_CheckedChanged);
            // 
            // checkBoxClose
            // 
            resources.ApplyResources(this.checkBoxClose, "checkBoxClose");
            this.checkBoxClose.Name = "checkBoxClose";
            this.checkBoxClose.UseVisualStyleBackColor = true;
            this.checkBoxClose.CheckedChanged += new System.EventHandler(this.checkBoxClose_CheckedChanged);
            // 
            // backgroundWorkerMessagePull
            // 
            this.backgroundWorkerMessagePull.WorkerSupportsCancellation = true;
            this.backgroundWorkerMessagePull.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMessagePull_DoWork);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIconMain, "notifyIconMain");
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripNotifyIcon;
            this.notifyIconMain.BalloonTipClicked += new System.EventHandler(this.notifyIconMain_BalloonTipClicked);
            this.notifyIconMain.Click += new System.EventHandler(this.notifyIconMain_Click);
            // 
            // contextMenuStripNotifyIcon
            // 
            this.contextMenuStripNotifyIcon.BackColor = System.Drawing.Color.White;
            this.contextMenuStripNotifyIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.åbenToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItemConnectedServer,
            this.toolStripSeparator1,
            this.lukToolStripMenuItem});
            this.contextMenuStripNotifyIcon.Name = "contextMenuStripNotifyIcon";
            resources.ApplyResources(this.contextMenuStripNotifyIcon, "contextMenuStripNotifyIcon");
            this.contextMenuStripNotifyIcon.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripNotifyIcon_Opening);
            // 
            // åbenToolStripMenuItem
            // 
            this.åbenToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.åbenToolStripMenuItem.Name = "åbenToolStripMenuItem";
            resources.ApplyResources(this.åbenToolStripMenuItem, "åbenToolStripMenuItem");
            this.åbenToolStripMenuItem.Click += new System.EventHandler(this.åbenToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripMenuItemConnectedServer
            // 
            this.toolStripMenuItemConnectedServer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.toolStripMenuItemConnectedServer.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItemConnectedServer.Name = "toolStripMenuItemConnectedServer";
            resources.ApplyResources(this.toolStripMenuItemConnectedServer, "toolStripMenuItemConnectedServer");
            this.toolStripMenuItemConnectedServer.DropDownOpening += new System.EventHandler(this.toolStripMenuItemConnectedServer_DropDownOpening);
            this.toolStripMenuItemConnectedServer.Click += new System.EventHandler(this.toolStripMenuItemConnectedServer_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // lukToolStripMenuItem
            // 
            this.lukToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.lukToolStripMenuItem.Name = "lukToolStripMenuItem";
            resources.ApplyResources(this.lukToolStripMenuItem, "lukToolStripMenuItem");
            this.lukToolStripMenuItem.Click += new System.EventHandler(this.lukToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTopBorderControls);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.TextChanged += new System.EventHandler(this.FormMain_TextChanged);
            this.Enter += new System.EventHandler(this.FormMain_Enter);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPendingMessageIcon)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ServerNameHeader.ResumeLayout(false);
            this.ServerNameHeader.PerformLayout();
            this.panelTopBorderControls.ResumeLayout(false);
            this.panelTopBorderControls.PerformLayout();
            this.flowLayoutPanelWindowButtons.ResumeLayout(false);
            this.contextMenuStripNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label ServerName;
        private System.Windows.Forms.Panel ServerNameHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel OnlineList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel MessageContainer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel ServerList;
        private System.Windows.Forms.Button ServerMenuBtn;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panelTopBorderControls;
        private System.Windows.Forms.CheckBox checkBoxClose;
        private System.Windows.Forms.CheckBox checkBoxResizeFull;
        private System.Windows.Forms.CheckBox checkBoxMinimize;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelWindowButtons;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMessagePull;
        private System.Windows.Forms.PictureBox pictureBoxPendingMessageIcon;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem åbenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem lukToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConnectedServer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label labelCustomTitle;
        private System.Windows.Forms.ToolTip toolTipServerEntry;
        private System.Windows.Forms.Panel BonfireLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonSendMessageButton;
        private System.Windows.Forms.Button DisconnectBtn;
    }
}

