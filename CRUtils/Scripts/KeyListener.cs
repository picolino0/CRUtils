using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace com.colinrosen.CRUtils
{
    public class KeyListener
    {
        #region EVENTS

        public event Action<Keys> OnKeyDown;
        public event Action<Keys> OnKeyUp;
        
        #endregion
        
        #region FIELDS

        private IKeyboardEvents _globalHook;

        private List<int> _keysDown;

        #endregion

        #region SETUP

        public KeyListener()
        {
            _keysDown = new List<int>();

            _globalHook = Hook.GlobalEvents();

            _globalHook.KeyDown += OnGlobalKeyDown;
            _globalHook.KeyUp += OnGlobalKeyUp;
        }

        ~KeyListener()
        {
            _globalHook.KeyDown -= OnGlobalKeyDown;
            _globalHook.KeyUp -= OnGlobalKeyUp;

            _globalHook = null;
        }

        #endregion

        #region EVENTHANDLERS

        private void OnGlobalKeyDown(object sender, KeyEventArgs e)
        {
            int key = KeyToString(e.KeyCode).ToLower().GetHashCode();
            if (_keysDown.Contains(key)) return;
            
            _keysDown.Add(key);
            
            // Call event
            if (OnKeyDown != null)
                OnKeyDown(e.KeyCode);
        }

        private void OnGlobalKeyUp(object sender, KeyEventArgs e)
        {
            int key = KeyToString(e.KeyCode).ToLower().GetHashCode();
            if (!_keysDown.Remove(key)) return;

            // Call event
            if (OnKeyUp != null)
                OnKeyUp(e.KeyCode);
        }

        #endregion

        #region PUBLIC

        public static string KeyToString(Keys key)
        {
            string keyName = key.ToString();

            // Change left/right [key] to single key
            switch (key)
            {
                case Keys.LMenu:
                case Keys.RMenu:
                    keyName = "Alt";
                    break;
                case Keys.LControlKey:
                case Keys.RControlKey:
                    keyName = "Ctrl";
                    break;
                case Keys.LShiftKey:
                case Keys.RShiftKey:
                    keyName = "Shift";
                    break;
                case Keys.LWin:
                case Keys.RWin:
                    keyName = "Win";
                    break;
            }

            return keyName.Trim();
        }

        public static Keys StringToKey(string key)
        {
            Keys k = Keys.None;

            // Change left/right [key] to single key
            switch (key.Trim().ToLower())
            {
                case "alt":
                    k = Keys.LMenu;
                    break;
                case "ctrl":
                    k = Keys.LControlKey;
                    break;
                case "shift":
                    k = Keys.LShiftKey;
                    break;
                case "win":
                    k = Keys.LWin;
                    break;
            }

            if (k == Keys.None && !Keys.TryParse(key, true, out k))
                return Keys.None;

            return k;
        }
        
        public bool AreKeysDown(params string[] keys)
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
    }
}