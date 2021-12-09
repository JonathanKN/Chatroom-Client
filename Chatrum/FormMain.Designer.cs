
namespace Chatrum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ServerList = new System.Windows.Forms.FlowLayoutPanel();
            this.ServerMenuBtn = new System.Windows.Forms.Button();
            this.MessageContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.OnlineList = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.ServerNameHeader = new System.Windows.Forms.Panel();
            this.ServerName = new System.Windows.Forms.Label();
            this.panelTopBorderControls = new System.Windows.Forms.Panel();
            this.checkBoxMinimize = new System.Windows.Forms.CheckBox();
            this.checkBoxResizeFull = new System.Windows.Forms.CheckBox();
            this.checkBoxClose = new System.Windows.Forms.CheckBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.flowLayoutPanelWindowButtons = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.ServerNameHeader.SuspendLayout();
            this.panelTopBorderControls.SuspendLayout();
            this.flowLayoutPanelWindowButtons.SuspendLayout();
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
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.buttonSettings);
            this.splitContainer2.Panel1.Controls.Add(this.ServerList);
            this.splitContainer2.Panel1.Controls.Add(this.ServerMenuBtn);
            // 
            // ServerList
            // 
            resources.ApplyResources(this.ServerList, "ServerList");
            this.ServerList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ServerList.Name = "ServerList";
            // 
            // ServerMenuBtn
            // 
            this.ServerMenuBtn.BackColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.ServerMenuBtn, "ServerMenuBtn");
            this.ServerMenuBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ServerMenuBtn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.ServerMenuBtn.FlatAppearance.BorderSize = 0;
            this.ServerMenuBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ServerMenuBtn.Name = "ServerMenuBtn";
            this.ServerMenuBtn.UseVisualStyleBackColor = false;
            this.ServerMenuBtn.Click += new System.EventHandler(this.ServerMenuBtn_Click);
            // 
            // MessageContainer
            // 
            resources.ApplyResources(this.MessageContainer, "MessageContainer");
            this.MessageContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.MessageContainer.Name = "MessageContainer";
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
            this.OnlineList.Name = "OnlineList";
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
            this.panel2.Controls.Add(this.panel4);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.panel4.Controls.Add(this.MessageBox);
            this.panel4.Name = "panel4";
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.MessageBox, "MessageBox");
            this.MessageBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Enter += new System.EventHandler(this.MessageBox_Enter);
            this.MessageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyDown);
            this.MessageBox.Leave += new System.EventHandler(this.MessageBox_Leave);
            // 
            // ServerNameHeader
            // 
            this.ServerNameHeader.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ServerNameHeader.Controls.Add(this.ServerName);
            resources.ApplyResources(this.ServerNameHeader, "ServerNameHeader");
            this.ServerNameHeader.Name = "ServerNameHeader";
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
            this.panelTopBorderControls.Controls.Add(this.flowLayoutPanelWindowButtons);
            this.panelTopBorderControls.Name = "panelTopBorderControls";
            this.panelTopBorderControls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBorderControls_MouseDown);
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
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.buttonSettings, "buttonSettings");
            this.buttonSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSettings.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // flowLayoutPanelWindowButtons
            // 
            this.flowLayoutPanelWindowButtons.Controls.Add(this.checkBoxMinimize);
            this.flowLayoutPanelWindowButtons.Controls.Add(this.checkBoxResizeFull);
            this.flowLayoutPanelWindowButtons.Controls.Add(this.checkBoxClose);
            resources.ApplyResources(this.flowLayoutPanelWindowButtons, "flowLayoutPanelWindowButtons");
            this.flowLayoutPanelWindowButtons.Name = "flowLayoutPanelWindowButtons";
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTopBorderControls);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ServerNameHeader.ResumeLayout(false);
            this.ServerNameHeader.PerformLayout();
            this.panelTopBorderControls.ResumeLayout(false);
            this.flowLayoutPanelWindowButtons.ResumeLayout(false);
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
    }
}

