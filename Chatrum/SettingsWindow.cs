using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Chatrum
{
    public partial class SettingsWindow : Form
    {
        public string name;

        public SettingsWindow(string userName)
        {
            name = userName;
            Thread.CurrentThread.CurrentUICulture = Properties.Settings.Default.Language;
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddServerPrompt_Load(object sender, EventArgs e)
        {
            NameTextBox.Text = name;

            // populate language selection
            comboBoxLanguageSelection.Items.Clear();
            comboBoxLanguageSelection.Items.Add("Dansk");
            comboBoxLanguageSelection.Items.Add("Esperanto");

            if (Properties.Settings.Default.Language.TwoLetterISOLanguageName.ToLower() == "eo")
            {
                comboBoxLanguageSelection.SelectedIndex = 1;
            }
            else
            {
                comboBoxLanguageSelection.SelectedIndex = 0;
            }

            // update message sound button
            checkBoxMessageSound.Checked = Properties.Settings.Default.MessageSound;
        }

        private void AddServerBtn_Click(object sender, EventArgs e)
        {
            name = NameTextBox.Text;
            Close();
        }

        private void AddServerPrompt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeFunctions.ReleaseCapture();
                NativeFunctions.SendMessage(Handle, NativeFunctions.WM_NCLBUTTONDOWN, NativeFunctions.HT_CAPTION, 0);
            }
        }

        private void UpdateLanguageSetting(CultureInfo cultureInfo)
        {
            Properties.Settings.Default.Language = cultureInfo;
            Properties.Settings.Default.Save();
        }

        private void UpdateMessageSoundSetting(bool setting)
        {
            Properties.Settings.Default.MessageSound = setting;
            Properties.Settings.Default.Save();
        }

        private void comboBoxLanguageSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((string)comboBoxLanguageSelection.SelectedItem)
            {
                case "Dansk":
                    UpdateLanguageSetting(new CultureInfo("da"));
                    break;
                case "Esperanto":
                    UpdateLanguageSetting(new CultureInfo("eo"));
                    break;
                default:
                    break;
            }
        }

        private void checkBoxMessageSound_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMessageSoundSetting(checkBoxMessageSound.Checked);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
