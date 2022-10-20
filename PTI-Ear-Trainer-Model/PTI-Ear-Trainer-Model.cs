namespace PTI_Ear_Trainer_Model
{
    public class PTI_Ear_Trainer_Model
    {
        enum Notes
        {
            C = 0, CSharp, D, DSharp, E, F, FSharp, G, GSharp, A, ASharp, B
        }
        enum Intervals
        {
            P1 = 0, m2, M2, m3, M3, P4, P5, m6, M6, m7, M7, P8
        }

        Intervals CountInterval(Notes note1, Notes note2)
        {
            return (Intervals)Math.Abs((int)note2 - (int)note1);
        }

        Notes CountNote (Notes note, Intervals interval)
        {
            return (Notes)(((int)note + (int)interval) % 12);
        }
    }
}