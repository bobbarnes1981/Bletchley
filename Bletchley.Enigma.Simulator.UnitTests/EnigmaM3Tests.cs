using NUnit.Framework;
using System.Collections.Generic;

namespace Bletchley.Enigma.Simulator.UnitTests
{
    class EnigmaM3Tests
    {
        /// <summary>
        /// Checking message from http://wiki.franklinheath.co.uk/index.php/Enigma/Sample_Messages
        /// Enigma Instruction Manual, 1930
        /// </summary>
        [Test]
        public void CheckInstructionManualMessage()
        {
            string expectedPlainText = "FEINDLIQEINFANTERIEKOLONNEBEOBAQTETXANFANGSUEDAUSGANGBAERWALDEXENDEDREIKMOSTWAERTSNEUSTADT";

            // Message Key: ABL
            // Reflector: A
            // Wheel order: II I III
            // Ring positions: 24 13 22
            // Plug Pairs: AM FI NV PS TU WZ
            Scrambler s = new Scrambler(Reflector.ReflectorA(), Rotor.RotorII((Letters)23, Letters.A), Rotor.RotorI((Letters)12, Letters.B), Rotor.RotorIII((Letters)21, Letters.L));

            Plugboard p = new Plugboard(new Dictionary<Letters,Letters>
            {
                { Letters.A, Letters.M },
                { Letters.F, Letters.I },
                { Letters.N, Letters.V },
                { Letters.P, Letters.S },
                { Letters.T, Letters.U },
                { Letters.W, Letters.Z },
            });

            EnigmaM3 e = new EnigmaM3(s, p);

            string cypherText = "GCDSEAHUGWTQGRKVLFGXUCALXVYMIGMMNMFDXTGNVHVRMMEVOUYFZSLRHDRRXFJWCFHUHMUNZEFRDISIKBGPMYVXUZ";

            string plainText = e.GetOutput(cypherText);

            Assert.That(plainText, Is.EqualTo(expectedPlainText));
        }
    }
}
