using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;

namespace com.colinrosen.CRUtils
{
    [Serializable]
    public class ApplicationSettings
    {
        #region FIELDS

        private readonly string _settingsPath =
            Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\settings.conf";

        #endregion

        #region PROPERTIES

        public bool EnableMediaKeys { get; set; }
        public bool EnableScreenshots { get; set; }

        public string ScreenshotFolder { get; set; }
        public string[] PlayPauseKeys { get; set; }
        public string[] PrevKeys { get; set; }
        public string[] NextKeys { get; set; }

        public bool RunAtStartup
        {
            get
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                return rk.GetValue("CRUtils") != null;
            }
            set
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (value)
                    rk.SetValue("CRUtils", Assembly.GetExecutingAssembly().Location);
                else
                    rk.DeleteValue("CRUtils", false);
            }
        }

        public bool HideAtStartup { get; set; }
        public bool MinimizeToTray { get; set; }

        #endregion

        #region SETUP

        public ApplicationSettings()
        {
            CreateFile();
        }

        #endregion

        #region PUBLIC

        public void Load()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream s = new FileStream(_settingsPath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    ApplicationSettings set = (ApplicationSettings) formatter.Deserialize(s);
                    EnableMediaKeys = set.EnableMediaKeys;
                    EnableScreenshots = set.EnableScreenshots;

                    ScreenshotFolder = set.ScreenshotFolder;
                    PlayPauseKeys = set.PlayPauseKeys;
                    PrevKeys = set.PrevKeys;
                    NextKeys = set.NextKeys;

                    RunAtStartup = set.RunAtStartup;
                    HideAtStartup = set.HideAtStartup;
                    MinimizeToTray = set.MinimizeToTray;
                }
            }
            catch (SerializationException)
            {
                CreateFile();
            }
            catch (FileNotFoundException)
            {
                CreateFile();
            }
        }

        public void Save()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream s = new FileStream(_settingsPath, FileMode.Create, FileAccess.Write, FileShare.None))
                formatter.Serialize(s, this);
        }

        #endregion

        #region PRIVATE

        private void CreateFile()
        {
            if (File.Exists(_settingsPath))
                return;

            #region Reset variables

            EnableMediaKeys = true;
            EnableScreenshots = true;

            ScreenshotFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Screenshots";
            PlayPauseKeys = new[] {"Shift", "Pause"};
            PrevKeys = new[] {"Ctrl", "F1"};
            NextKeys = new[] {"Ctrl", "F2"};

            RunAtStartup = false;
            HideAtStartup = false;
            MinimizeToTray = true;

            #endregion

            IFormatter formatter = new BinaryFormatter();
            using (Stream s = new FileStream(_settingsPath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None))
            {
                formatter.Serialize(s, this);
                s.Close();
            }
        }

        #endregion
    }
}