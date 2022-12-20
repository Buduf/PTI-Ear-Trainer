using System;
using System.Windows;
using PTI_Ear_Trainer.View;
using PTI_Ear_Trainer_Model;

namespace PTI_Ear_Trainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public GameDifficulty GetSelectedDifficulty()
        {
            if (easy.IsChecked.GetValueOrDefault())
                return GameDifficulty.EASY;
            else if (medium.IsChecked.GetValueOrDefault())
                return GameDifficulty.MEDIUM;
            else if (hard.IsChecked.GetValueOrDefault())
                return GameDifficulty.HARD;
            return GameDifficulty.EASY;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
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

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}
