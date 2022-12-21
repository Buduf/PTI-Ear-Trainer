using System;

namespace PTI_Ear_Trainer_Model
{
    public class GuessEventArgs : EventArgs
    {
        public bool IsCorrect { get; private set; }
        public Note CorrectNote1 { get; private set; }
        public Note CorrectNote2 { get; private set; }

        public GuessEventArgs(bool isCorrect, Note correctNote1, Note correctNote2)
        {
            IsCorrect = isCorrect;
            CorrectNote1 = correctNote1;
            CorrectNote2 = correctNote2;
        }
    }
}
