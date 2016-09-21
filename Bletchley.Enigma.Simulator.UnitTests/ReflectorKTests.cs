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

        [Test]
        public void CheckReflectorKCreatesCorrectOutput()
        {
            ReflectorK r = new ReflectorK(LetterMapper.CreateLettersArray("QYHOGNECVPUZTFDJAXWMKISRBL"), Letters.A, Letters.A);

            Letters result;

            result = r.GetOutput(Letters.A);

            Assert.That(result, Is.EqualTo(Letters.Q));

            result = r.GetOutput(Letters.Q);

            Assert.That(result, Is.EqualTo(Letters.A));
        }

        /// <summary>
        /// TODO: Not sure if this is right
        /// </summary>
        [Test]
        public void CheckReflectorKCreatesCorrectOutputPositionB()
        {
            ReflectorK r = new ReflectorK(LetterMapper.CreateLettersArray("QYHOGNECVPUZTFDJAXWMKISRBL"), Letters.A, Letters.B);

            Letters result;

            result = r.GetOutput(Letters.A);

            Assert.That(result, Is.EqualTo(Letters.X));

            result = r.GetOutput(Letters.X);

            Assert.That(result, Is.EqualTo(Letters.A));
        }

        /// <summary>
        /// TODO: Not sure if this is right
        /// </summary>
        [Test]
        public void CheckReflectorKCreatesCorrectOutputRingB()
        {
            ReflectorK r = new ReflectorK(LetterMapper.CreateLettersArray("QYHOGNECVPUZTFDJAXWMKISRBL"), Letters.B, Letters.A);

            Letters result;

            result = r.GetOutput(Letters.A);

            Assert.That(result, Is.EqualTo(Letters.M));

            result = r.GetOutput(Letters.M);

            Assert.That(result, Is.EqualTo(Letters.A));
        }
    }
}
