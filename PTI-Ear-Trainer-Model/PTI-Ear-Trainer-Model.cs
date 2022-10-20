namespace PTI_Ear_Trainer_Model
{
    public class PTI_Ear_Trainer_Model
    {
        private Random rng;

        public PTI_Ear_Trainer_Model()
        {
            this.rng = new Random();
        }

        static internal Interval CountInterval(Note note1, Note note2)
        {
            return (Interval)Math.Abs((int)note2 - (int)note1);
        }

        static internal Note CountNote (Note note, Interval interval)
        {
            return (Note)(((int)note + (int)interval) % 12);
        }

        private IntervalPuzzle GenerateInterval()
        {
            throw new NotImplementedException();
        }
    }
}