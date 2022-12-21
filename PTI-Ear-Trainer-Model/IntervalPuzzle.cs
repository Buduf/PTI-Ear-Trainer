using System;

namespace PTI_Ear_Trainer_Model
{
    public class IntervalPuzzle
    {
        public Note Note1 { get; private set; }
        public Note Note2 { get; private set; }

        private Interval _interval;

        public Interval Interval
        {
            get { return _interval; }
            private set { _interval = value; }
        }

        public IntervalPuzzle(Note lowerNote, Note higherNote)
        {
            this.Note1 = lowerNote;
            this.Note2 = higherNote;
            this.SetInterval(this.Note1, this.Note2);
        }

        public IntervalPuzzle(Note note, Interval interval)
        {
            Note1 = note;
            Note2 = EarTrainer.CountNote(note, interval);
            _interval = interval;
        }

        public Interval GetInterval()
        {
            return this._interval;
        }

        public void SetInterval(Interval interval)
        {
            this._interval = interval;
        }
        public void SetInterval(Note note1, Note note2)
        {
            this._interval = EarTrainer.CountInterval(note1, note2);
        }
    }
}
