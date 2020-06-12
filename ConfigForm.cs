using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Tweak
{
    public partial class ConfigForm : Form
    {
        private readonly Config _config;
        private readonly Dictionary<EnumDesktopAction, RadioButton> _desktop;
        private readonly Dictionary<EnumFilesAction, RadioButton> _download;
        private readonly Dictionary<EnumFilesAction, RadioButton> _others;
        private readonly Dictionary<EnumThemeAction, RadioButton> _theme;
        
        private readonly string _salt = Program.getUUID();
        private readonly RegistryValue _hash = Program.GetRegistryValue(EnumKnownRegistry.PasswordHash);
        
        
        public ConfigForm() : this(new Config())
        {
        }
        
        public ConfigForm(Config config)
        {
            InitializeComponent();
            _config = config;
            _desktop = new Dictionary<EnumDesktopAction, RadioButton>
            {
                {EnumDesktopAction.DeleteAll, DesktopDeleteAll},
                {EnumDesktopAction.DeleteOld, DesktopDeleteOld},
                {EnumDesktopAction.DeleteOldAndMove, DesktopDeleteOldAndMove},
                {EnumDesktopAction.Move, DesktopMoveAll},
                {EnumDesktopAction.Nothing, DesktopNothing}
            };
            _download = new Dictionary<EnumFilesAction, RadioButton>
            {
                {EnumFilesAction.DeleteAll, DownloadsDeleteAll},
                {EnumFilesAction.DeleteOld, DownloadsDeleteOld},
                {EnumFilesAction.Nothing, DownloadsNothing}
            };
            _others = new Dictionary<EnumFilesAction, RadioButton>
            {
                {EnumFilesAction.DeleteAll, OthersDeleteAll},
                {EnumFilesAction.DeleteOld, OthersDeleteOld},
                {EnumFilesAction.Nothing, OthersNothing}
            };
            _theme = new Dictionary<EnumThemeAction, RadioButton>
            {
                {EnumThemeAction.Default, ThemeSetDefault},
                {EnumThemeAction.Nothing, ThemeNothing}
            };
            _desktop[_config.DesktopAction].Checked = true;
            _download[_config.DownloadsAction].Checked = true;
            _others[_config.OthersAction].Checked = true;
            _theme[_config.ThemeAction].Checked = true;
            DesktopReadonlyCheckBox.Checked = _config.DesktopReadonly;
            DownloadsReadonlyCheckBox.Checked = _config.DownloadsReadonly;
            OthersReadonlyCheckBox.Checked = _config.OthersReadonly;
            ThemeLookCheckBox.Checked = _config.ThemeLock;
            ThemeLookPictureCheckBox.Checked = _config.ThemeLockPicture;
            TempDeleteCheckBox.Checked = _config.TempDelete;
            TempDeleteHistoryCheckBox.Checked = _config.TempDeleteHistory;
            DailyCheckBox.Checked = _config.Daily;
            ProtectCheckBox.Checked = _hash.GetValue<string>() != "";
        }

        private void Desktop_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked)
                _config.DesktopAction = _desktop
                    .FirstOrDefault(x => x.Value == sender)
                    .Key;
        }

        private void Download_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked)
                _config.DownloadsAction = _download
                    .FirstOrDefault(x => x.Value == sender)
                    .Key;
        }

        private void Others_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked)
                _config.OthersAction = _others
                    .FirstOrDefault(x => x.Value == sender)
                    .Key;
        }

        private void Theme_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked)
                _config.ThemeAction = _theme
                    .FirstOrDefault(x => x.Value == sender)
                    .Key;
        }

        private void DesktopReadonlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.DesktopReadonly = ((CheckBox) sender).Checked;
        }

        private void DownloadsReadonlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.DownloadsReadonly = ((CheckBox) sender).Checked;
        }

        private void OthersReadonlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.OthersReadonly = ((CheckBox) sender).Checked;
        }

        private void ThemeLookCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.ThemeLock = ((CheckBox) sender).Checked;
        }

        private void ThemeLookPictureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.ThemeLockPicture = ((CheckBox) sender).Checked;
        }

        private void TempDeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.TempDelete = ((CheckBox) sender).Checked;
        }

        private void TempDeleteHistoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.TempDeleteHistory = ((CheckBox) sender).Checked;
        }

        private void DailyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.Daily = ((CheckBox) sender).Checked;
        }

        private void OpenProgramsButton_Click(object sender, EventArgs e)
        {
            new Process
            {
                EnableRaisingEvents = false, StartInfo = {FileName = "appwiz.cpl", UseShellExecute = true}
            }.Start();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Hide();
            var progressForm = new ProgressForm(_config);
            progressForm.Closed += (s, args) => Close(); 
            progressForm.Show();
        }

        private void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            var hash = _hash.GetValue<string>();
            if (hash == "") return;
            var salt = string.Copy(_salt);
            string value;
            do
            {
                if (PromptForm.GetText(out value) == DialogResult.Abort) Application.Exit();
            } while (hash != Program.ComputeHash(value, ref salt));
        }

        private void ProtectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            if (ProtectCheckBox.Checked)
            {
                if (PromptForm.GetText(out var value) == DialogResult.Abort) return;
                var salt = string.Copy(_salt);
                _hash.SetValue(Program.ComputeHash(value, ref salt));
            }
            else
            {
                _hash.SetValue("");
            }
        }
    }
}