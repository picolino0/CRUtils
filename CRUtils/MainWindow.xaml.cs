using System.Windows;
using HamburgerMenu;

namespace MediaKeys
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HamburgerMenu_Change(object sender, RoutedEventArgs routedEventArgs)
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
    }
}