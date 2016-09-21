using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Bletchley.Enigma.Simulator.UnitTests
{
    class PlugboardTests
    {
        [Test]
        public void CheckPlugboardFailsWithMatchigKeyValue()
        {
            Exception exception = Assert.Throws<Exception>(() => new Plugboard(new Dictionary<Letters, Letters> { { Letters.A, Letters.B }, { Letters.C, Letters.A } }));

            Assert.That(exception.Message, Is.EqualTo("matching key and value A"));

            exception = Assert.Throws<Exception>(() => new Plugboard(new Dictionary<Letters, Letters> { { Letters.B, Letters.A }, { Letters.A, Letters.C } }));

            Assert.That(exception.Message, Is.EqualTo("matching key and value A"));
        }

        [Test]
        public void CheckPlugboardFailsWithDuplicateMap()
        {
            Exception exception = Assert.Throws<Exception>(() => new Plugboard(new Dictionary<Letters, Letters> { { Letters.A, Letters.B }, { Letters.C, Letters.B } }));

            Assert.That(exception.Message, Is.EqualTo("duplicate mapping to B"));
        }

        [Test]
        public void CheckPlugboardFailsWithDirectMap()
        {
            Exception exception = Assert.Throws<Exception>(() => new Plugboard(new Dictionary<Letters, Letters> { { Letters.A, Letters.A } }));

            Assert.That(exception.Message, Is.EqualTo("direct mapping for A"));
        }

        [Test]
        public void CheckPlugboardSucceeds()
        {
            Plugboard p = new Plugboard(new Dictionary<Letters, Letters> { { Letters.A, Letters.B } });
        }

        [Test]
        public void CheckPlugboardReturnsCorrectForMapped()
        {
            Plugboard p = new Plugboard(new Dictionary<Letters, Letters> { { Letters.A, Letters.B } });

            Letters result;

            result = p.GetOutput(Letters.A);

            Assert.That(result, Is.EqualTo(Letters.B));

            result = p.GetOutput(Letters.B);

            Assert.That(result, Is.EqualTo(Letters.A));
        }

        [Test]
        public void CheckPlugboardReturnsCorrectForUnmapped()
        {
            Plugboard p = new Plugboard(new Dictionary<Letters, Letters> { { Letters.A, Letters.B } });

            Letters result = p.GetOutput(Letters.C);

            Assert.That(result, Is.EqualTo(Letters.C));
        }
    }
}
