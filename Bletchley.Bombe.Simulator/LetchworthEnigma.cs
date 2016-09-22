using Bletchley.Enigma.Simulator;

namespace Bletchley.Bombe.Simulator
{
    public class LetchworthEnigma
    {
        private readonly Scrambler3 m_scrambler;

        public LetchworthEnigma(Scrambler3 scrambler)
        {
            m_scrambler = scrambler;
        }

        public Letters GetOutput(Letters input)
        {
            Letters output = m_scrambler.GetOutput(input);

            return output;
        }
    }
}
