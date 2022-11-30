using PTI_Ear_Trainer.View;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace PTI_Ear_Trainer
{
    ///<summary>
    ///Interaction logic for MainWindow.xaml
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
            //// For testing!
            //Hide();
            //GameWindow window = new GameWindow("Practice mode");
            //window.Show();
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

            //name = getname.Text;

            if (name == "" && difficulty == "Unspecified" && gamemode == "Unspecified")
            {
                MessageBox.Show("PLease choose a nickname, select difficulty and game mode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (name !="" && difficulty == "Unspecified" && gamemode != "Unspecified")
            {
                MessageBox.Show("Please select difficulty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (name !="" && difficulty != "Unspecified" && gamemode == "Unspecified")
            {
                MessageBox.Show("PLease select game mode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (name == "" && difficulty == "Unspecified" && gamemode != "Unspecified")
            {
                MessageBox.Show("Please choose a nickname and difficulty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (name =="" && difficulty != "Unspecified" && gamemode == "Unspecified")
            {
                MessageBox.Show("PLease choose a nickname and game mode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (name =="" && difficulty != "Unspecified" && gamemode != "Unspecified")
            {
                MessageBox.Show("PLease choose a nickname.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (name!="" && difficulty == "Unspecified" && gamemode == "Unspecified")
            {
                MessageBox.Show("PLease select difficulty and game mode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.Hide();
                GameWindow window = new GameWindow(name, difficulty, gamemode);
                window.Show();
            }
            //GameWindow gw = new GameWindow(difficulty,10);
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
            this.Hide();
            MainWindow window = new MainWindow();
            window.Show();
        }
        private void Reset(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("asd");
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
