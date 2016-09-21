using System;
using NUnit.Framework;

namespace Bletchley.Enigma.Simulator.UnitTests
{
    class ReflectorTests
    {
        [Test]
        public void CheckReflectorFailsWithMapTooSmall()
        {
            Exception exception = Assert.Throws<Exception>(() => new Reflector(LetterMapper.CreateLettersArray("Z")));

            Assert.That(exception.Message, Is.EqualTo("map is 1 but should be 26"));
        }

        [Test]
        public void CheckReflectorFailsWithMapTooBig()
        {
            Exception exception = Assert.Throws<Exception>(() => new Reflector(LetterMapper.CreateLettersArray("zZYXWVUTSRQPONMLKJIHGFEDCBA")));

            Assert.That(exception.Message, Is.EqualTo("map is 27 but should be 26"));
        }

        [Test]
        public void CheckReflectorFailsWithMapDuplicate()
        {
            Exception exception = Assert.Throws<Exception>(() => new Reflector(LetterMapper.CreateLettersArray("ZZXWVUTSRQPONMLKJIHGFEDCBA")));

            Assert.That(exception.Message, Is.EqualTo("duplicate letter Z in map"));
        }

        [Test]
        public void CheckReflectorFailsWithMapDirect()
        {
            Exception exception = Assert.Throws<Exception>(() => new Reflector(LetterMapper.CreateLettersArray("ABCDEFGHIJKLMNOPQRSTUVWXYZ")));

            Assert.That(exception.Message, Is.EqualTo("reflector contains direct map for A"));
        }

        [Test]
        public void CheckReflectorCreatesCorrectOutput()
        {
            Reflector r = new Reflector(LetterMapper.CreateLettersArray("ZYXWVUTSRQPONMLKJIHGFEDCBA"));

            Letters result;

            result = r.GetOutput(Letters.A);

            Assert.That(result, Is.EqualTo(Letters.Z));

            result = r.GetOutput(Letters.Z);

            Assert.That(result, Is.EqualTo(Letters.A));
        }
    }
}
