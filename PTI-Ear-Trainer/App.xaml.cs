using System.Windows;
using PTI_Ear_Trainer.View;
using PTI_Ear_Trainer_Model;

namespace PTI_Ear_Trainer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow mainWindow = new MainWindow();
        private GameWindow? gameWindow;
        private EarTrainer? model;

        public App()
        {
            mainWindow.ButtonNewGame.Click += MainWindow_NewGame;
            mainWindow.MenuItemNewGame.Click += MainWindow_NewGame;
            mainWindow.Show();
        }

        private void MainWindow_NewGame(object sender, RoutedEventArgs e)
        {
            string name = mainWindow.TextBoxName.Text;
            if (name.Length > 3)
            {
                MessageBox.Show("Username is too short.", "Error");
                return;
            }
            GameDifficulty difficulty = mainWindow.GetSelectedDifficulty();
            // TODO: get gamemode...

            mainWindow.Hide();
        }
    }
}
