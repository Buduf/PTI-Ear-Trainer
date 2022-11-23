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

namespace PTI_Ear_Trainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string difficulty = "Unspecified";
        string gamemode = "Unspecified";
        public MainWindow()
        {
            InitializeComponent();
            //// For testing!
            //Hide();
            //GameWindow window = new GameWindow("Practice mode");
            //window.Show();
        }

        private void New_Game_Click(object sender, RoutedEventArgs e)
        {
            if (easy.IsChecked == true)
            {
                difficulty = "Easy";
            }
            else if (medium.IsChecked == true)
            {
                difficulty = "Medium";
            }
            else if (hard.IsChecked == true)
            {
                difficulty = "Hard";
            }
            
            if (competitive.IsChecked == true)
            {
                gamemode = "Competetive";
            } else if (casual.IsChecked ==true)
            {
                gamemode = "Casual";
            } else if(practice.IsChecked == true)
            {
                gamemode = "Practice";
            }

            if(difficulty == "Unspecified" && gamemode == "Unspecified")
            {
                MessageBox.Show("PLease select difficulty and game mode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (difficulty == "Unspecified" && gamemode != "Unspecified")
            {
                MessageBox.Show("Please select difficulty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (difficulty != "Unspecified" && gamemode == "Unspecified")
            {
                MessageBox.Show("PLease select game mode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else {
                this.Hide();
                GameWindow window = new GameWindow(difficulty);
                window.Show();
            }
            //GameWindow gw = new GameWindow(difficulty,10);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
            App.Current.Shutdown();
        }
    }
}
