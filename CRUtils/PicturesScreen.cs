using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CRUtils
{
    public partial class PicturesScreen : UserControl
    {
        private Form1 form;

        public PicturesScreen(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            try
            {
                String[] files = Directory.GetFiles(form.settings.ScreenshotSavePath, "*.png");
                if (files.Length > 0)
                {
                    Controls.Clear();
                }

                for (int i = 1; i <= files.Length; i++)
                {
                    String st = files[files.Length - i];
                    int col = (i - 1) % 5;
                    int row = (i - 1) / 5;

                    PictureBox pb = new PictureBox();
                    pb.ImageLocation = st;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.BackColor = Color.Black;
                    pb.Width = 185;
                    pb.Height = 185;
                    pb.Location = new Point(43 + col * 191, 30 + row * 191);
                    pb.MouseEnter += PictureBox_MouseEnter;
                    pb.MouseLeave += PictureBox_MouseLeave;
                    pb.Click += PictureBox_Click;
                    Controls.Add(pb);
                }
            }
            catch (DirectoryNotFoundException)
            {
                //
            }

            PictureBox pbFolder = new PictureBox();
            pbFolder.Image = Properties.Resources.folder;
            pbFolder.SizeMode = PictureBoxSizeMode.Zoom;
            pbFolder.Width = 20;
            pbFolder.Height = 20;
            pbFolder.Location = new Point(5, 5);
            pbFolder.MouseEnter += PictureBox_MouseEnter;
            pbFolder.MouseLeave += PictureBox_MouseLeave;
            pbFolder.Click += openScreenshotFolder_Click;
            Controls.Add(pbFolder);

            Label lb = new Label();
            lb.Text = "Open screenshot folder";
            lb.Location = new Point(30, 5);
            lb.Width = 120;
            lb.ForeColor = Color.Blue;
            lb.Font = new Font(Font, FontStyle.Underline);
            lb.MouseEnter += PictureBox_MouseEnter;
            lb.MouseLeave += PictureBox_MouseLeave;
            lb.Click += openScreenshotFolder_Click;
            Controls.Add(lb);
        }

        private void openScreenshotFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(form.settings.ScreenshotSavePath);
            }
            catch (FileNotFoundException)
            {
                Directory.CreateDirectory(form.settings.ScreenshotSavePath);
                Process.Start(form.settings.ScreenshotSavePath);
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(((PictureBox)sender).ImageLocation);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Could not find image(?)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
    }
}
