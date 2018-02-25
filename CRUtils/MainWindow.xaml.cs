using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private ApplicationSettings _settings;

        #endregion

        #region SETUP

        public MainWindow()
        {
            if (CheckProcess())
            {
                Application.Current.Shutdown();
                return;
            }

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

            // Initialize settings
            _settings = new ApplicationSettings();
            _settings.Load();

            ApplySettingsToUI();
        }

        #endregion

        #region PRIVATE

        private bool CheckProcess()
        {
            foreach (Process clsProcess in Process.GetProcesses())
                if (clsProcess.ProcessName.Contains("CRUtils") && clsProcess.Id != Process.GetCurrentProcess().Id)
                {
                    MessageBox.Show("An instance of CRUtils is already running");
                    return true;
                }

            return false;
        }

        private void ApplySettingsToUI()
        {
            MediaEnable.IsChecked = _settings.EnableMediaKeys;
            ScreenshotEnable.IsChecked = _settings.EnableScreenshots;

            ScreenshotFolder.Text = _settings.ScreenshotFolder;
            if (_settings.PlayPauseKeys.Length > 0)
                playpauseKey0.Text = _settings.PlayPauseKeys[0];
            if (_settings.PlayPauseKeys.Length > 1)
                playpauseKey1.Text = _settings.PlayPauseKeys[1];
            if (_settings.PlayPauseKeys.Length > 2)
                playpauseKey2.Text = _settings.PlayPauseKeys[2];

            if (_settings.PrevKeys.Length > 0)
                prevKey0.Text = _settings.PrevKeys[0];
            if (_settings.PrevKeys.Length > 1)
                prevKey1.Text = _settings.PrevKeys[1];
            if (_settings.PrevKeys.Length > 2)
                prevKey2.Text = _settings.PrevKeys[2];

            if (_settings.NextKeys.Length > 0)
                nextKey0.Text = _settings.NextKeys[0];
            if (_settings.NextKeys.Length > 1)
                nextKey1.Text = _settings.NextKeys[1];
            if (_settings.NextKeys.Length > 2)
                nextKey2.Text = _settings.NextKeys[2];

            RunAtStartup.IsChecked = _settings.RunAtStartup;
            HideAtStartup.IsChecked = _settings.HideAtStartup;
            HideToTray.IsChecked = _settings.MinimizeToTray;
        }

        private void ApplyUIToSettings()
        {
            _settings.EnableMediaKeys = MediaEnable.IsChecked.Value;
            _settings.EnableScreenshots = ScreenshotEnable.IsChecked.Value;

            List<string> playpauseKeys = new List<string>();
            if (playpauseKey0.Text.Trim().GetHashCode() != "".GetHashCode())
                playpauseKeys.Add(playpauseKey0.Text.Trim());
            if (playpauseKey1.Text.Trim().GetHashCode() != "".GetHashCode())
                playpauseKeys.Add(playpauseKey1.Text.Trim());
            if (playpauseKey2.Text.Trim().GetHashCode() != "".GetHashCode())
                playpauseKeys.Add(playpauseKey2.Text.Trim());
            _settings.PlayPauseKeys = playpauseKeys.ToArray();

            List<string> prevKeys = new List<string>();
            if (prevKey0.Text.Trim().GetHashCode() != "".GetHashCode())
                prevKeys.Add(prevKey0.Text.Trim());
            if (prevKey1.Text.Trim().GetHashCode() != "".GetHashCode())
                prevKeys.Add(prevKey1.Text.Trim());
            if (prevKey2.Text.Trim().GetHashCode() != "".GetHashCode())
                prevKeys.Add(prevKey2.Text.Trim());
            _settings.PrevKeys = prevKeys.ToArray();

            List<string> nextKeys = new List<string>();
            if (nextKey0.Text.Trim().GetHashCode() != "".GetHashCode())
                nextKeys.Add(nextKey0.Text.Trim());
            if (nextKey1.Text.Trim().GetHashCode() != "".GetHashCode())
                nextKeys.Add(nextKey1.Text.Trim());
            if (nextKey2.Text.Trim().GetHashCode() != "".GetHashCode())
                nextKeys.Add(nextKey2.Text.Trim());
            _settings.NextKeys = nextKeys.ToArray();

            _settings.ScreenshotFolder = ScreenshotFolder.Text;

            _settings.RunAtStartup = RunAtStartup.IsChecked.Value;
            _settings.HideAtStartup = HideAtStartup.IsChecked.Value;
            _settings.MinimizeToTray = HideToTray.IsChecked.Value;
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

        private void SaveBtn_Click(object sender, RoutedEventArgs ev)
        {
            ApplyUIToSettings();

            _settings.Save();
            MessageBox.Show("Saved settings", "Saved!");
        }

        #endregion
    }
}