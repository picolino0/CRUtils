using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using com.colinrosen.CRUtils.Scripts;
using HamburgerMenu;

namespace com.colinrosen.CRUtils
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region FIELDS

        private KeyListener _keyListener;

        #endregion

        #region SETUP

        public MainWindow()
        {
            // Check if debug console should be shown
            string[] args = Environment.GetCommandLineArgs();
            bool debug = false;
            foreach (string arg in args)
                if (arg.Trim().ToLower().GetHashCode() == "--debug".GetHashCode())
                {
                    debug = true;
                    break;
                }

            // Show console if debug mode
            if (debug)
                ConsoleManager.Show();

            // Load wpf components
            InitializeComponent();

            // Initialize keylistener
            _keyListener = new KeyListener();
            KeyDown += _keyListener.OnKeyDown;
            KeyUp += _keyListener.OnKeyUp;
        }

        #endregion

        #region EVENTS

        private void HamburgerMenu_Change(object sender, RoutedEventArgs ev)
        {
            HamburgerMenuItem item = sender as HamburgerMenuItem;
            if (item == null) return;

            MediaPanel.Visibility = Visibility.Collapsed;
            ScreenshotPanel.Visibility = Visibility.Collapsed;
            SettingsPanel.Visibility = Visibility.Collapsed;

            switch (item.TabIndex)
            {
                case 0:
                    MediaPanel.Visibility = Visibility.Visible;
                    break;
                case 1:
                    ScreenshotPanel.Visibility = Visibility.Visible;
                    break;
                case 2:
                    SettingsPanel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void MediaKeyInput_KeyUp(object sender, KeyEventArgs ev)
        {
            if (!(sender is TextBox textBox) || ev.Key == Key.Tab) return;

            if (ev.Key == Key.Escape)
                textBox.Text = "";
            else
                textBox.Text = _keyListener.KeyToString(ev.Key);
        }

        #endregion
    }
}