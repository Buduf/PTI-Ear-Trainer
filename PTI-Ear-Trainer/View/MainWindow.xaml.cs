using System;
using System.Windows;
using System.Windows.Controls;
using PTI_Ear_Trainer.View;

namespace PTI_Ear_Trainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name = "Unspecified";
        string difficulty = "Unspecified";
        string gamemode = "Unspecified";
        protected int x;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Easy_Checked(object sender, RoutedEventArgs e)
        {
            SetDifficulty("Easy");
        }
        private void Medium_Checked(object sender, RoutedEventArgs e)
        {
            SetDifficulty("Medium");
        }
        private void Hard_Checked(object sender, RoutedEventArgs e)
        {
            SetDifficulty("Hard");
        }

        private void Competitive_Checked(object sender, RoutedEventArgs e)
        {
            SetGamemode("Competetive");
        }

        private void Casual_Checked(object sender, RoutedEventArgs e)
        {
            SetGamemode("Casual");
        }

        private void Practice_Checked(object sender, RoutedEventArgs e)
        {
            SetGamemode("Practice");
        }
        private void New_Game_Click(object sender, RoutedEventArgs e)
        {
            if (name == "" && difficulty == "Unspecified" && gamemode == "Unspecified")
            {
                MessageBox.Show("PLease choose a nickname, select difficulty and game mode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (name != "" && difficulty == "Unspecified" && gamemode != "Unspecified")
            {
                MessageBox.Show("Please select difficulty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (name != "" && difficulty != "Unspecified" && gamemode == "Unspecified")
            {
                MessageBox.Show("PLease select game mode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (name == "" && difficulty == "Unspecified" && gamemode != "Unspecified")
            {
                MessageBox.Show("Please choose a nickname and difficulty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (name == "" && difficulty != "Unspecified" && gamemode == "Unspecified")
            {
                MessageBox.Show("PLease choose a nickname and game mode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (name == "" && difficulty != "Unspecified" && gamemode != "Unspecified")
            {
                MessageBox.Show("PLease choose a nickname.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (name != "" && difficulty == "Unspecified" && gamemode == "Unspecified")
            {
                MessageBox.Show("PLease select difficulty and game mode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.Hide();
                GameWindow window = new GameWindow(name, difficulty, gamemode);
                window.Show();
            }
        }

        private void SetDifficulty(string thisdifficulty)
        {
            difficulty = thisdifficulty;
        }
        private void SetGamemode(string thisgamemode)
        {
            gamemode = thisgamemode;
        }
        private void SetName(object sender, TextChangedEventArgs e)
        {
            name = Getname.Text;
        }
        private void NewGame(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to start a new game?", "New game", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Hide();
                MainWindow window = new MainWindow();
                window.Show();
            }
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
