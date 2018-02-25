using System.Collections.Generic;
using System.Windows.Input;

namespace com.colinrosen.CRUtils.Scripts
{
    public class KeyListener
    {
        #region FIELDS

        private List<int> keysDown;

        #endregion

        #region SETUP

        public KeyListener()
        {
            keysDown = new List<int>();
        }

        #endregion

        #region PUBLIC

        public string KeyToString(Key key)
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

            return keyName;
        }

        public void OnKeyDown(object sender, KeyEventArgs ev)
        {
            string keyName = KeyToString(ev.Key);

            if (keysDown.Contains(keyName.GetHashCode()))
                return;

            keysDown.Add(keyName.GetHashCode());
        }

        public void OnKeyUp(object sender, KeyEventArgs ev)
        {
            string keyName = KeyToString(ev.Key);
            keysDown.Remove(keyName.GetHashCode());
        }

        public bool AreKeysDown(params string[] keys)
        {
            int matches = 0;
            foreach (string key in keys)
            {
                if (keysDown.Contains(key.Trim().ToLower().GetHashCode()))
                    matches++;

                if (matches >= keys.Length)
                    return true;
            }

            return false;
        }

        #endregion
    }
}