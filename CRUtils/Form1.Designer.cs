namespace CRUtils
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlScreen = new System.Windows.Forms.Panel();
            this.pnlUserControls = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbSettings = new System.Windows.Forms.PictureBox();
            this.pbPictures = new System.Windows.Forms.PictureBox();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeAScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTitlebar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbMinimize = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.playPauseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.takeAScreenshotToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nextTrackToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.previousTrackToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlScreen.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPictures)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.pnlTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScreen
            // 
            this.pnlScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlScreen.Controls.Add(this.pnlUserControls);
            this.pnlScreen.Controls.Add(this.panel1);
            this.pnlScreen.Controls.Add(this.mainMenuStrip);
            this.pnlScreen.Location = new System.Drawing.Point(0, 28);
            this.pnlScreen.Name = "pnlScreen";
            this.pnlScreen.Size = new System.Drawing.Size(1252, 636);
            this.pnlScreen.TabIndex = 0;
            // 
            // pnlUserControls
            // 
            this.pnlUserControls.Location = new System.Drawing.Point(207, 27);
            this.pnlUserControls.Name = "pnlUserControls";
            this.pnlUserControls.Size = new System.Drawing.Size(1040, 604);
            this.pnlUserControls.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.pbSettings);
            this.panel1.Controls.Add(this.pbPictures);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 606);
            this.panel1.TabIndex = 0;
            // 
            // pbSettings
            // 
            this.pbSettings.Location = new System.Drawing.Point(24, 194);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pbSettings.Size = new System.Drawing.Size(176, 176);
            this.pbSettings.TabIndex = 0;
            this.pbSettings.TabStop = false;
            this.pbSettings.Click += new System.EventHandler(this.pbSettings_Click);
            this.pbSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.picturebox_paint);
            this.pbSettings.MouseEnter += new System.EventHandler(this.picturebox_mouseenter);
            this.pbSettings.MouseLeave += new System.EventHandler(this.picturebox_mouseleave);
            // 
            // pbPictures
            // 
            this.pbPictures.Location = new System.Drawing.Point(24, 12);
            this.pbPictures.Name = "pbPictures";
            this.pbPictures.Size = new System.Drawing.Size(176, 176);
            this.pbPictures.TabIndex = 0;
            this.pbPictures.TabStop = false;
            this.pbPictures.Click += new System.EventHandler(this.pbPictures_Click);
            this.pbPictures.Paint += new System.Windows.Forms.PaintEventHandler(this.picturebox_paint);
            this.pbPictures.MouseEnter += new System.EventHandler(this.picturebox_mouseenter);
            this.pbPictures.MouseLeave += new System.EventHandler(this.picturebox_mouseleave);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackgroundImage = global::CRUtils.Properties.Resources.menuBack;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1250, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem,
            this.playPauseToolStripMenuItem,
            this.nextTrackToolStripMenuItem,
            this.previousTrackToolStripMenuItem,
            this.takeAScreenshotToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownClosed += new System.EventHandler(this.fileToolStripMenuItem_DropDownClosed);
            this.fileToolStripMenuItem.DropDownOpened += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpened);
            this.fileToolStripMenuItem.MouseEnter += new System.EventHandler(this.fileToolStripMenuItem_MouseEnter);
            this.fileToolStripMenuItem.MouseLeave += new System.EventHandler(this.fileToolStripMenuItem_MouseLeave);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // playPauseToolStripMenuItem
            // 
            this.playPauseToolStripMenuItem.Name = "playPauseToolStripMenuItem";
            this.playPauseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.playPauseToolStripMenuItem.Text = "Play/Pause";
            this.playPauseToolStripMenuItem.Click += new System.EventHandler(this.playPauseToolStripMenuItem_Click);
            // 
            // nextTrackToolStripMenuItem
            // 
            this.nextTrackToolStripMenuItem.Name = "nextTrackToolStripMenuItem";
            this.nextTrackToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.nextTrackToolStripMenuItem.Text = "Next track";
            this.nextTrackToolStripMenuItem.Click += new System.EventHandler(this.nextTrackToolStripMenuItem_Click);
            // 
            // previousTrackToolStripMenuItem
            // 
            this.previousTrackToolStripMenuItem.Name = "previousTrackToolStripMenuItem";
            this.previousTrackToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.previousTrackToolStripMenuItem.Text = "Previous track";
            this.previousTrackToolStripMenuItem.Click += new System.EventHandler(this.previousTrackToolStripMenuItem_Click);
            // 
            // takeAScreenshotToolStripMenuItem
            // 
            this.takeAScreenshotToolStripMenuItem.Name = "takeAScreenshotToolStripMenuItem";
            this.takeAScreenshotToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.takeAScreenshotToolStripMenuItem.Text = "Take a screenshot";
            this.takeAScreenshotToolStripMenuItem.Click += new System.EventHandler(this.takeAScreenshotToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pnlTitlebar
            // 
            this.pnlTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlTitlebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitlebar.Controls.Add(this.pictureBox1);
            this.pnlTitlebar.Controls.Add(this.lbMinimize);
            this.pnlTitlebar.Controls.Add(this.lbClose);
            this.pnlTitlebar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitlebar.Name = "pnlTitlebar";
            this.pnlTitlebar.Size = new System.Drawing.Size(1252, 30);
            this.pnlTitlebar.TabIndex = 1;
            this.pnlTitlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseDown);
            this.pnlTitlebar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseMove);
            this.pnlTitlebar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Image = global::CRUtils.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbMinimize
            // 
            this.lbMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbMinimize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinimize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbMinimize.Location = new System.Drawing.Point(1123, -1);
            this.lbMinimize.Name = "lbMinimize";
            this.lbMinimize.Size = new System.Drawing.Size(50, 20);
            this.lbMinimize.TabIndex = 0;
            this.lbMinimize.Text = "_";
            this.lbMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMinimize.Click += new System.EventHandler(this.lbMinimize_Click);
            this.lbMinimize.MouseEnter += new System.EventHandler(this.lbMinimize_MouseEnter);
            this.lbMinimize.MouseLeave += new System.EventHandler(this.lbMinimize_MouseLeave);
            // 
            // lbClose
            // 
            this.lbClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbClose.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbClose.Location = new System.Drawing.Point(1172, -1);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(50, 20);
            this.lbClose.TabIndex = 0;
            this.lbClose.Text = "X";
            this.lbClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            this.lbClose.MouseEnter += new System.EventHandler(this.lbClose_MouseEnter);
            this.lbClose.MouseLeave += new System.EventHandler(this.lbClose_MouseLeave);
            // 
            // notify
            // 
            this.notify.ContextMenuStrip = this.notifyMenu;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "CR Utilities";
            this.notify.BalloonTipClicked += new System.EventHandler(this.notify_BalloonTipClicked);
            this.notify.BalloonTipClosed += new System.EventHandler(this.notify_BalloonTipClosed);
            this.notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notify_MouseDoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.playPauseToolStripMenuItem1,
            this.nextTrackToolStripMenuItem1,
            this.previousTrackToolStripMenuItem1,
            this.takeAScreenshotToolStripMenuItem1,
            this.tsmiExit});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(169, 158);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(168, 22);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // playPauseToolStripMenuItem1
            // 
            this.playPauseToolStripMenuItem1.Name = "playPauseToolStripMenuItem1";
            this.playPauseToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.playPauseToolStripMenuItem1.Text = "Play/Pause";
            this.playPauseToolStripMenuItem1.Click += new System.EventHandler(this.playPauseToolStripMenuItem1_Click);
            // 
            // takeAScreenshotToolStripMenuItem1
            // 
            this.takeAScreenshotToolStripMenuItem1.Name = "takeAScreenshotToolStripMenuItem1";
            this.takeAScreenshotToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.takeAScreenshotToolStripMenuItem1.Text = "Take a screenshot";
            this.takeAScreenshotToolStripMenuItem1.Click += new System.EventHandler(this.takeAScreenshotToolStripMenuItem1_Click);
            // 
            // nextTrackToolStripMenuItem1
            // 
            this.nextTrackToolStripMenuItem1.Name = "nextTrackToolStripMenuItem1";
            this.nextTrackToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.nextTrackToolStripMenuItem1.Text = "Next track";
            this.nextTrackToolStripMenuItem1.Click += new System.EventHandler(this.nextTrackToolStripMenuItem1_Click);
            // 
            // previousTrackToolStripMenuItem1
            // 
            this.previousTrackToolStripMenuItem1.Name = "previousTrackToolStripMenuItem1";
            this.previousTrackToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.previousTrackToolStripMenuItem1.Text = "Previous track";
            this.previousTrackToolStripMenuItem1.Click += new System.EventHandler(this.previousTrackToolStripMenuItem1_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(168, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1252, 664);
            this.Controls.Add(this.pnlTitlebar);
            this.Controls.Add(this.pnlScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "Form1";
            this.Text = "CR Utilities";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.pnlScreen.ResumeLayout(false);
            this.pnlScreen.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPictures)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.pnlTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlScreen;
        private System.Windows.Forms.Panel pnlTitlebar;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Label lbMinimize;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeAScreenshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playPauseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem takeAScreenshotToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbPictures;
        private System.Windows.Forms.PictureBox pbSettings;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlUserControls;
        private System.Windows.Forms.ToolStripMenuItem nextTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextTrackToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem previousTrackToolStripMenuItem1;

    }
}

