using PTI_Ear_Trainer_Model;

namespace PTI_Ear_Trainer_Test
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        [DataRow(Note.C,      Note.GSharp, Interval.M6)]
        [DataRow(Note.CSharp, Note.A,      Interval.M6)]
        [DataRow(Note.D,      Note.ASharp, Interval.M6)]
        [DataRow(Note.DSharp, Note.B,      Interval.M6)]
        
        [DataRow(Note.GSharp, Note.C,      Interval.M3)]
        [DataRow(Note.A,      Note.CSharp, Interval.M3)]
        [DataRow(Note.ASharp, Note.D,      Interval.M3)]
        [DataRow(Note.B,      Note.DSharp, Interval.M3)]

        [DataRow(Note.B,      Note.C,      Interval.m2)]
        
        public void CountIntervalTest(Note note1, Note note2, Interval expectedInterval)
        {
            Assert.AreEqual(expectedInterval, PTI_Ear_Trainer_Model.PTI_Ear_Trainer_Model.CountInterval(note1, note2));
        }

        [TestMethod]
        [DataRow(Note.C,      Interval.M6, Note.GSharp)]
        [DataRow(Note.CSharp, Interval.M6, Note.A     )]
        [DataRow(Note.D,      Interval.M6, Note.ASharp)]
        [DataRow(Note.DSharp, Interval.M6, Note.B     )]

        [DataRow(Note.GSharp, Interval.M6, Note.E     )]
        [DataRow(Note.A,      Interval.M6, Note.F     )]
        [DataRow(Note.ASharp, Interval.M6, Note.FSharp)]
        [DataRow(Note.B,      Interval.M6, Note.G     )]

        public void CountNoteTest(Note note, Interval interval, Note expectedNote)
        {
            Assert.AreEqual(expectedNote, PTI_Ear_Trainer_Model.PTI_Ear_Trainer_Model.CountNote(note, interval));
        }
    }
}