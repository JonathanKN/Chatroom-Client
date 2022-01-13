
namespace Bonfire
{
    partial class AddServerPrompt
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddServerPrompt));
			this.AddServerBtn = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.ServerPortInput = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.ServerNicknameInput = new System.Windows.Forms.TextBox();
			this.labelInvalidPort = new System.Windows.Forms.Label();
			this.labelInvalidServerNickname = new System.Windows.Forms.Label();
			this.ServerIPInput = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.labelInvalidIP = new System.Windows.Forms.Label();
			this.panel5.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// AddServerBtn
			// 
			resources.ApplyResources(this.AddServerBtn, "AddServerBtn");
			this.AddServerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
			this.AddServerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AddServerBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
			this.AddServerBtn.Name = "AddServerBtn";
			this.AddServerBtn.UseVisualStyleBackColor = false;
			this.AddServerBtn.Click += new System.EventHandler(this.AddServerBtn_Click);
			// 
			// panel5
			// 
			resources.ApplyResources(this.panel5, "panel5");
			this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
			this.panel5.Controls.Add(this.ServerPortInput);
			this.panel5.Name = "panel5";
			// 
			// ServerPortInput
			// 
			this.ServerPortInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
			this.ServerPortInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(this.ServerPortInput, "ServerPortInput");
			this.ServerPortInput.Name = "ServerPortInput";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveBorder;
			this.label3.Name = "label3";
			// 
			// buttonClose
			// 
			resources.ApplyResources(this.buttonClose, "buttonClose");
			this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.ForeColor = System.Drawing.Color.Red;
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
			this.label2.Name = "label2";
			// 
			// panel2
			// 
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
			this.panel2.Controls.Add(this.ServerNicknameInput);
			this.panel2.Name = "panel2";
			// 
			// ServerNicknameInput
			// 
			this.ServerNicknameInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
			this.ServerNicknameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(this.ServerNicknameInput, "ServerNicknameInput");
			this.ServerNicknameInput.Name = "ServerNicknameInput";
			// 
			// labelInvalidPort
			// 
			resources.ApplyResources(this.labelInvalidPort, "labelInvalidPort");
			this.labelInvalidPort.ForeColor = System.Drawing.Color.Brown;
			this.labelInvalidPort.Name = "labelInvalidPort";
			// 
			// labelInvalidServerNickname
			// 
			resources.ApplyResources(this.labelInvalidServerNickname, "labelInvalidServerNickname");
			this.labelInvalidServerNickname.ForeColor = System.Drawing.Color.Brown;
			this.labelInvalidServerNickname.Name = "labelInvalidServerNickname";
			// 
			// ServerIPInput
			// 
			this.ServerIPInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
			this.ServerIPInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(this.ServerIPInput, "ServerIPInput");
			this.ServerIPInput.Name = "ServerIPInput";
			// 
			// panel1
			// 
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
			this.panel1.Controls.Add(this.ServerIPInput);
			this.panel1.Name = "panel1";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
			this.label1.Name = "label1";
			// 
			// labelInvalidIP
			// 
			resources.ApplyResources(this.labelInvalidIP, "labelInvalidIP");
			this.labelInvalidIP.ForeColor = System.Drawing.Color.Brown;
			this.labelInvalidIP.Name = "labelInvalidIP";
			// 
			// AddServerPrompt
			// 
			this.AcceptButton = this.AddServerBtn;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(64)))), ((int)(((byte)(69)))));
			this.CancelButton = this.buttonClose;
			this.Controls.Add(this.labelInvalidServerNickname);
			this.Controls.Add(this.labelInvalidPort);
			this.Controls.Add(this.labelInvalidIP);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.AddServerBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddServerPrompt";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.AddServerPrompt_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddServerPrompt_MouseDown);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddServerBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelInvalidPort;
        private System.Windows.Forms.Label labelInvalidServerNickname;
        private System.Windows.Forms.TextBox ServerPortInput;
        private System.Windows.Forms.TextBox ServerNicknameInput;
        private System.Windows.Forms.TextBox ServerIPInput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInvalidIP;
    }
}