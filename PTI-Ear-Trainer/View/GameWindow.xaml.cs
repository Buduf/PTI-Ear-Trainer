using System;
using System.Windows;

namespace PTI_Ear_Trainer.View
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
            App.Current.Shutdown();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            switch (WindowState)
            {
                case WindowState.Normal:
                    normal.IsChecked = true;
                    maximize.IsChecked = false;
                    break;
                case WindowState.Maximized:
                    normal.IsChecked = false;
                    maximize.IsChecked = true;
                    break;
            }
        }

        private void OpenLeaderboard(object sender, RoutedEventArgs e)
        {
            Leaderboard window = new Leaderboard();
            window.Show();
        }

        private void OpenAbout(object sender, RoutedEventArgs e)
        {
            About window = new About();
            window.Show();
        }

        private void OpenHTP(object sender, RoutedEventArgs e)
        {
            Howtoplay window = new Howtoplay();
            window.Show();
        }

        private void MaximizeWindow()
        {
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            menu.Visibility = Visibility.Visible;
        }

        private void NormalizeWindow()
        {
            this.WindowState = WindowState.Normal;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            menu.Visibility = Visibility.Visible;
        }

        private void MaximizeClick(object sender, RoutedEventArgs e)
        {
            MaximizeWindow();
        }

        private void NormalClick(object sender, RoutedEventArgs e)
        {
            NormalizeWindow();
        }
    }
}
