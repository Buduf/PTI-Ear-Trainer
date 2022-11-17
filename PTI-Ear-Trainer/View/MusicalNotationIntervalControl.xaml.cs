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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace PTI_Ear_Trainer.View
{
    /// <summary>
    /// Interaction logic for MusicalNotationIntervalControl.xaml
    /// </summary>
    public partial class MusicalNotationIntervalControl : UserControl
    {
        private const int LINEGAP = 15;

        public MusicalNotationIntervalControl()
        {
            InitializeComponent();
        }

        public string IntervalName
        {
            get => (string)Labelnterval.Content;
            set => Labelnterval.Content = value;
        }
    }
}
