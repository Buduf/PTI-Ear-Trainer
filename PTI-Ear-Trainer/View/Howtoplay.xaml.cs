using System.Windows;

namespace PTI_Ear_Trainer.View
{
    /// <summary>
    /// Interaction logic for Howtoplay.xaml
    /// </summary>
    public partial class Howtoplay : Window
    {
        public Howtoplay()
        {
            InitializeComponent();
            Description.Text = "";
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
