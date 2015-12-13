using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CRUtils
{
    public partial class SettingsScreen : UserControl
    {
        private Form1 form;
        private RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public SettingsScreen(Form1 form)
        {
            this.form = form;
            InitializeComponent();
            cbHideAtStartup.Checked = form.settings.HideAtStartup;
            cbHideOnClose.Checked = form.settings.HideOnClose;
            cbMediaControl.Checked = form.settings.MediaControlEnabled;
            cbSpotify.Checked = form.settings.SpotifyNotificationsEnabled;

            gbMediaPlayerControls.Enabled = form.settings.MediaControlEnabled;
            cbSaveScreenshots.Checked = form.settings.ScreenshotSaveEnabled;
            gbSaveScreenshotSettings.Enabled = form.settings.ScreenshotSaveEnabled;
            gbSpotify.Enabled = form.settings.SpotifyNotificationsEnabled;

            tbPlayBtn1.Text = form.settings.PlayPauseButtons.Count > 0 ? form.settings.PlayPauseButtons[0] : "";
            tbPlayBtn2.Text = form.settings.PlayPauseButtons.Count > 1 ? form.settings.PlayPauseButtons[1] : "";
            tbPlayBtn3.Text = form.settings.PlayPauseButtons.Count > 2 ? form.settings.PlayPauseButtons[2] : "";

            tbNextBtn1.Text = form.settings.NextTrackButtons.Count > 0 ? form.settings.NextTrackButtons[0] : "";
            tbNextBtn2.Text = form.settings.NextTrackButtons.Count > 1 ? form.settings.NextTrackButtons[1] : "";
            tbNextBtn3.Text = form.settings.NextTrackButtons.Count > 2 ? form.settings.NextTrackButtons[2] : "";

            tbPrevBtn1.Text = form.settings.PrevTrackButtons.Count > 0 ? form.settings.PrevTrackButtons[0] : "";
            tbPrevBtn2.Text = form.settings.PrevTrackButtons.Count > 1 ? form.settings.PrevTrackButtons[1] : "";
            tbPrevBtn3.Text = form.settings.PrevTrackButtons.Count > 2 ? form.settings.PrevTrackButtons[2] : "";

            tbScreenshotSavePath.Text = form.settings.ScreenshotSavePath;

            btnSpotifyConnect.Text = form.SpotifyConnected ? "Disconnect" : "Connect";

            if (rkApp.GetValue("CRUtils") == null)
            {
                cbRunAtStart.Checked = false;
            }
            else
            {
                cbRunAtStart.Checked = true;
            }
            form.Refresh();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ScreenshotFolderSelect.ShowDialog() == DialogResult.OK)
            {
                tbScreenshotSavePath.Text = ScreenshotFolderSelect.SelectedPath;
            }
        }

        private void cbMediaControl_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMediaControl.Checked)
            {
                gbMediaPlayerControls.Enabled = true;
            }
            else
            {
                gbMediaPlayerControls.Enabled = false;
            }
        }

        private void cbSaveScreenshots_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSaveScreenshots.Checked)
            {
                gbSaveScreenshotSettings.Enabled = true;
            }
            else
            {
                gbSaveScreenshotSettings.Enabled = false;
            }
        }

        private void cbSpotify_CheckedChanged(object sender, EventArgs e)
        {
            gbSpotify.Enabled = cbSpotify.Checked;
        }

        private void SettingsScreen_Click(object sender, EventArgs e)
        {
            panel1.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool btnPlay1 = false;
            bool btnPlay2 = false;
            bool btnPlay3 = false;

            bool btnNext1 = false;
            bool btnNext2 = false;
            bool btnNext3 = false;

            bool btnPrev1 = false;
            bool btnPrev2 = false;
            bool btnPrev3 = false;
            foreach (Keys k in Enum.GetValues(typeof(Keys)))
            {
                if (k.ToString() == tbPlayBtn1.Text || tbPlayBtn1.Text == "")
                {
                    btnPlay1 = true;
                }
                if (k.ToString() == tbPlayBtn2.Text || tbPlayBtn2.Text == "")
                {
                    btnPlay2 = true;
                }
                if (k.ToString() == tbPlayBtn3.Text || tbPlayBtn3.Text == "")
                {
                    btnPlay3 = true;
                }

                if (k.ToString() == tbNextBtn1.Text || tbNextBtn1.Text == "")
                {
                    btnNext1 = true;
                }
                if (k.ToString() == tbNextBtn2.Text || tbNextBtn2.Text == "")
                {
                    btnNext2 = true;
                }
                if (k.ToString() == tbNextBtn3.Text || tbNextBtn3.Text == "")
                {
                    btnNext3 = true;
                }

                if (k.ToString() == tbPrevBtn1.Text || tbPrevBtn1.Text == "")
                {
                    btnPrev1 = true;
                }
                if (k.ToString() == tbPrevBtn2.Text || tbPrevBtn2.Text == "")
                {
                    btnPrev2 = true;
                }
                if (k.ToString() == tbPrevBtn3.Text || tbPrevBtn3.Text == "")
                {
                    btnPrev3 = true;
                }
            }

            if (!(btnPlay1 && btnPlay2 && btnPlay3 && btnNext1 && btnNext2 && btnNext3 && btnPrev1 && btnPrev2 && btnPrev3))
            {
                MessageBox.Show("One of the fields for Mediaplayer control has an incorrect value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbMediaControl.Checked && tbPlayBtn1.Text.Trim() == "" && tbPlayBtn2.Text.Trim() == "" && tbPlayBtn3.Text.Trim() == "")
            {
                MessageBox.Show("Please enter at least one key for \"Play/Pause\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbMediaControl.Checked && tbNextBtn1.Text.Trim() == "" && tbNextBtn2.Text.Trim() == "" && tbNextBtn3.Text.Trim() == "")
            {
                MessageBox.Show("Please enter at least one key for \"Next tract\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbMediaControl.Checked && tbPlayBtn1.Text.Trim() == "" && tbPlayBtn2.Text.Trim() == "" && tbPlayBtn3.Text.Trim() == "")
            {
                MessageBox.Show("Please enter at least one key for \"Previous track\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            form.settings.HideAtStartup = cbHideAtStartup.Checked;
            form.settings.HideOnClose = cbHideOnClose.Checked;
            form.settings.MediaControlEnabled = cbMediaControl.Checked;
            form.settings.ScreenshotSaveEnabled = cbSaveScreenshots.Checked;
            form.settings.SpotifyNotificationsEnabled = cbSpotify.Checked;
            form.settings.PlayPauseButtons.Clear();
            if (tbPlayBtn1.Text.Trim() != "")
            {
                form.settings.PlayPauseButtons.Add(tbPlayBtn1.Text);
            }
            if (tbPlayBtn2.Text.Trim() != "")
            {
                form.settings.PlayPauseButtons.Add(tbPlayBtn2.Text);
            }
            if (tbPlayBtn3.Text.Trim() != "")
            {
                form.settings.PlayPauseButtons.Add(tbPlayBtn3.Text);
            }

            form.settings.NextTrackButtons.Clear();
            if (tbNextBtn1.Text.Trim() != "")
            {
                form.settings.NextTrackButtons.Add(tbNextBtn1.Text);
            }
            if (tbNextBtn2.Text.Trim() != "")
            {
                form.settings.NextTrackButtons.Add(tbNextBtn2.Text);
            }
            if (tbNextBtn3.Text.Trim() != "")
            {
                form.settings.NextTrackButtons.Add(tbNextBtn3.Text);
            }

            form.settings.PrevTrackButtons.Clear();
            if (tbPrevBtn1.Text.Trim() != "")
            {
                form.settings.PrevTrackButtons.Add(tbPrevBtn1.Text);
            }
            if (tbPrevBtn2.Text.Trim() != "")
            {
                form.settings.PrevTrackButtons.Add(tbPrevBtn2.Text);
            }
            if (tbPrevBtn3.Text.Trim() != "")
            {
                form.settings.PrevTrackButtons.Add(tbPrevBtn3.Text);
            }

            form.settings.ScreenshotSavePath = tbScreenshotSavePath.Text;

            if (cbRunAtStart.Checked)
            {
                rkApp.SetValue("CRUtils", Application.ExecutablePath.ToString());
            }
            else
            {
                rkApp.DeleteValue("CRUtils", false);
            }

            form.settings.saveSettings();
            form.Refresh();
            MessageBox.Show("Settings saved", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Media_KeyUp(object sender, KeyEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (e.KeyCode != Keys.Tab)
            {
                ctrl.Text = (e.KeyCode).ToString();
            }
            if (e.KeyCode == Keys.Escape)
            {
                ctrl.Text = "";
            }
        }

        private void btnSpotifyConnect_Click(object sender, EventArgs e)
        {
            if (form.SpotifyConnected)
            {
                btnSpotifyConnect.Text = "Connect";
                form.SpotifyDisconnect();
            }
            else
            {
                if (form.SpotifyConnect(true))
                {
                    btnSpotifyConnect.Text = "Disconnect";
                }
            }
        }
    }
}
