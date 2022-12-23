using System.Windows;
using PTI_Ear_Trainer.View;
using PTI_Ear_Trainer.ViewModel;
using PTI_Ear_Trainer_Model;

namespace PTI_Ear_Trainer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow mainWindow = new MainWindow();
        private GameWindow gameWindow = new GameWindow();
        private PuzzleViewModel? viewModel;
        private EarTrainer? model;

        public App()
        {
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            gameWindow.MenuItemExitCurrentGame.Click += GameWindow_ExitCurrentGame;
            gameWindow.MenuItemNewGame.Click += OnNewGame;
            mainWindow.ButtonNewGame.Click += OnNewGame;
            mainWindow.MenuItemNewGame.Click += OnNewGame;
            mainWindow.Show();
        }

        private void OnNewGame(object sender, RoutedEventArgs e)
        {
            string name = mainWindow.TextBoxName.Text;
            if (name.Length < 3)
            {
                MessageBox.Show("Username is too short.", "Error");
                return;
            }
            GameDifficulty difficulty = mainWindow.GetSelectedDifficulty();
            // TODO: get gamemode..., get instrument

            model = new EarTrainer(difficulty);
            viewModel = new PuzzleViewModel(model);
            viewModel.EarTrainerEnded += ViewModel_EarTrainerEnded;
            gameWindow.DataContext = viewModel;

            mainWindow.Hide();
            gameWindow.Show();
        }

        private void ViewModel_EarTrainerEnded(object? sender, System.EventArgs e)
        {
            MessageBox.Show($"Time: {viewModel?.Time}\nCorrect Guesses: {model?.CorrectGuesses}", "Ear Trainer Ended");
            gameWindow.Hide();
            mainWindow.Show();
        }

        private void GameWindow_ExitCurrentGame(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                gameWindow.Hide();
                mainWindow.Show();
            }
        }
    }
}
