using System;
using NUnit.Framework;

namespace Bletchley.Enigma.Simulator.UnitTests
{
    class EntryWheelTests
    {
        [Test]
        public void CheckEntryWheelFailsWithMapTooSmall()
        {
            Exception exception = Assert.Throws<Exception>(() => new EntryWheel(LetterMapper.CreateLettersArray("Z")));

            Assert.That(exception.Message, Is.EqualTo("map is 1 but should be 26"));
        }

        [Test]
        public void CheckEntryWheelFailsWithMapTooBig()
        {
            Exception exception = Assert.Throws<Exception>(() => new EntryWheel(LetterMapper.CreateLettersArray("zZYXWVUTSRQPONMLKJIHGFEDCBA")));

            Assert.That(exception.Message, Is.EqualTo("map is 27 but should be 26"));
        }

        [Test]
        public void CheckEntryWheelFailsWithMapDuplicate()
        {
            Exception exception = Assert.Throws<Exception>(() => new EntryWheel(LetterMapper.CreateLettersArray("ZZXWVUTSRQPONMLKJIHGFEDCBA")));

            Assert.That(exception.Message, Is.EqualTo("duplicate letter Z in map"));
        }

        [Test]
        public void CheckEntryWheelSucceedsWithMapQwertz()
        {
            EntryWheel e = new EntryWheel(LetterMapper.CreateLettersArray("QWERTZUIOASDFGHJKPYXCVBNML"));
        }

        [Test]
        public void CheckEntryWheelSucceedsWithMapDirect()
        {
            EntryWheel e = new EntryWheel(LetterMapper.CreateLettersArray("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
        }

        [Test]
        public void CheckEntryWheelGivesCorrectInputValue()
        {
            EntryWheel e = new EntryWheel(LetterMapper.CreateLettersArray("QWERTZUIOASDFGHJKPYXCVBNML"));

            Letters result = e.GetInput(Letters.A);

            Assert.That(result, Is.EqualTo(Letters.J));
        }

        [Test]
        public void CheckEntryWheelGivesCorrectOutputValue()
        {
            EntryWheel e = new EntryWheel(LetterMapper.CreateLettersArray("QWERTZUIOASDFGHJKPYXCVBNML"));

            Letters result = e.GetOutput(Letters.J);

            Assert.That(result, Is.EqualTo(Letters.A));
        }
    }
}
