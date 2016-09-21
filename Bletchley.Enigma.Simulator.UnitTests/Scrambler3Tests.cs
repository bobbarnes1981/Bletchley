using NUnit.Framework;

namespace Bletchley.Enigma.Simulator.UnitTests
{
    class Scrambler3Tests
    {
        /// <summary>
        /// Check example from wikipedia
        /// </summary>
        [Test]
        public void CheckFiveAWithRingAGivesCorrectOutput()
        {
            //With the rotors I, II and III (from left to right), wide B - reflector, all ring settings in A - position, and start position AAA, typing AAAAA will produce the encoded sequence BDZGO.
            Scrambler3 s = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.A, Letters.A), Rotor.RotorII(Letters.A, Letters.A), Rotor.RotorIII(Letters.A, Letters.A));

            Letters l;

            l = s.GetOutput(Letters.A);
            Assert.That(l, Is.EqualTo(Letters.B));

            l = s.GetOutput(Letters.A);
            Assert.That(l, Is.EqualTo(Letters.D));

            l = s.GetOutput(Letters.A);
            Assert.That(l, Is.EqualTo(Letters.Z));

            l = s.GetOutput(Letters.A);
            Assert.That(l, Is.EqualTo(Letters.G));

            l = s.GetOutput(Letters.A);
            Assert.That(l, Is.EqualTo(Letters.O));
        }

        /// <summary>
        /// Check example from wikipedia
        /// </summary>
        [Test]
        public void CheckFiveAWithRingBGivesCorrectOutput()
        {
            //With the rotors I, II, III (from left to right), wide B-reflector, all ring settings in B-position, and start position AAA, typing AAAAA will produce the encoded sequence EWTYX.
            Scrambler3 s = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.B, Letters.A), Rotor.RotorII(Letters.B, Letters.A), Rotor.RotorIII(Letters.B, Letters.A));

            Letters l;

            l = s.GetOutput(Letters.A);
            Assert.That(l, Is.EqualTo(Letters.E));

            l = s.GetOutput(Letters.A);
            Assert.That(l, Is.EqualTo(Letters.W));

            l = s.GetOutput(Letters.A);
            Assert.That(l, Is.EqualTo(Letters.T));

            l = s.GetOutput(Letters.A);
            Assert.That(l, Is.EqualTo(Letters.Y));

            l = s.GetOutput(Letters.A);
            Assert.That(l, Is.EqualTo(Letters.X));
        }

        /// <summary>
        /// Check example from https://www.codesandciphers.org.uk/enigma/example1.htm
        /// </summary>
        [Test]
        public void CheckGandPReverseWithSameStartingConfiguration()
        {
            Scrambler s;
            Letters l;

            s = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.A, Letters.A), Rotor.RotorII(Letters.A, Letters.A), Rotor.RotorIII(Letters.A, Letters.Z));
            
            l = s.GetOutput(Letters.G);
            Assert.That(l, Is.EqualTo(Letters.P));

            s = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.A, Letters.A), Rotor.RotorII(Letters.A, Letters.A), Rotor.RotorIII(Letters.A, Letters.Z));

            l = s.GetOutput(Letters.P);
            Assert.That(l, Is.EqualTo(Letters.G));
        }

        [Test]
        public void CheckEncypheredMessageDecyphers()
        {
            Scrambler s = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.A, Letters.A), Rotor.RotorII(Letters.A, Letters.A), Rotor.RotorIII(Letters.A, Letters.A));

            Letters[] expectedPlaintext = LetterMapper.CreateLettersArray("THISISMYTESTMESSAGE");

            Letters[] cyphertext = LetterMapper.CreateLettersArray("OPGNDXOEHCJEXBEDDUO");

            Letters[] plaintext = new Letters[cyphertext.Length];

            for (int i = 0; i < cyphertext.Length; i++)
            {
                plaintext[i] = s.GetOutput(cyphertext[i]);
            }

            Assert.That(plaintext, Is.EqualTo(expectedPlaintext));
        }

        [Test]
        public void CheckEncypheredMessageDecyphersWithRollover()
        {
            Scrambler s = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.A, Letters.A), Rotor.RotorII(Letters.A, Letters.A), Rotor.RotorIII(Letters.A, Letters.A));

            Letters[] expectedPlaintext = LetterMapper.CreateLettersArray("THISISALONGMESSAGETOTESTROLLOVERINTHEROTORS");

            Letters[] cyphertext = LetterMapper.CreateLettersArray("OPGNDXCGMHUNLNECJZGJUPLWOVMOJFUJWQXGSUDEJVY");

            Letters[] plaintext = new Letters[cyphertext.Length];

            for (int i = 0; i < cyphertext.Length; i++)
            {
                plaintext[i] = s.GetOutput(cyphertext[i]);
            }

            Assert.That(plaintext, Is.EqualTo(expectedPlaintext));
        }

        [Test]
        public void CheckEncypheredMessageDecyphersWithMoreRollover()
        {
            Scrambler s = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.A, Letters.A), Rotor.RotorII(Letters.A, Letters.A), Rotor.RotorIII(Letters.A, Letters.A));

            Letters[] expectedPlaintext = LetterMapper.CreateLettersArray("BAUSSRLQONWLBSZPPAORUKKJPRUYZNOLRKKHFMLJRAVSPOJVTPGHRBLEPRVPZMZYNTBWBISKQUBDWIENKKPHHDZIXBUSROMKSBITTAKICWDIFWPINAMXTHWOOQWZWCEIPGKDRMIGIVRSLCEQGHGKXLCXARNZXWGJSICHWOVIUGPLUVNYYQLOONRJJRQNPSIHYMQXXMUOEEKQPVUFLCPUFFJLFWIDHTVBHFHLCJMKWYZWPJHCOBHYXJEOKOSHCMABEVUNHEFYBMFPQPHVQPLFSYFNESRLWBOIBUEMZHLAZFRJEYGVTSCZTKRTRVOLZEFNZPCYDPCNIYQEEJBNWWXSXSRIYAIVFOUVMBOGQZVWMPYVOAUBIOZWFZVVLGKMCOZMWCSCOXWNJRPPVVUUPRURVIWXIATKFHUTXJSNMHCQLKGTTKAFBTORKWHTUCMTXQJFKORXORVINKXGUNCALBJQHQQEWFCQQMBJYWFAWVSZSMFLHUBZEQYEGPBAXMNYVKJBXRMTLBVZTHPQBRPPSFMQRDLJLVUYUHQRYTEUURQSOGYUAEIJQMXSXFJFTLSOPYJLULMGJGXYBPVJHZAGFIBEPUKKEJMVQMGQMKFMZKXGRKGTSYAZLPUDRRWSOHWC");

            Letters[] cyphertext = LetterMapper.CreateLettersArray("ADFNBTUOMHCRANIBRLEVTHRCQJCBVYGUEOMGUKCDTSUQJCUUOFNEKPBXHMQJKEUIXENMCLAHIWCCTJMSETLDMZWJWIYCCNWUHHHFNBWMBITTGETBVFAFRWUTYMQUPZHHRRHYWEJTBAMKJLILXFAZKDHVLDCXMUXDIQKUAXMUXRFYRDWKFFFHFAAQBKLTJNLBRQYUMXDAQZUDTGWGRGITLHPXPDMVOMDWOVBMKRGTRXUKNEDMNILPHYGNJJVOPXZRPRWAQSXERTQVXFPXVVZNTVXAYKLMVUEYZGQOLQSBEVYLRFOQSDUUMLPKAXLWRNBCMCNEFQMERXFIDSNGLBAMVBYOFVUOGNTOLSFKCROCEGOELRWSZTHDNHHISITKKDDUVEKLLDEGCPHWERBOLVTPQQVFBHDDYDSFDYKQLQTCJBUQYGVHVMSOOEDCEUBBPFQPGNIMTTZNSNDTFPMCODOLRZKXHBNTDTQYDNVZZBATJVLQVSVBGVEDBRWQAQUUPTTDPSGZJUWXVOUHNWQMQXHZABKGNUVPELJHVGORJXDYDFINOOYQAFKYORUPEBKNSCOARUUTSAGLWGILXMEPXDYJMSHXQOQRNAQYVJTETTZZPTQUEXYREZOXJTFCJNPK");

            Letters[] plaintext = new Letters[cyphertext.Length];

            for (int i = 0; i < cyphertext.Length; i++)
            {
                plaintext[i] = s.GetOutput(cyphertext[i]);
            }

            Assert.That(plaintext, Is.EqualTo(expectedPlaintext));
        }

        [Test]
        public void CheckEncypheredMessageDecyphersWithRolloverAndRingF()
        {
            Scrambler s = new Scrambler3(Reflector.ReflectorB(), Rotor.RotorI(Letters.A, Letters.A), Rotor.RotorII(Letters.A, Letters.A), Rotor.RotorIII(Letters.F, Letters.A));

            Letters[] expectedPlaintext = LetterMapper.CreateLettersArray("THISMESSAGEWILLCAUSEROLLOVER");

            Letters[] cyphertext = LetterMapper.CreateLettersArray("UFVWRFXPGFNQBAPWSVNSFXOGCPPK");

            Letters[] plaintext = new Letters[cyphertext.Length];

            for (int i = 0; i < cyphertext.Length; i++)
            {
                plaintext[i] = s.GetOutput(cyphertext[i]);
            }

            Assert.That(plaintext, Is.EqualTo(expectedPlaintext));
        }
    }
}
