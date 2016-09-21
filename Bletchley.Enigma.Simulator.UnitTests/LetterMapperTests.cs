using NUnit.Framework;

namespace Bletchley.Enigma.Simulator.UnitTests
{
    class LetterMapperTests
    {
        [Test]
        public void CheckMapsLetters()
        {
            Letters[] expectedResult = new Letters[]
            {
                Letters.A,
                Letters.B,
                Letters.C
            };

            Letters[] actualResult = LetterMapper.CreateLettersArray("ABC");

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckMapsString()
        {
            string expectedResult = "ABC";

            string actualResult = LetterMapper.CreateLettersString(new Letters[] {Letters.A, Letters.B, Letters.C});

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
