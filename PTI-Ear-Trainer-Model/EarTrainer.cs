using System;
using I = PTI_Ear_Trainer_Model.Interval;
using N = PTI_Ear_Trainer_Model.Note;

namespace PTI_Ear_Trainer_Model
{
    public class EarTrainer
    {
        private Random rng;

        public DateTime StartTime { get; private set; }

        public static readonly N[][] PossibleNotes =
        {
            new N[] { N.LowerA, N.C, N.E },
            new N[] { N.LowerA, N.LowerB, N.C, N.D, N.E, N.F },
            new N[] { N.LowerA, N.LowerASharp, N.LowerB, N.C, N.CSharp, N.D, N.DSharp, N.E, N.F }
        };
        public static readonly I[][] PossibleIntervals =
        {
            new I[] { I.P1, I.M2, I.M3, I.P4, I.P5, I.P8 },
            new I[] { I.m2, I.M2, I.m3, I.M3, I.P4, I.P5, I.M6, I.M7, I.P8 },
            new I[] { I.m2, I.M2, I.m3, I.M3, I.P4, I.P5, I.m6, I.M6, I.m7, I.M7, I.P8 }
        };
        public static readonly int TotalPuzzleCount = 10;

        public IntervalPuzzle IntervalPuzzle { get; private set; } = null!;
        public GameDifficulty Difficulty { get; set; }
        public int PuzzleNumber { get; private set; }
        public int CorrectGuesses { get; private set; }

        public event EventHandler<GuessEventArgs>? IntervalGuessed;
        public event EventHandler? EarTrainerEnded;

        public EarTrainer() : this(GameDifficulty.MEDIUM) { }

        public EarTrainer(GameDifficulty difficulty)
        {
            StartTime = DateTime.Now;
            rng = new Random();
            Difficulty = difficulty;
        }

        public static Interval CountInterval(Note note1, Note note2)
        {
            if (note1 > note2)
                throw new ArgumentException("First note must be lower than second note!");
            return (Interval)((int)note2 - (int)note1);
        }

        public static Note CountNote(Note note, Interval interval)
        {
            return (Note)((int)note + (int)interval);
        }

        public void NextPuzzle()
        {
            if (++PuzzleNumber < TotalPuzzleCount)
            {
                IntervalPuzzle = new IntervalPuzzle(RandomNote(Difficulty), RandomInterval(Difficulty));
            }
            else
            {
                EarTrainerEnded?.Invoke(this, EventArgs.Empty);
            }
        }

        public void GuessInterval(Interval interval)
        {
            bool correct = interval == IntervalPuzzle.Interval;
            if (correct)
                CorrectGuesses++;
            IntervalGuessed?.Invoke(this, new GuessEventArgs(correct, IntervalPuzzle.Note1, IntervalPuzzle.Note2));
        }

        private Note RandomNote(GameDifficulty difficulty) =>
            PossibleNotes[(int)difficulty][rng.Next(PossibleNotes[(int)difficulty].Length)];

        private Interval RandomInterval(GameDifficulty difficulty) =>
            PossibleIntervals[(int)difficulty][rng.Next(PossibleIntervals[(int)difficulty].Length)];
    }
}
