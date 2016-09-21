using NUnit.Framework;
using System;

namespace Bletchley.Enigma.Simulator.UnitTests
{
    class RotorTests
    {
        [Test]
        public void CheckRotorFailsWithMapTooSmall()
        {
            Exception exception = Assert.Throws<Exception>(() => new Rotor(LetterMapper.CreateLettersArray("Z"), Letters.A, Letters.A, Letters.A));

            Assert.That(exception.Message, Is.EqualTo("map is 1 but should be 26"));
        }

        [Test]
        public void CheckRotorFailsWithMapTooBig()
        {
            Exception exception = Assert.Throws<Exception>(() => new Rotor(LetterMapper.CreateLettersArray("zZYXWVUTSRQPONMLKJIHGFEDCBA"), Letters.A, Letters.A, Letters.A));

            Assert.That(exception.Message, Is.EqualTo("map is 27 but should be 26"));
        }

        [Test]
        public void CheckRotorFailsWithMapDuplicate()
        {
            Exception exception = Assert.Throws<Exception>(() => new Rotor(LetterMapper.CreateLettersArray("ZZXWVUTSRQPONMLKJIHGFEDCBA"), Letters.A, Letters.A, Letters.A));

            Assert.That(exception.Message, Is.EqualTo("duplicate letter Z in map"));
        }

        /// <summary>
        /// Check example from wikipedia
        /// </summary>
        [Test]
        public void CheckRotorIReturnsCorrectOutputToLeft()
        {
            Rotor r = Rotor.RotorI(Letters.A, Letters.B);

            //If for example rotor I is in the B - position, an A enters at the letter B which is wired to the K.Because of the offset this K enters the next rotor in the J position.
            Letters left = r.GetLeft(Letters.A);

            Assert.That(left, Is.EqualTo(Letters.J));
        }

        /// <summary>
        /// Check example from wikipedia
        /// </summary>
        [Test]
        public void CheckRotorIReturnsCorrectOutputToRight()
        {
            Rotor r = Rotor.RotorI(Letters.A, Letters.B);

            //If for example rotor I is in the B - position, an A enters at the letter B which is wired to the K.Because of the offset this K enters the next rotor in the J position.
            Letters right = r.GetRight(Letters.J);

            Assert.That(right, Is.EqualTo(Letters.A));
        }

        /// <summary>
        /// Check example from https://www.codesandciphers.org.uk/enigma/example1.htm
        /// </summary>
        [Test]
        public void CheckRotorIIIReturnsCorrectOutputToLeftWithPositionA()
        {
            Rotor r = Rotor.RotorIII(Letters.A, Letters.A);

            Letters left = r.GetLeft(Letters.G);

            Assert.That(left, Is.EqualTo(Letters.C));
        }

        /// <summary>
        /// Check example from https://www.codesandciphers.org.uk/enigma/example1.htm
        /// </summary>
        [Test]
        public void CheckRotorIIReturnsCorrectOutputToLeftWithPositionA()
        {
            Rotor r = Rotor.RotorII(Letters.A, Letters.A);

            Letters left = r.GetLeft(Letters.C);

            Assert.That(left, Is.EqualTo(Letters.D));
        }

        /// <summary>
        /// Check example from https://www.codesandciphers.org.uk/enigma/example1.htm
        /// </summary>
        [Test]
        public void CheckRotorIReturnsCorrectOutputToLeftWithPositionA()
        {
            Rotor r = Rotor.RotorI(Letters.A, Letters.A);

            Letters left = r.GetLeft(Letters.D);

            Assert.That(left, Is.EqualTo(Letters.F));
        }

        /// <summary>
        /// Check example from https://www.codesandciphers.org.uk/enigma/example1.htm
        /// </summary>
        [Test]
        public void CheckRotorIIIReturnsCorrectOutputToRightWithPositionA()
        {
            Rotor r = Rotor.RotorIII(Letters.A, Letters.A);

            Letters right = r.GetRight(Letters.E);

            Assert.That(right, Is.EqualTo(Letters.P));
        }

        /// <summary>
        /// Check example from https://www.codesandciphers.org.uk/enigma/example1.htm
        /// </summary>
        [Test]
        public void CheckRotorIIReturnsCorrectOutputToRightWithPositionA()
        {
            Rotor r = Rotor.RotorII(Letters.A, Letters.A);

            Letters right = r.GetRight(Letters.S);

            Assert.That(right, Is.EqualTo(Letters.E));
        }

        /// <summary>
        /// Check example from https://www.codesandciphers.org.uk/enigma/example1.htm
        /// </summary>
        [Test]
        public void CheckRotorIReturnsCorrectOutputToRightWithPositionA()
        {
            Rotor r = Rotor.RotorI(Letters.A, Letters.A);

            Letters right = r.GetRight(Letters.S);

            Assert.That(right, Is.EqualTo(Letters.S));
        }

        [Test]
        public void CheckRotorIReturnsCorrectOutputToLeftWithPositionARingB()
        {
            Rotor r;
            Letters left;

            // ring b, position a, a->k b->f
            r = Rotor.RotorI(Letters.B, Letters.A);

            //                         A
            //EKMFLGDQVZNTOWYHXUSPAIBRCJ
            left = r.GetLeft(Letters.A);

            Assert.That(left, Is.EqualTo(Letters.K));

            //B
            //EKMFLGDQVZNTOWYHXUSPAIBRCJ
            left = r.GetLeft(Letters.B);

            Assert.That(left, Is.EqualTo(Letters.F));

            // ring f, position y, a->w, b->h
            r = Rotor.RotorI(Letters.F, Letters.Y);

            //        A
            //EKMFLGDQVZNTOWYHXUSPAIBRCJ
            left = r.GetLeft(Letters.A);

            Assert.That(left, Is.EqualTo(Letters.W));

            //     B
            //EKMFLGDQVZNTOWYHXUSPAIBRCJ
            left = r.GetLeft(Letters.B);

            Assert.That(left, Is.EqualTo(Letters.H));
        }

        /// <summary>
        /// Check example from wikipedia
        /// </summary>
        [Test]
        public void CheckRotorIReturnsCorrectOutputToRightWithPositionARingB()
        {
            Rotor r;
            Letters right;

            // ring b, position a, k->a f->b
            r = Rotor.RotorI(Letters.B, Letters.A);

            //                         A
            //EKMFLGDQVZNTOWYHXUSPAIBRCJ
            right = r.GetRight(Letters.K);

            Assert.That(right, Is.EqualTo(Letters.A));

            //B
            //EKMFLGDQVZNTOWYHXUSPAIBRCJ
            right = r.GetRight(Letters.F);

            Assert.That(right, Is.EqualTo(Letters.B));

            // ring f, position y, w->a, h->b
            r = Rotor.RotorI(Letters.F, Letters.Y);

            //        A
            //EKMFLGDQVZNTOWYHXUSPAIBRCJ
            right = r.GetRight(Letters.W);

            Assert.That(right, Is.EqualTo(Letters.A));

            //     B
            //EKMFLGDQVZNTOWYHXUSPAIBRCJ
            right = r.GetRight(Letters.H);

            Assert.That(right, Is.EqualTo(Letters.B));
        }
    }
}
