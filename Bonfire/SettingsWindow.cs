using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Bonfire
{
    public partial class SettingsWindow : Form
    {
        private CultureInfo[] supportedLanguages;

        /// <summary>
        /// Ignores calls to <c>UpdatedIndex</c> during population.
        /// </summary>
        private bool populatingCombobox;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsWindow"/> class.
        /// </summary>
        public SettingsWindow()
        {
            Thread.CurrentThread.CurrentUICulture = PreferenceHelper.LoadedLanguage;
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void AddServerPrompt_Load(object sender, EventArgs e)
        {
            // populate language selection
            supportedLanguages = new CultureInfo[]
            {
                new CultureInfo("da"), // default
                new CultureInfo("eo"),
            };

            populatingCombobox = true;
            var selectedLanguage = Properties.Settings.Default.Language;
            comboBoxLanguageSelection.Items.Clear();
            foreach (var language in supportedLanguages)
            {
                int index = comboBoxLanguageSelection.Items.Add(language.Name);

                if (language.Name == selectedLanguage.Name)
                {
                    comboBoxLanguageSelection.SelectedIndex = index;
                }
            }

            populatingCombobox = false;

            // update nickname input
            NicknameTextBox.Text = Properties.Settings.Default.Nickname;

            // update message sound button
            checkBoxMessageSound.Checked = Properties.Settings.Default.MessageSound;

            // set restart changes
            labelRestartChanges.Visible = Properties.Settings.Default.Language.Name != PreferenceHelper.LoadedLanguage.Name;
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
            CultureInfo previousInfo = Properties.Settings.Default.Language;
            Properties.Settings.Default.Language = cultureInfo;

            labelRestartChanges.Visible = previousInfo.Name != cultureInfo.Name;

            buttonApply.Enabled = true;
            Properties.Settings.Default.Save();
        }

        private void comboBoxLanguageSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (populatingCombobox)
            {
                return;
            }

            UpdateLanguageSetting(supportedLanguages[comboBoxLanguageSelection.SelectedIndex]);
        }

        private void UpdateMessageSoundSetting(bool setting)
        {
            buttonApply.Enabled = true;
            Properties.Settings.Default.MessageSound = setting;
            Properties.Settings.Default.Save();
        }

        private void checkBoxMessageSound_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMessageSoundSetting(checkBoxMessageSound.Checked);
        }

        private void NicknameTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Nickname = NicknameTextBox.Text;
            Properties.Settings.Default.Save();
            buttonApply.Enabled = true;
        }

        private void buttonColophon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lavet af Patrick, Kresten og Jonathan.\n" +
                "- Protokol designet af Patrick, revideret af Daniel og Kresten\n" +
                "- Brugerflade designet og implementeret af Jonathan, ekstra funktionaliter implementeret af Kresten\n" +
                "- Backend implementeret af Patrick\n" +
                "- Server implementeret af Kresten");
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            buttonApply.Enabled = false;
        }
    }
}
