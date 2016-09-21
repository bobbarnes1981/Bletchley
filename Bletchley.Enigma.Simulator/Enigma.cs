namespace Bletchley.Enigma.Simulator
{
    public abstract class Enigma : IEnigma
    {
        private readonly Scrambler m_scrambler;

        private readonly Plugboard m_plugboard;

        public Enigma(Scrambler scrambler, Plugboard plugboard)
        {
            m_scrambler = scrambler;
            m_plugboard = plugboard;
        }

        public string GetOutput(string text)
        {
            Letters[] inputText = LetterMapper.CreateLettersArray(text);

            Letters[] outputText = new Letters[inputText.Length];

            for (int i = 0; i < inputText.Length; i++)
            {
                outputText[i] = GetOutput(inputText[i]);
            }

            return LetterMapper.CreateLettersString(outputText);
        }

        public Letters GetOutput(Letters input)
        {
            // pass throught plugboard
            Letters output = m_plugboard.GetOutput(input);

            // pass through scrambler
            output = m_scrambler.GetOutput(output);

            // pass through scrambler
            output = m_plugboard.GetOutput(output);

            return output;
        }
    }
}
