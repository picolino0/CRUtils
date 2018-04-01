using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace com.colinrosen.CRUtils
{
    public class KeyListener0
    {
        #region EVENTS

        public static event Action<Key> OnKeyDown;
        public static event Action<Key> OnKeyUp;

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance,
            uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        #endregion

        #region FIELDS

        private static KeyListener0 _instance;

        private static List<int> _keysDown;

        private static LowLevelKeyboardProc _proc = OnGlobalKeyPress;
        private static IntPtr hhook = IntPtr.Zero;

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;

        #endregion

        #region PROPERTIES

        public static KeyListener0 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KeyListener0();
                return _instance;
            }
        }

        #endregion

        #region SETUP

        private KeyListener0()
        {
            _keysDown = new List<int>();
            SetHook();
        }

        ~KeyListener0()
        {
            UnHook();
        }

        public static void Init()
        {
            var inst = Instance;
        }

        public void Dispose()
        {
            _instance = null;
        }

        #endregion

        #region EVENTHANDLERS

        private static void KeyDown(Key key)
        {
            string keyName = KeyToString(key);

            if (_keysDown.Contains(keyName.GetHashCode()))
                return;

            _keysDown.Add(keyName.GetHashCode());
            
            if (OnKeyDown != null)
                OnKeyDown(key);
        }

        private static void KeyUp(Key key)
        {
            string keyName = KeyToString(key);
            _keysDown.Remove(keyName.GetHashCode());
            
            if (OnKeyUp != null)
                OnKeyUp(key);
        }

        private static IntPtr OnGlobalKeyPress(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code < 0) return CallNextHookEx(hhook, code, (int) wParam, lParam);

            int vkCode = Marshal.ReadInt32(lParam);
            Key key = KeyInterop.KeyFromVirtualKey(vkCode);

            if (wParam == (IntPtr) WM_KEYDOWN)
                KeyDown(key);
            else if (wParam == (IntPtr) WM_KEYUP)
                KeyUp(key);

            return IntPtr.Zero;
        }

        #endregion

        #region PUBLIC

        public static string KeyToString(Key key)
        {
            string keyName = key.ToString();

            // Change left/right [key] to single key
            switch (key)
            {
                case Key.LeftAlt:
                case Key.RightAlt:
                    keyName = "Alt";
                    break;
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    keyName = "Ctrl";
                    break;
                case Key.LeftShift:
                case Key.RightShift:
                    keyName = "Shift";
                    break;
                case Key.LWin:
                case Key.RWin:
                    keyName = "Win";
                    break;
            }

            return keyName.Trim().ToLower();
        }

        public static Key StringToKey(string key)
        {
            Key k = Key.None;

            // Change left/right [key] to single key
            switch (key.ToLower())
            {
                case "alt":
                    k = Key.LeftAlt;
                    break;
                case "ctrl":
                    k = Key.LeftCtrl;
                    break;
                case "shift":
                    k = Key.LeftShift;
                    break;
                case "win":
                    k = Key.LWin;
                    break;
            }

            if (k == Key.None && !Key.TryParse(key, true, out k))
                return Key.None;
            return k;
        }

        public static bool AreKeysDown(params string[] keys)
        {
            int matches = 0;

            foreach (string key in keys)
            {
                if (_keysDown.Contains(key.Trim().ToLower().GetHashCode()))
                    matches++;

                if (matches >= keys.Length)
                    return true;
            }

            return false;
        }

        #endregion

        #region PRIVATE

        private static void SetHook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }

        private static void UnHook()
        {
            UnhookWindowsHookEx(hhook);
        }

        #endregion
    }
}