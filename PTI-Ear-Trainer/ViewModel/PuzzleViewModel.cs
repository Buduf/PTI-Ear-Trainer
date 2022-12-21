using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PTI_Ear_Trainer_Model;

namespace PTI_Ear_Trainer.ViewModel
{
    public partial class PuzzleViewModel : ObservableObject
    {
        private EarTrainer model;
        private Instrument instrument;
        private SoundPlayer sound1 = new SoundPlayer();
        private SoundPlayer sound2 = new SoundPlayer();

        [ObservableProperty]
        private Note note1, note2;
        [ObservableProperty]
        private Interval interval;
        [ObservableProperty]
        private bool isGuessed, isCorrect;

        public int TotalPuzzleCount { get => EarTrainer.TotalPuzzleCount; }
        public int PuzzleNumber { get => model.PuzzleNumber; }
        public ObservableCollection<IntervalInfo> PossibleIntervals { get; private set; } = new ObservableCollection<IntervalInfo>();

        public PuzzleViewModel(EarTrainer model, Instrument instrument = Instrument.Piano)
        {
            this.model = model;
            this.instrument = instrument;
            model.IntervalGuessed += OnIntervalGuessed;
            foreach (Interval item in EarTrainer.PossibleIntervals[(int)model.Difficulty])
            {
                PossibleIntervals.Add(new IntervalInfo(model, item));
            }
            NextPuzzle();
        }

        private void LoadSound(SoundPlayer sound, Note note)
        {
            Uri uri = new Uri($"/Audio/{instrument}/{note}.wav", UriKind.Relative);
            sound.Stream = Application.GetResourceStream(uri).Stream;
        }

        [RelayCommand(AllowConcurrentExecutions = false)]
        private async Task PlaySounds()
        {
            await Task.WhenAll(Task.Run(() => sound1.LoadAsync()), Task.Run(() => sound2.LoadAsync()));
            await Task.Run(() =>
            {
                sound1.PlaySync();
                sound2.PlaySync();
            });
            sound1.Stream.Position = 0;
            sound2.Stream.Position = 0;
        }

        private void NextPuzzle()
        {
            Note1 = model.IntervalPuzzle.Note1;
            Note2 = model.IntervalPuzzle.Note2;
            IsGuessed = false;
            LoadSound(sound1, Note1);
            LoadSound(sound2, Note2);
            PlaySoundsCommand.ExecuteAsync(null);
        }

        private void OnIntervalGuessed(object? sender, GuessEventArgs e)
        {
            Note1 = e.CorrectNote1;
            Note2 = e.CorrectNote2;
            Interval = EarTrainer.CountInterval(Note1, Note2);
            IsGuessed = true;
        }
    }
}
