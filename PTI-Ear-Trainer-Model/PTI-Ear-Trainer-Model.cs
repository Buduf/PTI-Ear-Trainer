using System;

namespace PTI_Ear_Trainer_Model
{
    public class PTI_Ear_Trainer_Model
    {
        private Random rng;

        public GameDifficulty Difficulty { get; set; }

        public PTI_Ear_Trainer_Model()
        {
            this.rng = new Random();
            this.Difficulty = GameDifficulty.MEDIUM;
        }

        public static Interval CountInterval(Note note1, Note note2)
        {
            //return (Interval)(((int)note1 >= (int)note2) ? ((int)note1 - (int)note2) : ((int)note2 - (int)note1));
            if (note2 >= note1) return (Interval)((int)note2 - (int)note1);
            return (Interval)((int)note2 + Enum.GetNames(typeof(Note)).Length - (int)note1);

        }

        public static Note CountNote (Note note, Interval interval)
        {
            return (Note)(((int)note + (int)interval) % 12);
        }

        private IntervalPuzzle GenerateInterval()
        {
            switch ((int)this.Difficulty)
            {
                case (int)GameDifficulty.VERYEASY:
                    return new IntervalPuzzle(0, (Note)this.rng.Next(2)); // for starters, we always generate a C as the first note
                case (int)GameDifficulty.EASY:
                    return new IntervalPuzzle(0, (Note)this.rng.Next(4));
                case (int)GameDifficulty.MEDIUM:
                    return new IntervalPuzzle(0, (Note)this.rng.Next(6));
                case (int)GameDifficulty.HARD:
                    return new IntervalPuzzle(0, (Note)this.rng.Next(9));
                case (int)GameDifficulty.VERYHARD:
                    return new IntervalPuzzle(0, (Note)this.rng.Next(12));
                default:
                    return new IntervalPuzzle(0, (Note)this.rng.Next(6));
            }
        }
    }
}