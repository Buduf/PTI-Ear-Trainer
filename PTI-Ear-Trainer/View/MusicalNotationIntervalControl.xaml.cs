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
        private const int LINEGAP = 16;
        private BitmapImage GClef = new BitmapImage(new Uri("pack://application:,,,/Resources/GClef.png"));

        public MusicalNotationIntervalControl()
        {
            InitializeComponent();
            DrawBaseNotation();
        }

        public string IntervalName
        {
            get => (string)Labelnterval.Content;
            set => Labelnterval.Content = value;
        }

        /// <summary>
        /// Draw the lines and the G-Clef.
        /// </summary>
        private void DrawBaseNotation()
        {
            DrawingGroup drGroup = new DrawingGroup();
            using (DrawingContext dx = drGroup.Open())
            {
                Pen pen = new Pen(Brushes.Black, 2);
                Point point = new Point(0, (NotationImage.Height / 2) - 2 * LINEGAP);
                for (int i = 0; i < 5; i++)
                {
                    Point start = Point.Add(point, new Vector(0, i * LINEGAP));
                    Point end = Point.Add(start, new Vector(NotationImage.Width, 0));
                    dx.DrawLine(pen, start, end);
                }

                dx.DrawImage(GClef, new Rect(0, (NotationImage.Height / 2) - 4 * LINEGAP, 48, 128));
            }
            DrawingImage img = new DrawingImage(drGroup);
            NotationImage.Source = img;
        }
    }
}
