namespace Bletchley.Enigma.Simulator
{
    public class LetterMapper
    {
        public static Letters[] CreateLettersArray(string map)
        {
            Letters[] letters = new Letters[map.Length];

            for (int i = 0; i < map.Length; i++)
            {
                letters[i] = (Letters)(map[i] - 'A');
            }

            return letters;
        }
    }
}
