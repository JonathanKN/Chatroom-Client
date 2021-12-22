
namespace Chatrum
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
            this.ServernameLabel = new System.Windows.Forms.Label();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.checkBoxConnected = new System.Windows.Forms.CheckBox();
            this.ContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServernameLabel
            // 
            this.ServernameLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ServernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
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
            // ContainerPanel
            // 
            this.ContainerPanel.Controls.Add(this.checkBoxConnected);
            this.ContainerPanel.Controls.Add(this.ServernameLabel);
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.ContainerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(150, 40);
            this.ContainerPanel.TabIndex = 1;
            // 
            // checkBoxConnected
            // 
            this.checkBoxConnected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxConnected.AutoCheck = false;
            this.checkBoxConnected.AutoSize = true;
            this.checkBoxConnected.Location = new System.Drawing.Point(123, 15);
            this.checkBoxConnected.Name = "checkBoxConnected";
            this.checkBoxConnected.Size = new System.Drawing.Size(15, 14);
            this.checkBoxConnected.TabIndex = 1;
            this.checkBoxConnected.UseVisualStyleBackColor = true;
            // 
            // ServerListEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContainerPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ServerListEntry";
            this.Size = new System.Drawing.Size(150, 40);
            this.ContainerPanel.ResumeLayout(false);
            this.ContainerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ContainerPanel;
        public System.Windows.Forms.Label ServernameLabel;
        private System.Windows.Forms.CheckBox checkBoxConnected;
    }
}
