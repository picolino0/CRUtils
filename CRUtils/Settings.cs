using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUtils
{
    [Serializable]
    public class Settings
    {
        public bool HideAtStartup
        {
            get;
            set;
        }
        public bool FirstTimeHide
        {
            get;
            set;
        }

        public bool HideOnClose
        {
            get;
            set;
        }

        public bool MediaControlEnabled
        {
            get;
            set;
        }

        public List<String> PlayPauseButtons
        {
            get;
            private set;
        }

        public List<String> NextTrackButtons
        {
            get;
            private set;
        }

        public List<String> PrevTrackButtons
        {
            get;
            private set;
        }

        public bool ScreenshotSaveEnabled
        {
            get;
            set;
        }

        public String ScreenshotSavePath
        {
            get;
            set;
        }

        public Settings()
        {
            loadSettings();
        }

        public void saveSettings()
        {
            String path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            IFormatter formatter = new BinaryFormatter();
            using (Stream s = new FileStream(path + "\\Settings.crutil", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(s, this);
            }
        }

        public void loadSettings()
        {
            try
            {
                String path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                IFormatter formatter = new BinaryFormatter();
                using (Stream s = new FileStream(path + "\\Settings.crutil", FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    Settings set = (Settings)formatter.Deserialize(s);
                    HideAtStartup = set.HideAtStartup;
                    FirstTimeHide = set.FirstTimeHide;
                    HideOnClose = set.HideOnClose;
                    MediaControlEnabled = set.MediaControlEnabled;
                    PlayPauseButtons = set.PlayPauseButtons;
                    NextTrackButtons = set.NextTrackButtons;
                    PrevTrackButtons = set.PrevTrackButtons;
                    ScreenshotSaveEnabled = set.ScreenshotSaveEnabled;
                    ScreenshotSavePath = set.ScreenshotSavePath;
                }
            }
            catch (SerializationException)
            {
                createFile();
            }
            catch (FileNotFoundException)
            {
                createFile();
            }
        }

        private void createFile()
        {
            String path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            HideAtStartup = false;
            FirstTimeHide = true;
            HideOnClose = true;
            MediaControlEnabled = true;
            PlayPauseButtons = new List<String>() { Keys.ControlKey.ToString(), Keys.F2.ToString() };
            NextTrackButtons = new List<String>() { Keys.ControlKey.ToString(), Keys.F3.ToString() };
            PrevTrackButtons = new List<String>() { Keys.ControlKey.ToString(), Keys.F1.ToString() };
            ScreenshotSaveEnabled = true;
            ScreenshotSavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Screenshots";

            IFormatter formatter = new BinaryFormatter();
            using (Stream s = new FileStream(path + "\\Settings.crutil", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(s, this);
                s.Close();
            }
        }
    }
}
