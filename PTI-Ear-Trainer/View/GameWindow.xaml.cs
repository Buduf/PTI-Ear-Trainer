using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PTI_Ear_Trainer.View
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        string name;
        string difficulty;
        string gamemode;
        public GameWindow(string name, string difficulty, string gamemode, int totalGuessNumber = 10)
        {
            InitializeComponent();
            this.name = name;
            this.difficulty = difficulty;
            this.gamemode = gamemode;
            Title = "PTI Ear Trainer | " + difficulty + " - " + gamemode;
            LabelGuessNumber.Content = "1/" + totalGuessNumber;
        }

        private void ButtonInterval_Click(object sender, RoutedEventArgs e)
        {
            Button? buttonInterval = sender as Button;
            switch (buttonInterval?.Content.ToString())
            {
                case null:
                    throw new ArgumentNullException();
            }
        }
        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            ButtonPlay.IsEnabled = false;
            ButtonPlay.Foreground = Brushes.Gray;
        }
        private void NewGame(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to start a new game?", "New game", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Hide();
                GameWindow window = new GameWindow(name, difficulty, gamemode, 10);
                window.Show();
            }
        }
        private void ExitCurrentGame(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Hide();
                MainWindow window = new MainWindow();
                window.Show();
            }
        }
        private void Reset(object sender, RoutedEventArgs e)
        {

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
                    normal.IsChecked= false;
                    maximize.IsChecked= true;
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
