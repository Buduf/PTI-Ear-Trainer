using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTI_Ear_Trainer_Model
{
    internal class IntervalPuzzle
    {
        public Note Note1 { get; private set; }
        public Note Note2 { get; private set; }

        private Interval _interval;

        public IntervalPuzzle(Note lowerNote, Note higherNote)
        {
            this.Note1 = lowerNote;
            this.Note2 = higherNote;
            this.SetInterval(this.Note1, this.Note2);
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
            this._interval = PTI_Ear_Trainer_Model.CountInterval(note1, note2);
        }
    }
}
