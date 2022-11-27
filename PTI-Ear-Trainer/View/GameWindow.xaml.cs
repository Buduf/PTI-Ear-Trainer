using System;
using System.Collections.Generic;
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
            Title = "PTI Ear Trainer - " + difficulty;
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
            this.Hide();
            GameWindow window = new GameWindow(name, difficulty, gamemode, 10);
            window.Show();
        }
        private void ExitCurrentGame(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow window = new MainWindow();
            window.Show();
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
    }
}
