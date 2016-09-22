using System;
using System.Collections.Generic;
using Bletchley.Enigma.Simulator;
using NUnit.Framework;

namespace Bletchley.Bombe.Simulator.UnitTests
{
    class WelchmanTuringBombeTests
    {
        [Test]
        public void LetchworthEnigmaTests()
        {
            //                         |              |  |
            // Plaintext "crib"     A  T  T  A  C  K  A  T  D  A  W  N
            // Ciphertext           W  A  Z  X  L  E  C  C  X  B  U  P
            // Message position     1  2  3  4  5  6  7  8  9 10 11 12
            // Upper drum setting   Z  Z  Z  Z  Z  Z  Z  Z  Z  Z  Z  Z
            // Middle drum setting  Z  Z  Z  Z  Z  Z  Z  Z  Z  Z  Z  Z
            // Lower drum setting   A  B  C  D  E  F  G  H  I  J  K  L

            // Menu                  ATC
            //                        2
            //                      A - T
            //                    7  \ /  8
            //                        C

            // validate input produces output
            EnigmaM3 e = new EnigmaM3(new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.A, Letters.Z), Rotor.RotorII(Letters.A, Letters.Z), Rotor.RotorIII(Letters.A, Letters.A)), new Plugboard(new Dictionary<Letters, Letters>()));
            string plainText = "ATTACKATDAWN";
            string cypherText = e.GetOutput(plainText);
            Assert.That(cypherText, Is.EqualTo("WAZXLECCXBUP"));

            // set up l1 at offset A/1 (B/2)
            Scrambler3 s1 = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.A, Letters.Z), Rotor.RotorII(Letters.A, Letters.Z), Rotor.RotorIII(Letters.A, Letters.A));
            LetchworthEnigma l1 = new LetchworthEnigma(s1);

            // set up l2 at offset F/6 (G/7)
            Scrambler3 s2 = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.A, Letters.Z), Rotor.RotorII(Letters.A, Letters.Z), Rotor.RotorIII(Letters.A, Letters.F));
            LetchworthEnigma l2 = new LetchworthEnigma(s2);

            // set up l3 at offset G/7 (H/8)
            Scrambler3 s3 = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.A, Letters.Z), Rotor.RotorII(Letters.A, Letters.Z), Rotor.RotorIII(Letters.A, Letters.G));
            LetchworthEnigma l3 = new LetchworthEnigma(s3);

            bool found = false;

            // check all combinations with relative offsets
            for (int i = 0; i < (26*25*26); i++)
            {
                Letters o1 = l1.GetOutput(Letters.T);
                Letters o2 = l2.GetOutput(Letters.A);
                Letters o3 = l3.GetOutput(Letters.T);
                
                if (o1 == Letters.A && o2 == Letters.C && o3 == Letters.C)
                {
                    found = true;
                }
            };

            // TODO: get initial settings from startup settings
            // run another letchworthEnigma starting at initial settings? tick it over at same rate

            Assert.That(found, Is.True);
        }
    }
}
