using System;
using I = PTI_Ear_Trainer_Model.Interval;
using N = PTI_Ear_Trainer_Model.Note;

namespace PTI_Ear_Trainer_Model
{
    public class EarTrainer
    {
        private Random rng;

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

        public EarTrainer() : this(GameDifficulty.MEDIUM) { }

        private IntervalPuzzle? _intervalPuzzle;

        public EarTrainer(GameDifficulty difficulty)
        {
            rng = new Random();
            Difficulty = difficulty;
        }

        public static Interval CountInterval(Note note1, Note note2)
        {
            //return (Interval)(((int)note1 >= (int)note2) ? ((int)note1 - (int)note2) : ((int)note2 - (int)note1));
            if (note2 >= note1) return (Interval)((int)note2 - (int)note1);
            throw new ArgumentException("First note must be lower than second note!");
            //return (Interval)((int)note2 + Enum.GetNames(typeof(Note)).Length - (int)note1);

        }

        public static Note CountNote(Note note, Interval interval)
        {
            return (Note)((int)note + (int)interval);
        }

        public bool GuessInterval(Interval interval)
        {
            if (_intervalPuzzle is null) return false;
            return interval == _intervalPuzzle.Interval;
        }

        private Note RandomNote(GameDifficulty difficulty) =>
            (Note)rng.Next(possibleNotes[(int)difficulty].Length);
        
        private Interval RandomInterval(GameDifficulty difficulty) =>
            (Interval)rng.Next(possibleIntervals[(int)difficulty].Length);

        private IntervalPuzzle GenerateInterval() => 
            new IntervalPuzzle(RandomNote(Difficulty), RandomInterval(Difficulty));
    }
}