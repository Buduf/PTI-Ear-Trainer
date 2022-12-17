using System.Windows;

namespace PTI_Ear_Trainer.View
{
    /// <summary>
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        public Leaderboard()
        {
            InitializeComponent();
        }

        private void Reset(object sender, RoutedEventArgs e)
        {

        }
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
