using System;
using NUnit.Framework;

namespace Bletchley.Enigma.Simulator.UnitTests
{
    class ReflectorKTests
    {
        [Test]
        public void CheckReflectorKFailsWithMapTooSmall()
        {
            Exception exception = Assert.Throws<Exception>(() => new ReflectorK(LetterMapper.CreateLettersArray("Z"), Letters.A, Letters.A));

            Assert.That(exception.Message, Is.EqualTo("map is 1 but should be 26"));
        }

        [Test]
        public void CheckReflectorKFailsWithMapTooBig()
        {
            Exception exception = Assert.Throws<Exception>(() => new ReflectorK(LetterMapper.CreateLettersArray("zZYXWVUTSRQPONMLKJIHGFEDCBA"), Letters.A, Letters.A));

            Assert.That(exception.Message, Is.EqualTo("map is 27 but should be 26"));
        }

        [Test]
        public void CheckReflectorKFailsWithMapDuplicate()
        {
            Exception exception = Assert.Throws<Exception>(() => new ReflectorK(LetterMapper.CreateLettersArray("ZZXWVUTSRQPONMLKJIHGFEDCBA"), Letters.A, Letters.A));

            Assert.That(exception.Message, Is.EqualTo("duplicate letter Z in map"));
        }

        [Test]
        public void CheckReflectorKFailsWithMapDirect()
        {
            Exception exception = Assert.Throws<Exception>(() => new ReflectorK(LetterMapper.CreateLettersArray("ABCDEFGHIJKLMNOPQRSTUVWXYZ"), Letters.A, Letters.A));

            Assert.That(exception.Message, Is.EqualTo("reflector contains direct map for A"));
        }
    }
}
