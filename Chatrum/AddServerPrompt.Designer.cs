
namespace Chatrum
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ServerIPInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddServerBtn
            // 
            this.AddServerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.AddServerBtn, "AddServerBtn");
            this.AddServerBtn.Name = "AddServerBtn";
            this.AddServerBtn.UseVisualStyleBackColor = true;
            this.AddServerBtn.Click += new System.EventHandler(this.AddServerBtn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.ServerPortInput);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // ServerPortInput
            // 
            this.ServerPortInput.BackColor = System.Drawing.Color.Silver;
            this.ServerPortInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.ServerPortInput, "ServerPortInput");
            this.ServerPortInput.Name = "ServerPortInput";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.ServerIPInput);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // ServerIPInput
            // 
            this.ServerIPInput.BackColor = System.Drawing.Color.Silver;
            this.ServerIPInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.ServerIPInput, "ServerIPInput");
            this.ServerIPInput.Name = "ServerIPInput";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.ForeColor = System.Drawing.Color.Red;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // AddServerPrompt
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddServerBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        public System.Windows.Forms.TextBox ServerIPInput;
        public System.Windows.Forms.TextBox ServerPortInput;
    }
}