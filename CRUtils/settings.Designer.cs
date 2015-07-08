namespace CRUtils
{
    partial class SettingsScreen
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
            this.cbHideAtStartup = new System.Windows.Forms.CheckBox();
            this.cbHideOnClose = new System.Windows.Forms.CheckBox();
            this.cbMediaControl = new System.Windows.Forms.CheckBox();
            this.gbMediaPlayerControls = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrevBtn3 = new System.Windows.Forms.TextBox();
            this.tbNextBtn3 = new System.Windows.Forms.TextBox();
            this.tbPlayBtn3 = new System.Windows.Forms.TextBox();
            this.tbPrevBtn2 = new System.Windows.Forms.TextBox();
            this.tbNextBtn2 = new System.Windows.Forms.TextBox();
            this.tbPlayBtn2 = new System.Windows.Forms.TextBox();
            this.tbPrevBtn1 = new System.Windows.Forms.TextBox();
            this.tbNextBtn1 = new System.Windows.Forms.TextBox();
            this.tbPlayBtn1 = new System.Windows.Forms.TextBox();
            this.cbSaveScreenshots = new System.Windows.Forms.CheckBox();
            this.gbSaveScreenshotSettings = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbScreenshotSavePath = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.ScreenshotFolderSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbRunAtStart = new System.Windows.Forms.CheckBox();
            this.gbMediaPlayerControls.SuspendLayout();
            this.gbSaveScreenshotSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbHideAtStartup
            // 
            this.cbHideAtStartup.AutoSize = true;
            this.cbHideAtStartup.Location = new System.Drawing.Point(15, 44);
            this.cbHideAtStartup.Name = "cbHideAtStartup";
            this.cbHideAtStartup.Size = new System.Drawing.Size(95, 17);
            this.cbHideAtStartup.TabIndex = 0;
            this.cbHideAtStartup.Text = "Hide at startup";
            this.cbHideAtStartup.UseVisualStyleBackColor = true;
            // 
            // cbHideOnClose
            // 
            this.cbHideOnClose.AutoSize = true;
            this.cbHideOnClose.Checked = true;
            this.cbHideOnClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHideOnClose.Location = new System.Drawing.Point(15, 67);
            this.cbHideOnClose.Name = "cbHideOnClose";
            this.cbHideOnClose.Size = new System.Drawing.Size(210, 17);
            this.cbHideOnClose.TabIndex = 1;
            this.cbHideOnClose.Text = "Minimize to tray when window is closed";
            this.cbHideOnClose.UseVisualStyleBackColor = true;
            // 
            // cbMediaControl
            // 
            this.cbMediaControl.AutoSize = true;
            this.cbMediaControl.Checked = true;
            this.cbMediaControl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMediaControl.Location = new System.Drawing.Point(15, 90);
            this.cbMediaControl.Name = "cbMediaControl";
            this.cbMediaControl.Size = new System.Drawing.Size(123, 17);
            this.cbMediaControl.TabIndex = 2;
            this.cbMediaControl.Text = "Control mediaplayers";
            this.cbMediaControl.UseVisualStyleBackColor = true;
            this.cbMediaControl.CheckedChanged += new System.EventHandler(this.cbMediaControl_CheckedChanged);
            // 
            // gbMediaPlayerControls
            // 
            this.gbMediaPlayerControls.Controls.Add(this.label3);
            this.gbMediaPlayerControls.Controls.Add(this.label2);
            this.gbMediaPlayerControls.Controls.Add(this.label1);
            this.gbMediaPlayerControls.Controls.Add(this.tbPrevBtn3);
            this.gbMediaPlayerControls.Controls.Add(this.tbNextBtn3);
            this.gbMediaPlayerControls.Controls.Add(this.tbPlayBtn3);
            this.gbMediaPlayerControls.Controls.Add(this.tbPrevBtn2);
            this.gbMediaPlayerControls.Controls.Add(this.tbNextBtn2);
            this.gbMediaPlayerControls.Controls.Add(this.tbPlayBtn2);
            this.gbMediaPlayerControls.Controls.Add(this.tbPrevBtn1);
            this.gbMediaPlayerControls.Controls.Add(this.tbNextBtn1);
            this.gbMediaPlayerControls.Controls.Add(this.tbPlayBtn1);
            this.gbMediaPlayerControls.Location = new System.Drawing.Point(230, 19);
            this.gbMediaPlayerControls.Name = "gbMediaPlayerControls";
            this.gbMediaPlayerControls.Size = new System.Drawing.Size(800, 125);
            this.gbMediaPlayerControls.TabIndex = 4;
            this.gbMediaPlayerControls.TabStop = false;
            this.gbMediaPlayerControls.Text = "Mediaplay control settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Previous track";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Next track";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Play/Pause";
            // 
            // tbPrevBtn3
            // 
            this.tbPrevBtn3.BackColor = System.Drawing.Color.White;
            this.tbPrevBtn3.Location = new System.Drawing.Point(224, 89);
            this.tbPrevBtn3.Name = "tbPrevBtn3";
            this.tbPrevBtn3.ReadOnly = true;
            this.tbPrevBtn3.Size = new System.Drawing.Size(57, 20);
            this.tbPrevBtn3.TabIndex = 8;
            this.tbPrevBtn3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Media_KeyUp);
            // 
            // tbNextBtn3
            // 
            this.tbNextBtn3.BackColor = System.Drawing.Color.White;
            this.tbNextBtn3.Location = new System.Drawing.Point(224, 58);
            this.tbNextBtn3.Name = "tbNextBtn3";
            this.tbNextBtn3.ReadOnly = true;
            this.tbNextBtn3.Size = new System.Drawing.Size(57, 20);
            this.tbNextBtn3.TabIndex = 5;
            this.tbNextBtn3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Media_KeyUp);
            // 
            // tbPlayBtn3
            // 
            this.tbPlayBtn3.BackColor = System.Drawing.Color.White;
            this.tbPlayBtn3.Location = new System.Drawing.Point(224, 26);
            this.tbPlayBtn3.Name = "tbPlayBtn3";
            this.tbPlayBtn3.ReadOnly = true;
            this.tbPlayBtn3.Size = new System.Drawing.Size(57, 20);
            this.tbPlayBtn3.TabIndex = 2;
            this.tbPlayBtn3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Media_KeyUp);
            // 
            // tbPrevBtn2
            // 
            this.tbPrevBtn2.BackColor = System.Drawing.Color.White;
            this.tbPrevBtn2.Location = new System.Drawing.Point(161, 89);
            this.tbPrevBtn2.Name = "tbPrevBtn2";
            this.tbPrevBtn2.ReadOnly = true;
            this.tbPrevBtn2.Size = new System.Drawing.Size(57, 20);
            this.tbPrevBtn2.TabIndex = 7;
            this.tbPrevBtn2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Media_KeyUp);
            // 
            // tbNextBtn2
            // 
            this.tbNextBtn2.BackColor = System.Drawing.Color.White;
            this.tbNextBtn2.Location = new System.Drawing.Point(161, 58);
            this.tbNextBtn2.Name = "tbNextBtn2";
            this.tbNextBtn2.ReadOnly = true;
            this.tbNextBtn2.Size = new System.Drawing.Size(57, 20);
            this.tbNextBtn2.TabIndex = 4;
            this.tbNextBtn2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Media_KeyUp);
            // 
            // tbPlayBtn2
            // 
            this.tbPlayBtn2.BackColor = System.Drawing.Color.White;
            this.tbPlayBtn2.Location = new System.Drawing.Point(161, 26);
            this.tbPlayBtn2.Name = "tbPlayBtn2";
            this.tbPlayBtn2.ReadOnly = true;
            this.tbPlayBtn2.Size = new System.Drawing.Size(57, 20);
            this.tbPlayBtn2.TabIndex = 1;
            this.tbPlayBtn2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Media_KeyUp);
            // 
            // tbPrevBtn1
            // 
            this.tbPrevBtn1.BackColor = System.Drawing.Color.White;
            this.tbPrevBtn1.Location = new System.Drawing.Point(98, 89);
            this.tbPrevBtn1.Name = "tbPrevBtn1";
            this.tbPrevBtn1.ReadOnly = true;
            this.tbPrevBtn1.Size = new System.Drawing.Size(57, 20);
            this.tbPrevBtn1.TabIndex = 6;
            this.tbPrevBtn1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Media_KeyUp);
            // 
            // tbNextBtn1
            // 
            this.tbNextBtn1.BackColor = System.Drawing.Color.White;
            this.tbNextBtn1.Location = new System.Drawing.Point(98, 58);
            this.tbNextBtn1.Name = "tbNextBtn1";
            this.tbNextBtn1.ReadOnly = true;
            this.tbNextBtn1.Size = new System.Drawing.Size(57, 20);
            this.tbNextBtn1.TabIndex = 3;
            this.tbNextBtn1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Media_KeyUp);
            // 
            // tbPlayBtn1
            // 
            this.tbPlayBtn1.BackColor = System.Drawing.Color.White;
            this.tbPlayBtn1.Location = new System.Drawing.Point(98, 26);
            this.tbPlayBtn1.Name = "tbPlayBtn1";
            this.tbPlayBtn1.ReadOnly = true;
            this.tbPlayBtn1.Size = new System.Drawing.Size(57, 20);
            this.tbPlayBtn1.TabIndex = 0;
            this.tbPlayBtn1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Media_KeyUp);
            // 
            // cbSaveScreenshots
            // 
            this.cbSaveScreenshots.AutoSize = true;
            this.cbSaveScreenshots.Checked = true;
            this.cbSaveScreenshots.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveScreenshots.Location = new System.Drawing.Point(15, 113);
            this.cbSaveScreenshots.Name = "cbSaveScreenshots";
            this.cbSaveScreenshots.Size = new System.Drawing.Size(131, 17);
            this.cbSaveScreenshots.TabIndex = 3;
            this.cbSaveScreenshots.Text = "Autosave screenshots";
            this.cbSaveScreenshots.UseVisualStyleBackColor = true;
            this.cbSaveScreenshots.CheckedChanged += new System.EventHandler(this.cbSaveScreenshots_CheckedChanged);
            // 
            // gbSaveScreenshotSettings
            // 
            this.gbSaveScreenshotSettings.Controls.Add(this.btnBrowse);
            this.gbSaveScreenshotSettings.Controls.Add(this.label6);
            this.gbSaveScreenshotSettings.Controls.Add(this.tbScreenshotSavePath);
            this.gbSaveScreenshotSettings.Location = new System.Drawing.Point(230, 150);
            this.gbSaveScreenshotSettings.Name = "gbSaveScreenshotSettings";
            this.gbSaveScreenshotSettings.Size = new System.Drawing.Size(800, 60);
            this.gbSaveScreenshotSettings.TabIndex = 5;
            this.gbSaveScreenshotSettings.TabStop = false;
            this.gbSaveScreenshotSettings.Text = "Screenshot settings";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(719, 24);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Screenshot savepath";
            // 
            // tbScreenshotSavePath
            // 
            this.tbScreenshotSavePath.BackColor = System.Drawing.Color.White;
            this.tbScreenshotSavePath.Location = new System.Drawing.Point(121, 26);
            this.tbScreenshotSavePath.Name = "tbScreenshotSavePath";
            this.tbScreenshotSavePath.ReadOnly = true;
            this.tbScreenshotSavePath.Size = new System.Drawing.Size(592, 20);
            this.tbScreenshotSavePath.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.Location = new System.Drawing.Point(915, 549);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 39);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1030, 594);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 10);
            this.panel1.TabIndex = 16;
            // 
            // cbRunAtStart
            // 
            this.cbRunAtStart.AutoSize = true;
            this.cbRunAtStart.Location = new System.Drawing.Point(15, 21);
            this.cbRunAtStart.Name = "cbRunAtStart";
            this.cbRunAtStart.Size = new System.Drawing.Size(194, 17);
            this.cbRunAtStart.TabIndex = 0;
            this.cbRunAtStart.Text = "Run CR Utilities at Windows startup";
            this.cbRunAtStart.UseVisualStyleBackColor = true;
            // 
            // SettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbSaveScreenshotSettings);
            this.Controls.Add(this.gbMediaPlayerControls);
            this.Controls.Add(this.cbSaveScreenshots);
            this.Controls.Add(this.cbMediaControl);
            this.Controls.Add(this.cbHideOnClose);
            this.Controls.Add(this.cbRunAtStart);
            this.Controls.Add(this.cbHideAtStartup);
            this.Name = "SettingsScreen";
            this.Size = new System.Drawing.Size(1040, 604);
            this.Click += new System.EventHandler(this.SettingsScreen_Click);
            this.gbMediaPlayerControls.ResumeLayout(false);
            this.gbMediaPlayerControls.PerformLayout();
            this.gbSaveScreenshotSettings.ResumeLayout(false);
            this.gbSaveScreenshotSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbHideAtStartup;
        private System.Windows.Forms.CheckBox cbHideOnClose;
        private System.Windows.Forms.CheckBox cbMediaControl;
        private System.Windows.Forms.GroupBox gbMediaPlayerControls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPlayBtn3;
        private System.Windows.Forms.TextBox tbPlayBtn2;
        private System.Windows.Forms.TextBox tbPlayBtn1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPrevBtn3;
        private System.Windows.Forms.TextBox tbNextBtn3;
        private System.Windows.Forms.TextBox tbPrevBtn2;
        private System.Windows.Forms.TextBox tbNextBtn2;
        private System.Windows.Forms.TextBox tbPrevBtn1;
        private System.Windows.Forms.TextBox tbNextBtn1;
        private System.Windows.Forms.CheckBox cbSaveScreenshots;
        private System.Windows.Forms.GroupBox gbSaveScreenshotSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbScreenshotSavePath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog ScreenshotFolderSelect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbRunAtStart;
    }
}
