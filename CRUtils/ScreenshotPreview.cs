using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUtils
{
    public partial class ScreenshotPreview : Form
    {
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmGetColorizationColor(out uint ColorizationColor, [MarshalAs(UnmanagedType.Bool)]out bool ColorizationOpaqueBlend);

        private Form1 form;
        private List<PictureBox> pictureboxes = new List<PictureBox>();

        public ScreenshotPreview()
        {
            this.form = Form1.form;
            InitializeComponent();
            InitializeAdditionalComponent();
        }

        private Color UIntToColor(uint color)
        {
            byte a = (byte)(color >> 24);
            byte r = (byte)(color >> 16);
            byte g = (byte)(color >> 8);
            byte b = (byte)(color >> 0);
            return Color.FromArgb(a, r, g, b);
        }

        private void InitializeAdditionalComponent()
        {
            uint color = 0x00000000;
            bool opaque = false;
            DwmGetColorizationColor(out color, out opaque);
            Color c = UIntToColor(color);
            c = Color.FromArgb(255, c);
            this.BackColor = c;

            this.Width = 20 + Screen.AllScreens.Length * 205;

            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                PictureBox pb = new PictureBox();
                //pb.ImageLocation = ;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.BackColor = Color.Black;
                pb.Width = 185;
                pb.Height = 185;
                pb.Location = new Point(20 + i * 205, 20);
                pb.Click += PictureBox_Click;
                Controls.Add(pb);
                pictureboxes.Add(pb);
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Save image
            String scName = "SC" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".png";
            Directory.CreateDirectory(form.settings.ScreenshotSavePath);
            ((PictureBox)sender).Image.Save(form.settings.ScreenshotSavePath + "\\" + scName, ImageFormat.Png);
            form.Notify("Screenshot added", "Screenshot saved as " + scName);
            form.setSelected("Pictures");
            form.scp = null;
            this.Close();
        }

        public void getScreenshots()
        {
            List<Image> screenshots = new List<Image>();
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                Screen screen = Screen.AllScreens[i];
                using (Bitmap bmpScreenCapture = new Bitmap(screen.Bounds.Width,
                                                screen.Bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                    {
                        g.CopyFromScreen(screen.Bounds.X,
                                         screen.Bounds.Y,
                                         0, 0,
                                         bmpScreenCapture.Size,
                                         CopyPixelOperation.SourceCopy);
                    }
                    screenshots.Add((Image)bmpScreenCapture.Clone());
                }
            }

            for (int i = 0; i < pictureboxes.Count; i++)
            {
                pictureboxes[i].Image = screenshots[i];
            }
        }

        private void ScreenshotPreview_Load(object sender, EventArgs e)
        {
            getScreenshots();
        }

        private void ScreenshotPreview_Deactivate(object sender, EventArgs e)
        {
            form.scp = null;
            this.Close();
        }
    }
}
