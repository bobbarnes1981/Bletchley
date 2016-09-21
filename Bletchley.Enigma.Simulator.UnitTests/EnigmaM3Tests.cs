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
            Scrambler3 s = new Scrambler3(Reflector.ReflectorA(), Rotor.RotorII((Letters)23, Letters.A), Rotor.RotorI((Letters)12, Letters.B), Rotor.RotorIII((Letters)21, Letters.L));

            Plugboard p = new Plugboard(new Dictionary<Letters, Letters>
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

        /// <summary>
        /// Checking message from http://wiki.franklinheath.co.uk/index.php/Enigma/Sample_Messages
        /// Operation Barbarossa, 1941
        /// </summary>
        [Test]
        public void CheckOperationBarbarosaMessage()
        {
            string expectedPlainText = "AUFKLXABTEILUNGXVONXKURTINOWAXKURTINOWAXNORDWESTLXSEBEZXSEBEZXUAFFLIEGERSTRASZERIQTUNGXDUBROWKIXDUBROWKIXOPOTSCHKAXOPOTSCHKAXUMXEINSAQTDREINULLXUHRANGETRETENXANGRIFFXINFXRGTX";

            // Message Key: BLA
            // Reflector: B
            // Wheel order: II IV V
            // Ring positions: 02 21 12
            // Plug Pairs: AV BS CG DL FU HZ IN KM OW RX
            Scrambler3 s = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorII((Letters)1, Letters.B), Rotor.RotorIV((Letters)20, Letters.L), Rotor.RotorV((Letters)11, Letters.A));

            Plugboard p = new Plugboard(new Dictionary<Letters, Letters>
            {
                { Letters.A, Letters.V },
                { Letters.B, Letters.S },
                { Letters.C, Letters.G },
                { Letters.D, Letters.L },
                { Letters.F, Letters.U },
                { Letters.H, Letters.Z },
                { Letters.I, Letters.N },
                { Letters.K, Letters.M },
                { Letters.O, Letters.W },
                { Letters.R, Letters.X },
            });

            EnigmaM3 e = new EnigmaM3(s, p);

            string cypherText = "EDPUDNRGYSZRCXNUYTPOMRMBOFKTBZREZKMLXLVEFGUEYSIOZVEQMIKUBPMMYLKLTTDEISMDICAGYKUACTCDOMOHWXMUUIAUBSTSLRNBZSZWNRFXWFYSSXJZVIJHIDISHPRKLKAYUPADTXQSPINQMATLPIFSVKDASCTACDPBOPVHJK";

            string plainText = e.GetOutput(cypherText);

            Assert.That(plainText, Is.EqualTo(expectedPlainText));
        }
    }
}
