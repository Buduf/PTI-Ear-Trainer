using System;
using I = PTI_Ear_Trainer_Model.Interval;
using N = PTI_Ear_Trainer_Model.Note;

namespace PTI_Ear_Trainer_Model
{
    public class EarTrainer
    {
        private Random rng;
        private IntervalPuzzle _intervalPuzzle = null!;
        private readonly N[][] possibleNotes =
        {
            new N[] { N.C },
            new N[] { N.LowerA, N.C, N.E },
            new N[] { N.LowerA, N.C, N.E },
            new N[] { N.LowerA, N.LowerB, N.C, N.D, N.E, N.F },
            new N[] { N.LowerA, N.LowerASharp, N.LowerB, N.C, N.CSharp, N.D, N.DSharp, N.E, N.F }
        };
        private readonly I[][] possibleIntervals =
        {
            new I[] { I.P1, I.M2, I.P5, I.P8 },
            new I[] { I.P1, I.M2, I.M3, I.P4, I.P5, I.P8 },
            new I[] { I.P1, I.m2, I.M2, I.m3, I.M3, I.P4, I.P5, I.M6, I.M7, I.P8 },
            new I[] { I.P1, I.m2, I.M2, I.m3, I.M3, I.P4, I.P5, I.m6, I.M6, I.m7, I.M7, I.P8 },
            new I[] { I.P1, I.m2, I.M2, I.m3, I.M3, I.P4, I.P5, I.m6, I.M6, I.m7, I.M7, I.P8 }
        };

        public GameDifficulty Difficulty { get; set; }

        public event EventHandler<GuessEventArgs>? IntervalGuessed;

        public EarTrainer() : this(GameDifficulty.MEDIUM) { }

        public EarTrainer(GameDifficulty difficulty)
        {
            rng = new Random();
            Difficulty = difficulty;
            NextPuzzle();
        }

        public static Interval CountInterval(Note note1, Note note2)
        {
            if (note1 >= note2)
                throw new ArgumentException("First note must be lower than second note!");
            return (Interval)((int)note2 - (int)note1);
        }

        public static Note CountNote(Note note, Interval interval)
        {
            return (Note)((int)note + (int)interval);
        }

        public void NextPuzzle()
        {
            _intervalPuzzle = new IntervalPuzzle(RandomNote(Difficulty), RandomInterval(Difficulty));
        }

        public void GuessInterval(Interval interval)
        {
            if (_intervalPuzzle is null) return;
            IntervalGuessed?.Invoke(this, new GuessEventArgs(interval == _intervalPuzzle.Interval, _intervalPuzzle.Note1, _intervalPuzzle.Note2));
        }

        private Note RandomNote(GameDifficulty difficulty) =>
            (Note)rng.Next(possibleNotes[(int)difficulty].Length);
        
        private Interval RandomInterval(GameDifficulty difficulty) =>
            (Interval)rng.Next(possibleIntervals[(int)difficulty].Length);
    }
}