
namespace Chatrum
{
    partial class Form1
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
            this.AddServerMenu = new System.Windows.Forms.Panel();
            this.AddServerBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ServerPortInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ServerIPInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.AddServerMenu.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(113)))), ((int)(((byte)(110)))));
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.splitContainer1.Panel1MinSize = 214;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MessageContainer);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.ServerNameHeader);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 588);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ServerList);
            this.splitContainer2.Panel1.Controls.Add(this.ServerMenuBtn);
            this.splitContainer2.Size = new System.Drawing.Size(233, 588);
            this.splitContainer2.SplitterDistance = 344;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 2;
            // 
            // ServerList
            // 
            this.ServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ServerList.AutoScroll = true;
            this.ServerList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ServerList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ServerList.Location = new System.Drawing.Point(-42, 108);
            this.ServerList.Margin = new System.Windows.Forms.Padding(4, 5, 20, 5);
            this.ServerList.Name = "ServerList";
            this.ServerList.Size = new System.Drawing.Size(249, 231);
            this.ServerList.TabIndex = 0;
            this.ServerList.WrapContents = false;
            // 
            // ServerMenuBtn
            // 
            this.ServerMenuBtn.BackColor = System.Drawing.Color.DarkGray;
            this.ServerMenuBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ServerMenuBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.ServerMenuBtn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.ServerMenuBtn.FlatAppearance.BorderSize = 0;
            this.ServerMenuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServerMenuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerMenuBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ServerMenuBtn.Location = new System.Drawing.Point(75, 31);
            this.ServerMenuBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ServerMenuBtn.Name = "ServerMenuBtn";
            this.ServerMenuBtn.Size = new System.Drawing.Size(198, 52);
            this.ServerMenuBtn.TabIndex = 1;
            this.ServerMenuBtn.Text = "Tilføj server";
            this.ServerMenuBtn.UseVisualStyleBackColor = false;
            this.ServerMenuBtn.Click += new System.EventHandler(this.AddServerBtn_Click);
            // 
            // MessageContainer
            // 
            this.MessageContainer.AutoScroll = true;
            this.MessageContainer.AutoSize = true;
            this.MessageContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MessageContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.MessageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageContainer.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.MessageContainer.Location = new System.Drawing.Point(0, 131);
            this.MessageContainer.Name = "MessageContainer";
            this.MessageContainer.Size = new System.Drawing.Size(459, 351);
            this.MessageContainer.TabIndex = 1;
            this.MessageContainer.WrapContents = false;
            this.MessageContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.panel3.Controls.Add(this.OnlineList);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(459, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 351);
            this.panel3.TabIndex = 15;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // OnlineList
            // 
            this.OnlineList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OnlineList.AutoScroll = true;
            this.OnlineList.AutoSize = true;
            this.OnlineList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.OnlineList.Location = new System.Drawing.Point(20, 82);
            this.OnlineList.Name = "OnlineList";
            this.OnlineList.Size = new System.Drawing.Size(298, 245);
            this.OnlineList.TabIndex = 1;
            this.OnlineList.WrapContents = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(20, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 52);
            this.label2.TabIndex = 0;
            this.label2.Text = "Online:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 482);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(789, 106);
            this.panel2.TabIndex = 14;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.panel4.Controls.Add(this.MessageBox);
            this.panel4.Location = new System.Drawing.Point(48, 25);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(8, 9, 8, 8);
            this.panel4.Size = new System.Drawing.Size(1155, 55);
            this.panel4.TabIndex = 1;
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.MessageBox.Location = new System.Drawing.Point(8, 9);
            this.MessageBox.MaxLength = 150;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(1139, 32);
            this.MessageBox.TabIndex = 0;
            this.MessageBox.Text = "Skriv din besked her...";
            this.MessageBox.TextChanged += new System.EventHandler(this.MessageBox_TextChanged);
            this.MessageBox.Enter += new System.EventHandler(this.MessageBox_Enter);
            this.MessageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyDown);
            this.MessageBox.Leave += new System.EventHandler(this.MessageBox_Leave);
            // 
            // ServerNameHeader
            // 
            this.ServerNameHeader.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ServerNameHeader.Controls.Add(this.ServerName);
            this.ServerNameHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ServerNameHeader.Location = new System.Drawing.Point(0, 0);
            this.ServerNameHeader.Name = "ServerNameHeader";
            this.ServerNameHeader.Size = new System.Drawing.Size(789, 131);
            this.ServerNameHeader.TabIndex = 13;
            // 
            // ServerName
            // 
            this.ServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerName.AutoSize = true;
            this.ServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerName.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.ServerName.Location = new System.Drawing.Point(36, 20);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(566, 79);
            this.ServerName.TabIndex = 12;
            this.ServerName.Text = "Esperanto server";
            this.ServerName.Click += new System.EventHandler(this.label13_Click);
            // 
            // AddServerMenu
            // 
            this.AddServerMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddServerMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.AddServerMenu.Controls.Add(this.AddServerBtn);
            this.AddServerMenu.Controls.Add(this.panel5);
            this.AddServerMenu.Controls.Add(this.label3);
            this.AddServerMenu.Controls.Add(this.panel1);
            this.AddServerMenu.Controls.Add(this.label1);
            this.AddServerMenu.Location = new System.Drawing.Point(352, 63);
            this.AddServerMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddServerMenu.Name = "AddServerMenu";
            this.AddServerMenu.Size = new System.Drawing.Size(336, 435);
            this.AddServerMenu.TabIndex = 0;
            this.AddServerMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.AddServerMenu_Paint);
            // 
            // AddServerBtn
            // 
            this.AddServerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddServerBtn.Location = new System.Drawing.Point(72, 325);
            this.AddServerBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddServerBtn.Name = "AddServerBtn";
            this.AddServerBtn.Size = new System.Drawing.Size(188, 69);
            this.AddServerBtn.TabIndex = 2;
            this.AddServerBtn.Text = "Forbind";
            this.AddServerBtn.UseVisualStyleBackColor = true;
            this.AddServerBtn.Click += new System.EventHandler(this.AddServerBtn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.ServerPortInput);
            this.panel5.Location = new System.Drawing.Point(28, 223);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(8, 15, 0, 0);
            this.panel5.Size = new System.Drawing.Size(279, 65);
            this.panel5.TabIndex = 3;
            // 
            // ServerPortInput
            // 
            this.ServerPortInput.BackColor = System.Drawing.Color.Silver;
            this.ServerPortInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServerPortInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerPortInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerPortInput.Location = new System.Drawing.Point(8, 15);
            this.ServerPortInput.Margin = new System.Windows.Forms.Padding(8, 15, 8, 8);
            this.ServerPortInput.Name = "ServerPortInput";
            this.ServerPortInput.Size = new System.Drawing.Size(271, 34);
            this.ServerPortInput.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Server Port:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.ServerIPInput);
            this.panel1.Location = new System.Drawing.Point(28, 85);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 15, 0, 0);
            this.panel1.Size = new System.Drawing.Size(279, 65);
            this.panel1.TabIndex = 1;
            // 
            // ServerIPInput
            // 
            this.ServerIPInput.BackColor = System.Drawing.Color.Silver;
            this.ServerIPInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServerIPInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerIPInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerIPInput.Location = new System.Drawing.Point(8, 15);
            this.ServerIPInput.Margin = new System.Windows.Forms.Padding(8, 15, 8, 8);
            this.ServerIPInput.Name = "ServerIPInput";
            this.ServerIPInput.Size = new System.Drawing.Size(271, 34);
            this.ServerIPInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 588);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.AddServerMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
            this.AddServerMenu.ResumeLayout(false);
            this.AddServerMenu.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel AddServerMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ServerIPInput;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox ServerPortInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddServerBtn;
    }
}

