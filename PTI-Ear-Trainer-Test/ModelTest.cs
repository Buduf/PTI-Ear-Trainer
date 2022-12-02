using PTI_Ear_Trainer_Model;

namespace PTI_Ear_Trainer_Test
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        [DataRow(Note.C, Note.GSharp, Interval.m6)]
        [DataRow(Note.CSharp, Note.A, Interval.m6)]
        [DataRow(Note.D, Note.ASharp, Interval.m6)]
        [DataRow(Note.DSharp, Note.B, Interval.m6)]

        [DataRow(Note.GSharp, Note.UpperC, Interval.M3)]
        [DataRow(Note.A, Note.UpperCSharp, Interval.M3)]
        [DataRow(Note.ASharp, Note.UpperD, Interval.M3)]
        [DataRow(Note.B, Note.UpperDSharp, Interval.M3)]
        [DataRow(Note.UpperC, Note.UpperE, Interval.M3)]

        [DataRow(Note.B, Note.UpperC, Interval.m2)]

        public void CountIntervalTest(Note note1, Note note2, Interval expectedInterval)
        {
            Assert.AreEqual(expectedInterval, EarTrainer.CountInterval(note1, note2));
        }

        [TestMethod]
        [DataRow(Note.C, Interval.M6, Note.A)]
        [DataRow(Note.CSharp, Interval.M6, Note.ASharp)]
        [DataRow(Note.D, Interval.M6, Note.B)]
        [DataRow(Note.DSharp, Interval.M6, Note.UpperC)]

        [DataRow(Note.G, Interval.M6, Note.UpperE)]
        [DataRow(Note.GSharp, Interval.M6, Note.UpperF)]

        [DataRow(Note.LowerA, Interval.M6, Note.FSharp)]
        [DataRow(Note.LowerASharp, Interval.M6, Note.G)]
        [DataRow(Note.LowerB, Interval.M6, Note.GSharp)]

        public void CountNoteTest(Note note, Interval interval, Note expectedNote)
        {
            Assert.AreEqual(expectedNote, EarTrainer.CountNote(note, interval));
        }
    }
}
