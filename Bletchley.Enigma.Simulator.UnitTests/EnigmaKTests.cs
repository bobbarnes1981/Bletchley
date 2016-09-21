using System.Collections.Generic;
using NUnit.Framework;

namespace Bletchley.Enigma.Simulator.UnitTests
{
    class EnigmaKTests
    {
        /// <summary>
        /// Checking message from http://wiki.franklinheath.co.uk/index.php/Enigma/Sample_Messages
        /// Turing's Treatise, 1940
        /// </summary>
        [Test]
        public void CheckInstructionManualMessage()
        {
            //string expectedPlainText = "";

            //// Message Key: JEZA
            //// Reflector: ?
            //// Wheel order: III I II
            //// Ring positions: 26 17 16 13
            //// Plug Pairs: 
            //ScramblerK s = new ScramblerK(ReflectorK.Reflector((Letters)25, Letters.J), Rotor.RotorKIII((Letters)16, Letters.E), Rotor.RotorKI((Letters)15, Letters.Z), Rotor.RotorKII((Letters)12, Letters.A), EntryWheel.EntryWheelK());

            //EnigmaK e = new EnigmaK(s);

            //string cypherText = "QSZVIDVMPNEXACMRWWXUIYOTYNGVVXDZ";

            //string plainText = e.GetOutput(cypherText);

            //Assert.That(plainText, Is.EqualTo(expectedPlainText));
        }
    }
}
