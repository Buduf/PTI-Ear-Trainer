using System.Windows;

namespace PTI_Ear_Trainer.View
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
