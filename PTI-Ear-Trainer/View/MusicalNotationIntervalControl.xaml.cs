using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PTI_Ear_Trainer_Model;

namespace PTI_Ear_Trainer.View
{
    /// <summary>
    /// Interaction logic for MusicalNotationIntervalControl.xaml
    /// </summary>
    public partial class MusicalNotationIntervalControl : UserControl
    {
        private const int LINEGAP = 15;
        private bool intervalVisible;
        private Note note1;
        private Note note2;

        public MusicalNotationIntervalControl()
        {
            InitializeComponent();
        }

        [Description("Sets if the notes and the interval label are visible."), Category("Interval Properties")]
        public bool IntervalVisible
        {
            get => intervalVisible;
            set
            {
                intervalVisible = value;
                if (intervalVisible)
                {
                    DrawingNote1.Visibility = Visibility.Visible;
                    DrawingNote2.Visibility = Visibility.Visible;
                    Labelnterval.Visibility = Visibility.Visible;
                }
                else
                {
                    DrawingNote1.Visibility = Visibility.Hidden;
                    DrawingNote2.Visibility = Visibility.Hidden;
                    Labelnterval.Visibility = Visibility.Hidden;
                }
                updateHelperLines();
                updateSharpSigns();
            }
        }
        [Description("The name of the interval to display."), Category("Interval Properties")]
        public string IntervalName
        {
            get => (string)Labelnterval.Content;
            set => Labelnterval.Content = value;
        }

        [Description("Sets the first note. Immediately updates the control."), Category("Interval Properties")]
        public Note Note1
        {
            get => note1;
            set
            {
                note1 = value;
                double yPos = getNotePosY(note1);
                Canvas.SetTop(DrawingNote1, yPos);
                Canvas.SetTop(SharpSign1, yPos - 22.5);
                updateHelperLines();
                updateSharpSigns();
            }
        }

        [Description("The image displayed by the button."), Category("Interval Properties")]
        public Note Note2
        {
            get => note2;
            set
            {
                note2 = value;
                double yPos = getNotePosY(note2);
                Canvas.SetTop(DrawingNote2, yPos);
                Canvas.SetTop(SharpSign2, yPos - 22.5);
                updateHelperLines();
                updateSharpSigns();
            }
        }

        private double getNotePosY(Note note)
        {
            // The C base note's y position, and line position.
            double basePosY = 112.5;
            double linePosition = 0;
            switch (note)
            {
                case Note.LowerA:
                case Note.LowerASharp:
                    linePosition = -1; break;
                case Note.LowerB:
                    linePosition = -0.5; break;
                case Note.C:
                case Note.CSharp:
                    linePosition = 0; break;
                case Note.D:
                case Note.DSharp:
                    linePosition = 0.5; break;
                case Note.E:
                    linePosition = 1; break;
                case Note.F:
                case Note.FSharp:
                    linePosition = 1.5; break;
                case Note.G:
                case Note.GSharp:
                    linePosition = 2; break;
                case Note.A:
                case Note.ASharp:
                    linePosition = 2.5; break;
                case Note.B:
                    linePosition = 3; break;
                case Note.UpperC:
                case Note.UpperCSharp:
                    linePosition = 3.5; break;
                case Note.UpperD:
                case Note.UpperDSharp:
                    linePosition = 4; break;
                case Note.UpperE:
                    linePosition = 4.5; break;
                case Note.UpperF:
                    linePosition = 5; break;
            }
            return basePosY - linePosition * LINEGAP;
        }

        private void updateHelperLines()
        {
            if (IntervalVisible)
            {
                HelperLine1.Visibility = IntervalVisible && note1 < Note.D || note2 < Note.D ?
                    Visibility.Visible : Visibility.Hidden;
                HelperLine2.Visibility = IntervalVisible && note1 < Note.LowerB || note2 < Note.LowerB ?
                    Visibility.Visible : Visibility.Hidden;
            }
        }

        private static readonly Note[] sharpNotes = { Note.LowerASharp, Note.CSharp, Note.DSharp, Note.FSharp, Note.GSharp, Note.ASharp, Note.UpperCSharp, Note.UpperDSharp };
        private void updateSharpSigns()
        {
                SharpSign1.Visibility = IntervalVisible && sharpNotes.Contains(note1) ?
                Visibility.Visible : Visibility.Hidden;
                SharpSign2.Visibility = IntervalVisible && sharpNotes.Contains(note2) ?
                    Visibility.Visible : Visibility.Hidden;
        }
    }
}
