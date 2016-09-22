using NUnit.Framework;
using System.Collections.Generic;

namespace Bletchley.Enigma.Simulator.UnitTests
{
    class EnigmaM4Tests
    {
        /// <summary>
        /// Checking message from http://wiki.franklinheath.co.uk/index.php/Enigma/Sample_Messages
        /// Enigma Instruction Manual, 1930
        /// </summary>
        [Test]
        public void CheckU264Message()
        {
            string expectedPlainText = "VONVONJLOOKSJHFFTTTEINSEINSDREIZWOYYQNNSNEUNINHALTXXBEIANGRIFFUNTERWASSERGEDRUECKTYWABOSXLETZTERGEGNERSTANDNULACHTDREINULUHRMARQUANTONJOTANEUNACHTSEYHSDREIYZWOZWONULGRADYACHTSMYSTOSSENACHXEKNSVIERMBFAELLTYNNNNNNOOOVIERYSICHTEINSNULL";

            // Message Key: VJNA
            // Reflector: Thin B
            // Wheel order: Beta II IV I
            // Ring positions: 01 01 01 22
            // Plug Pairs: AT BL DF GJ HM NW OP QY RZ VX
            Scrambler4 s = new Scrambler4(Reflector.ReflectorThinB(), Rotor.RotorBeta((Letters)0, Letters.V), Rotor.RotorII((Letters)0, Letters.J), Rotor.RotorIV((Letters)0, Letters.N), Rotor.RotorI((Letters)21, Letters.A));

            Plugboard p = new Plugboard(new Dictionary<Letters, Letters>
            {
                { Letters.A, Letters.T },
                { Letters.B, Letters.L },
                { Letters.D, Letters.F },
                { Letters.G, Letters.J },
                { Letters.H, Letters.M },
                { Letters.N, Letters.W },
                { Letters.O, Letters.P },
                { Letters.Q, Letters.Y },
                { Letters.R, Letters.Z },
                { Letters.V, Letters.X },
            });

            EnigmaM4 e = new EnigmaM4(s, p);

            string cypherText = "NCZWVUSXPNYMINHZXMQXSFWXWLKJAHSHNMCOCCAKUQPMKCSMHKSEINJUSBLKIOSXCKUBHMLLXCSJUSRRDVKOHULXWCCBGVLIYXEOAHXRHKKFVDREWEZLXOBAFGYUJQUKGRTVUKAMEURBVEKSUHHVOYHABCJWMAKLFKLMYFVNRIZRVVRTKOFDANJMOLBGFFLEOPRGTFLVRHOWOPBEKVWMUQFMPWPARMFHAGKXIIBG";

            string plainText = e.GetOutput(cypherText);

            Assert.That(plainText, Is.EqualTo(expectedPlainText));
        }
    }
}
