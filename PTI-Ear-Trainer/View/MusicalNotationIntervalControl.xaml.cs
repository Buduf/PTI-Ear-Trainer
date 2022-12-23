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
        public static readonly DependencyProperty Note1Property =
            DependencyProperty.Register(
                name: "Note2",
                propertyType: typeof(Note),
                ownerType: typeof(MusicalNotationIntervalControl),
                typeMetadata: new PropertyMetadata(Note.C, new PropertyChangedCallback(OnNote1Changed)));

        public static readonly DependencyProperty Note2Property =
            DependencyProperty.Register(
                name: "Note1",
                propertyType: typeof(Note),
                ownerType: typeof(MusicalNotationIntervalControl),
                typeMetadata: new PropertyMetadata(Note.C, new PropertyChangedCallback(OnNote2Changed)));

        public static readonly DependencyProperty IntervalVisibleProperty =
            DependencyProperty.Register(
                name: "IntervalVisible",
                propertyType: typeof(bool),
                ownerType: typeof(MusicalNotationIntervalControl),
                typeMetadata: new PropertyMetadata(false, new PropertyChangedCallback(OnIntervalVisibleChanged)));

        public static readonly DependencyProperty IntervalNameProperty =
            DependencyProperty.Register(
                name: "IntervalName",
                propertyType: typeof(string),
                ownerType: typeof(MusicalNotationIntervalControl),
                typeMetadata: new PropertyMetadata("Perfect Unison", new PropertyChangedCallback(OnIntervalNameChanged)));

        [Description("Sets the first note. Immediately updates the control."), Category("Interval Properties")]
        public Note Note1
        {
            get => (Note)GetValue(Note1Property);
            set => SetValue(Note1Property, value);
        }

        [Description("Sets the second note. Immediately updates the control."), Category("Interval Properties")]
        public Note Note2
        {
            get => (Note)GetValue(Note2Property);
            set => SetValue(Note2Property, value);
        }

        [Description("Sets if the notes and the interval label are visible."), Category("Interval Properties")]
        public bool IntervalVisible
        {
            get => (bool)GetValue(IntervalVisibleProperty);
            set => SetValue(IntervalVisibleProperty, value);
        }

        [Description("The name of the interval to display."), Category("Interval Properties")]
        public string IntervalName
        {
            get => (string)GetValue(IntervalNameProperty);
            set => SetValue(IntervalNameProperty, value);
        }

        private static void OnNote1Changed(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            (d as MusicalNotationIntervalControl)?.OnNote1Changed(e);

        private static void OnNote2Changed(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            (d as MusicalNotationIntervalControl)?.OnNote2Changed(e);

        private static void OnIntervalVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            (d as MusicalNotationIntervalControl)?.OnIntervalVisibleChanged(e);

        private static void OnIntervalNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            (d as MusicalNotationIntervalControl)?.OnIntervalNameChanged(e);

        private void OnNote1Changed(DependencyPropertyChangedEventArgs e)
        {
            double yPos = getNotePosY(Note1);
            Canvas.SetTop(DrawingNote1, yPos);
            Canvas.SetTop(SharpSign1, yPos - 22.5);
            updateHelperLines();
            updateSharpSigns();
        }

        private void OnNote2Changed(DependencyPropertyChangedEventArgs e)
        {
            double yPos = getNotePosY(Note2);
            Canvas.SetTop(DrawingNote2, yPos);
            Canvas.SetTop(SharpSign2, yPos - 22.5);
            updateHelperLines();
            updateSharpSigns();
        }

        private void OnIntervalVisibleChanged(DependencyPropertyChangedEventArgs e)
        {
            if (IntervalVisible)
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

        private void OnIntervalNameChanged(DependencyPropertyChangedEventArgs e)
        {
            Labelnterval.Content = IntervalName;
        }

        private const int LINEGAP = 15;

        public MusicalNotationIntervalControl()
        {
            InitializeComponent();
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
            HelperLine1.Visibility = IntervalVisible && (Note1 < Note.D || Note2 < Note.D) ?
                Visibility.Visible : Visibility.Hidden;
            HelperLine2.Visibility = IntervalVisible && (Note1 < Note.LowerB || Note2 < Note.LowerB) ?
                Visibility.Visible : Visibility.Hidden;
        }

        private static readonly Note[] sharpNotes = { Note.LowerASharp, Note.CSharp, Note.DSharp, Note.FSharp, Note.GSharp, Note.ASharp, Note.UpperCSharp, Note.UpperDSharp };
        private void updateSharpSigns()
        {
            SharpSign1.Visibility = IntervalVisible && sharpNotes.Contains(Note1) ?
                Visibility.Visible : Visibility.Hidden;
            SharpSign2.Visibility = IntervalVisible && sharpNotes.Contains(Note2) ?
                Visibility.Visible : Visibility.Hidden;
        }
    }
}
