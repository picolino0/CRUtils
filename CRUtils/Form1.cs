using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;

namespace CRUtils
{
    public partial class Form1 : Form
    {
        private bool moving = false, closeForReal = false, mouseEnteredToolStrip = false, startup = true, overrideAutoSpot = false;
        private Point locationFromMouse;
        private string selected = "Pictures";
        private UserActivityHook actHook;
        private List<string> keysPressed = new List<String>();
        private static Form1 form;

        public bool SpotifyConnected
        {
            get; private set;
        }
        private SpotifyLocalAPI spotify;

        public ScreenshotPreview scp
        {
            get;
            set;
        }

        public string Selected
        {
            get { return selected; }
        }

        public Settings settings
        {
            get;
            private set;
        }


        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        public Form1()
        {
            InitializeComponent();
            form = this;
            settings = new Settings();
            pnlUserControls.Controls.Add(new PicturesScreen(this));

            if (settings.SpotifyNotificationsEnabled)
            {
                SpotifyConnect(false);
            }
        }

        #region Titlebar
        private void pnlTitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            locationFromMouse = new Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);
            moving = true;
        }

        private void pnlTitlebar_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }

        private void pnlTitlebar_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                this.Location = new Point(Cursor.Position.X - locationFromMouse.X, Cursor.Position.Y - locationFromMouse.Y);
            }
        }

        private void lbClose_MouseEnter(object sender, EventArgs e)
        {
            Thread th = new Thread(new ParameterizedThreadStart(ChangeToColor));
            th.Start(new object[] { lbClose, Color.FromArgb(200, 0, 0), th, false });
            this.Cursor = Cursors.Hand;
        }

        private void lbClose_MouseLeave(object sender, EventArgs e)
        {
            Thread th = new Thread(ChangeToColor);
            th.Start(new object[] { lbClose, Color.FromArgb(64, 64, 64), th, true });
            this.Cursor = Cursors.Default;
        }

        private void lbMinimize_MouseEnter(object sender, EventArgs e)
        {
            Thread th = new Thread(new ParameterizedThreadStart(ChangeToColor));
            th.Start(new object[] { lbMinimize, Color.FromArgb(100, 100, 100), th, false });
            this.Cursor = Cursors.Hand;
        }

        private void lbMinimize_MouseLeave(object sender, EventArgs e)
        {
            Thread th = new Thread(new ParameterizedThreadStart(ChangeToColor));
            th.Start(new object[] { lbMinimize, Color.FromArgb(64, 64, 64), th, true });
            this.Cursor = Cursors.Default;
        }

        private void ChangeToColor(object arg)
        {
            object[] args = (object[])arg;
            Control ctrl = (Control)args[0];
            Color c = (Color)args[1];
            Thread th = (Thread)args[2];
            bool ignoreCursorPos = (bool)args[3];

            int r = ctrl.BackColor.R;
            int g = ctrl.BackColor.G;
            int b = ctrl.BackColor.B;
            while (r != c.R || g != c.G || b != c.B)
            {
                if (!ignoreCursorPos && (Cursor.Position.X < ctrl.Location.X + this.Location.X || Cursor.Position.X > ctrl.Location.X + this.Location.X + ctrl.Width || Cursor.Position.Y < ctrl.Location.Y + this.Location.Y || Cursor.Position.Y > ctrl.Location.Y + this.Location.Y + ctrl.Height))
                {
                    th.Abort();
                }

                if (r < c.R)
                    r = ctrl.BackColor.R + 5 > c.R ? c.R : ctrl.BackColor.R + 5;
                else
                    r = ctrl.BackColor.R - 5 < c.R ? c.R : ctrl.BackColor.R - 5;

                if (g < c.G)
                    g = ctrl.BackColor.G + 5 > c.G ? c.G : ctrl.BackColor.G + 5;
                else
                    g = ctrl.BackColor.G - 5 < c.G ? c.G : ctrl.BackColor.G - 5;

                if (b < c.B)
                    b = ctrl.BackColor.B + 5 > c.B ? c.B : ctrl.BackColor.B + 5;
                else
                    b = ctrl.BackColor.B - 5 < c.B ? c.B : ctrl.BackColor.B - 5;

                setColorLbClose(r, g, b, ctrl);
                Thread.Sleep(10);
            }
        }

        private void setColorLbClose(int r, int g, int b, Control ctrl)
        {
            lock (this)
            {
                ctrl.BackColor = Color.FromArgb(r, g, b);
            }
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void takeAScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveScreenshot();
        }

        private void takeAScreenshotToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveScreenshot();
        }
        #endregion

        #region Form
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeForReal && settings.HideOnClose)
            {
                e.Cancel = true;
                this.Hide();
                notify.Visible = true;
                if (settings.FirstTimeHide)
                {
                    notify.ShowBalloonTip(1000, "Note!", "The application window has been closed, but the application itself is still running", ToolTipIcon.Info);
                    notify.BalloonTipTitle = "Note!";
                    settings.FirstTimeHide = false;
                }
                return;
            }
            settings.saveSettings();
            UserActivityHook.UnHook();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (settings.HideAtStartup && startup)
            {
                this.Hide();
                notify.Visible = true;
                if (settings.FirstTimeHide)
                {
                    notify.ShowBalloonTip(1000, "Note!", "The application window has been closed, but the application itself is still running", ToolTipIcon.Info);
                    notify.BalloonTipTitle = "Note!";
                    settings.FirstTimeHide = false;
                }
            }
            startup = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            actHook = new UserActivityHook();
            actHook.SetHook();
        }
        #endregion

        #region Notify/Toolstrip
        public void Notify(String title, String content)
        {
            notify.Visible = true;
            notify.ShowBalloonTip(1000, title, content, ToolTipIcon.Info);
            notify.BalloonTipTitle = title;
        }

        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notify.Visible = false;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            closeForReal = true;
            this.Close();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            this.Show();
            notify.Visible = false;
        }

        private void playPauseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            playPause();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForReal = true;
            this.Close();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            notify.Visible = true;
            if (settings.FirstTimeHide)
            {
                notify.ShowBalloonTip(1000, "Note!", "The application window has been closed, but the application itself is still running", ToolTipIcon.Info);
                settings.FirstTimeHide = false;
            }
        }

        private void fileToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.Black;
        }

        private void fileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            if (!mouseEnteredToolStrip)
            {
                fileToolStripMenuItem.ForeColor = Color.White;
            }
        }

        private void fileToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.Black;
            mouseEnteredToolStrip = true;
        }

        private void fileToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (!fileToolStripMenuItem.DropDown.Visible)
            {
                fileToolStripMenuItem.ForeColor = Color.White;
            }
            mouseEnteredToolStrip = false;
        }

        private void playPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playPause();
        }

        private void nextTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nextTrack();
        }

        private void previousTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prevTrack();
        }

        private void nextTrackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nextTrack();
        }

        private void previousTrackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            prevTrack();
        }

        private void notify_BalloonTipClicked(object sender, EventArgs e)
        {
            if (notify.BalloonTipTitle == "Screenshot added")
            {
                try
                {
                    Process.Start(settings.ScreenshotSavePath);
                }
                catch (FileNotFoundException)
                {
                    //
                }
            }
        }

        private void notify_BalloonTipClosed(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                notify.Visible = false;
            }
        }
        #endregion

        #region Pictureboxes
        private void picturebox_paint(object sender, PaintEventArgs e)
        {
            if (!settings.MediaControlEnabled)
            {
                playPauseToolStripMenuItem.Enabled = false;
                nextTrackToolStripMenuItem.Enabled = false;
                previousTrackToolStripMenuItem.Enabled = false;
                playPauseToolStripMenuItem1.Enabled = false;
                nextTrackToolStripMenuItem1.Enabled = false;
                previousTrackToolStripMenuItem.Enabled = false;
            }
            else
            {
                playPauseToolStripMenuItem.Enabled = true;
                nextTrackToolStripMenuItem.Enabled = true;
                previousTrackToolStripMenuItem.Enabled = true;
                playPauseToolStripMenuItem1.Enabled = true;
                nextTrackToolStripMenuItem1.Enabled = true;
                previousTrackToolStripMenuItem.Enabled = true;
            }

            if (!settings.ScreenshotSaveEnabled)
            {
                takeAScreenshotToolStripMenuItem.Enabled = false;
                takeAScreenshotToolStripMenuItem1.Enabled = false;
            }
            else
            {
                takeAScreenshotToolStripMenuItem.Enabled = true;
                takeAScreenshotToolStripMenuItem1.Enabled = true;
            }

            Control ctrl = (Control)sender;
            if (ctrl.Name.StartsWith("pb"))
            {
                Point offset = new Point();
                if (ctrl.Name != "pb" + selected)
                {
                    offset = new Point(0, -176);
                }
                if (Cursor.Position.X >= ctrl.Location.X + this.Location.X && Cursor.Position.X <= ctrl.Location.X + this.Location.X + ctrl.Width && Cursor.Position.Y >= ctrl.Location.Y + this.Location.Y + 52 && Cursor.Position.Y <= ctrl.Location.Y + this.Location.Y + 52 + ctrl.Height)
                {
                    offset = new Point();
                }

                Image img = (Image)Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, false, true).GetObject(ctrl.Name.Substring(2).ToLower(), true);

                e.Graphics.DrawImage(img, new Rectangle(offset.X, offset.Y, 176, 352));
            }
        }

        private void picturebox_mouseenter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            Refresh();
        }

        private void picturebox_mouseleave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Refresh();
        }

        private void pbPictures_Click(object sender, EventArgs e)
        {
            setSelected("Pictures");
        }

        private void pbSettings_Click(object sender, EventArgs e)
        {
            setSelected("Settings");
        }
        #endregion

        #region GlobalWindows
        public static void GlobalWindowsKeyDown(Keys key)
        {
            if (form != null)
            {
                form.WindowsKeyDown(key);
            }
        }

        private void WindowsKeyDown(Keys key)
        {
            #region left and right keys to one
            if (key.ToString().EndsWith("ControlKey"))
            {
                key = Keys.ControlKey;
            }
            if (key.ToString().EndsWith("ShiftKey"))
            {
                key = Keys.ShiftKey;
            }
            #endregion

            if (!keysPressed.Contains(key.ToString()))
            {
                keysPressed.Add(key.ToString());
            }

            #region play/pause/previous/next keys
            if (settings.MediaControlEnabled)
            {
                int keyCombo = 0;
                foreach (String k in settings.PlayPauseButtons)
                {
                    if (keysPressed.ContainsIgnoreCase(k))
                    {
                        keyCombo++;
                    }
                }
                if (keyCombo == settings.PlayPauseButtons.Count)
                {
                    playPause();
                }

                keyCombo = 0;
                foreach (String k in settings.NextTrackButtons)
                {
                    if (keysPressed.ContainsIgnoreCase(k))
                    {
                        keyCombo++;
                    }
                }
                if (keyCombo == settings.NextTrackButtons.Count)
                {
                    nextTrack();
                }

                keyCombo = 0;
                foreach (String k in settings.PrevTrackButtons)
                {
                    if (keysPressed.ContainsIgnoreCase(k))
                    {
                        keyCombo++;
                    }
                }
                if (keyCombo == settings.PrevTrackButtons.Count)
                {
                    prevTrack();
                }
            }
            #endregion
        }

        public static void GlobalWindowsKeyUp(Keys key)
        {
            if (form != null)
            {
                form.WindowsKeyUp(key);
            }
        }

        private void WindowsKeyUp(Keys key)
        {
            #region left and right keys to one
            if (key.ToString().EndsWith("ControlKey"))
            {
                key = Keys.ControlKey;
            }
            if (key.ToString().EndsWith("ShiftKey"))
            {
                key = Keys.ShiftKey;
            }
            #endregion
            if (key == Keys.Escape && scp != null)
            {
                scp.Close();
                scp = null;
            }
            keysPressed.Remove(key.ToString());

            #region Screenshot
            if (settings.ScreenshotSaveEnabled && key == Keys.PrintScreen)
            {
                saveScreenshot();
            }
            #endregion
        }
        #endregion

        #region Mediaplayer control
        public void playPause()
        {
            int WM_APPCOMMAND = 0x319;
            int APPCOMMAND_MEDIA_PLAY_PAUSE = 0xE0000;

            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
            (IntPtr)APPCOMMAND_MEDIA_PLAY_PAUSE);
        }
        public void nextTrack()
        {
            int WM_APPCOMMAND = 0x319;
            int APPCOMMAND_MEDIA_NEXT_TRACK = 0xB0000;

            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
            (IntPtr)APPCOMMAND_MEDIA_NEXT_TRACK);
        }
        public void prevTrack()
        {
            int WM_APPCOMMAND = 0x319;
            int APPCOMMAND_MEDIA_PREV_TRACK = 0xC0000;

            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
            (IntPtr)APPCOMMAND_MEDIA_PREV_TRACK);
        }
        #endregion

        #region Spotify Control
        public void Spotify_OnTrackChange(TrackChangeEventArgs ev)
        {
            this.Notify("Now Playing", ev.NewTrack.TrackResource.Name + " by " + ev.NewTrack.ArtistResource.Name);
        }

        public void Spotify_OnPlayStateChange(PlayStateEventArgs ev)
        {
            if (ev.Playing)
            {
                Track track = spotify.GetStatus().Track;
                this.Notify("Now Playing", track.TrackResource.Name + " by " + track.ArtistResource.Name);
            }
        }

        public bool SpotifyConnect(bool prompt)
        {
            if (prompt)
            {
                overrideAutoSpot = true;
            }

            spotify = new SpotifyLocalAPI();
            spotify.OnTrackChange += Spotify_OnTrackChange;
            spotify.OnPlayStateChange += Spotify_OnPlayStateChange;
            spotify.ListenForEvents = true;

            if (!SpotifyLocalAPI.IsSpotifyRunning())
            {
                if (prompt)
                {
                    MessageBox.Show(@"Spotify isn't running!");
                }
                else
                {
                    new Thread(delegate ()
                    {
                        Thread.Sleep(10000);
                        if (!overrideAutoSpot)
                        {
                            this.Invoke(new Action(() => SpotifyConnect(false)));
                        }
                    }).Start();
                }
                return false;
            }
            if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
            {
                if (prompt)
                {
                    MessageBox.Show(@"SpotifyWebHelper isn't running!");
                }
                return false;
            }

            bool successful = spotify.Connect();
            if (!successful)
            {
                // Reset connection first
                SpotifyDisconnect();

                if (prompt)
                {
                    DialogResult res = MessageBox.Show(@"Couldn't connect to the spotify client. Retry?", @"Spotify", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                        SpotifyConnect(true);
                }
            }

            SpotifyConnected = successful;
            return successful;
        }

        public void SpotifyDisconnect()
        {
            spotify.OnTrackChange -= Spotify_OnTrackChange;
            spotify.OnPlayStateChange -= Spotify_OnPlayStateChange;
            spotify = null;
            SpotifyConnected = false;
            overrideAutoSpot = true;
        }
        #endregion

        public void saveScreenshot()
        {
            if (scp != null)
            {
                scp.Close();
                scp = null;
            }
            scp = new ScreenshotPreview(this);
            scp.Show();
        }

        public void setSelected(String screen)
        {
            if (screen.ToLower().Equals("pictures"))
            {
                selected = "Pictures";
                pnlUserControls.Controls.Clear();
                pnlUserControls.Controls.Add(new PicturesScreen(this));
            }
            if (screen.ToLower().Equals("settings"))
            {
                selected = "Settings";
                pnlUserControls.Controls.Clear();
                pnlUserControls.Controls.Add(new SettingsScreen(this));
            }
            Refresh();
        }
    }
}
