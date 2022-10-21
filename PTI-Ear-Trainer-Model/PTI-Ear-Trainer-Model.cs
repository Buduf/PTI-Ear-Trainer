using System;

namespace PTI_Ear_Trainer_Model
{
    public class PTI_Ear_Trainer_Model
    {
        private Random rng;

        public PTI_Ear_Trainer_Model()
        {
            this.rng = new Random();
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
            throw new NotImplementedException();
        }
    }
}