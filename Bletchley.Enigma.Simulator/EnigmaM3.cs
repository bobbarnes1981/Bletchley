namespace Bletchley.Enigma.Simulator
{
    public class EnigmaM3
    {
        private Scrambler m_scrambler;

        private Plugboard m_plugboard;

        public EnigmaM3(Scrambler scrambler, Plugboard plugboard)
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
