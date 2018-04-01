using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace com.colinrosen.CRUtils
{
    public class VirtualKeyManager
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        #region FIELDS

        private const int KEYEVENTF_EXTENDEDKEY = 0x0001; // Key down flag
        private const int KEYEVENTF_KEYUP = 0x0002; // Key up flag

        private MainWindow _window;

        private bool _ignoreNextKey;

        #endregion

        #region PROPERTIES

        public const byte VK_MEDIA_PLAY_PAUSE = 0xB3; // Play/Pause keycode
        public const byte VK_MEDIA_NEXT_TRACK = 0xB0; // Play/Pause keycode
        public const byte VK_MEDIA_PREVIOUS_TRACK = 0xB1; // Play/Pause keycode

        #endregion

        #region SETUP

        public VirtualKeyManager(MainWindow window)
        {
            _window = window;
            _window.KeyListener.OnKeyDown += KeyDown;
        }

        ~VirtualKeyManager()
        {
            _window.KeyListener.OnKeyDown -= KeyDown;
        }

        #endregion

        #region PUBLIC

        public void SimulateKeyPress(byte keycode)
        {
            keybd_event(keycode, 0, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(keycode, 0, KEYEVENTF_KEYUP, 0);
        }

        public void KeyDown(Keys key)
        {
            if (!_window.Settings.EnableMediaKeys) return;
            
            if (_ignoreNextKey)
            {
                _ignoreNextKey = false;
                return;
            }

            if (_window.KeyListener.AreKeysDown(_window.Settings.PlayPauseKeys))
            {
                _ignoreNextKey = true;
                SimulateKeyPress(VK_MEDIA_PLAY_PAUSE);
            }

            if (_window.KeyListener.AreKeysDown(_window.Settings.NextKeys))
            {
                _ignoreNextKey = true;
                SimulateKeyPress(VK_MEDIA_NEXT_TRACK);
            }

            if (_window.KeyListener.AreKeysDown(_window.Settings.PrevKeys))
            {
                _ignoreNextKey = true;
                SimulateKeyPress(VK_MEDIA_PREVIOUS_TRACK);
            }
        }

        #endregion
    }
}