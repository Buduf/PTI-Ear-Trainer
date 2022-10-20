namespace PTI_Ear_Trainer_Model
{
    public class PTI_Ear_Trainer_Model
    {
        Interval CountInterval(Note note1, Note note2)
        {
            return (Interval)Math.Abs((int)note2 - (int)note1);
        }

        Note CountNote (Note note, Interval interval)
        {
            return (Note)(((int)note + (int)interval) % 12);
        }
    }
}