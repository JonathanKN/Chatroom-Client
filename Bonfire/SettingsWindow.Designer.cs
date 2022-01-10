
namespace Bonfire
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.labelUILanguage = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.comboBoxLanguageSelection = new System.Windows.Forms.ComboBox();
            this.checkBoxMessageSound = new System.Windows.Forms.CheckBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonColophon = new System.Windows.Forms.Button();
            this.labelRestartChanges = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NicknameTextBox = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUILanguage
            // 
            resources.ApplyResources(this.labelUILanguage, "labelUILanguage");
            this.labelUILanguage.ForeColor = System.Drawing.Color.LightGray;
            this.labelUILanguage.Name = "labelUILanguage";
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
            // comboBoxLanguageSelection
            // 
            this.comboBoxLanguageSelection.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.comboBoxLanguageSelection, "comboBoxLanguageSelection");
            this.comboBoxLanguageSelection.FormattingEnabled = true;
            this.comboBoxLanguageSelection.Items.AddRange(new object[] {
            resources.GetString("comboBoxLanguageSelection.Items"),
            resources.GetString("comboBoxLanguageSelection.Items1")});
            this.comboBoxLanguageSelection.Name = "comboBoxLanguageSelection";
            this.comboBoxLanguageSelection.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguageSelection_SelectedIndexChanged);
            // 
            // checkBoxMessageSound
            // 
            resources.ApplyResources(this.checkBoxMessageSound, "checkBoxMessageSound");
            this.checkBoxMessageSound.ForeColor = System.Drawing.Color.LightGray;
            this.checkBoxMessageSound.Name = "checkBoxMessageSound";
            this.checkBoxMessageSound.UseVisualStyleBackColor = true;
            this.checkBoxMessageSound.CheckedChanged += new System.EventHandler(this.checkBoxMessageSound_CheckedChanged);
            // 
            // labelUsername
            // 
            resources.ApplyResources(this.labelUsername, "labelUsername");
            this.labelUsername.ForeColor = System.Drawing.Color.LightGray;
            this.labelUsername.Name = "labelUsername";
            // 
            // buttonColophon
            // 
            resources.ApplyResources(this.buttonColophon, "buttonColophon");
            this.buttonColophon.BackColor = System.Drawing.Color.DarkGray;
            this.buttonColophon.FlatAppearance.BorderSize = 0;
            this.buttonColophon.Name = "buttonColophon";
            this.buttonColophon.UseVisualStyleBackColor = false;
            this.buttonColophon.Click += new System.EventHandler(this.buttonColophon_Click);
            // 
            // labelRestartChanges
            // 
            resources.ApplyResources(this.labelRestartChanges, "labelRestartChanges");
            this.labelRestartChanges.ForeColor = System.Drawing.Color.Brown;
            this.labelRestartChanges.Name = "labelRestartChanges";
            // 
            // buttonApply
            // 
            resources.ApplyResources(this.buttonApply, "buttonApply");
            this.buttonApply.BackColor = System.Drawing.Color.DarkGray;
            this.buttonApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonApply.FlatAppearance.BorderSize = 0;
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.NicknameTextBox);
            this.panel2.Name = "panel2";
            // 
            // NicknameTextBox
            // 
            this.NicknameTextBox.BackColor = System.Drawing.Color.Silver;
            this.NicknameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.NicknameTextBox, "NicknameTextBox");
            this.NicknameTextBox.Name = "NicknameTextBox";
            this.NicknameTextBox.TextChanged += new System.EventHandler(this.NicknameTextBox_TextChanged);
            // 
            // SettingsWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.CancelButton = this.buttonClose;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.labelRestartChanges);
            this.Controls.Add(this.buttonColophon);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.checkBoxMessageSound);
            this.Controls.Add(this.comboBoxLanguageSelection);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelUILanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddServerPrompt_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddServerPrompt_MouseDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelUILanguage;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxLanguageSelection;
        private System.Windows.Forms.CheckBox checkBoxMessageSound;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonColophon;
        private System.Windows.Forms.Label labelRestartChanges;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox NicknameTextBox;
    }
}