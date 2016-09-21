namespace Bletchley.Enigma.Simulator
{
    public class LetterMapper
    {
        public static Letters[] CreateLettersArray(string lettersString)
        {
            Letters[] letters = new Letters[lettersString.Length];

            for (int i = 0; i < lettersString.Length; i++)
            {
                letters[i] = (Letters)(lettersString[i] - 'A');
            }

            return letters;
        }
        public static string CreateLettersString(Letters[] letters)
        {
            string lettersString = string.Empty;

            for (int i = 0; i < letters.Length; i++)
            {
                lettersString += (char)(letters[i] + 'A');
            }

            return lettersString;
        }
    }
}
