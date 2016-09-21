using System;
using System.Linq;

namespace Bletchley.Enigma.Simulator
{
    public class EntryWheel
    {
        private readonly Letters[] m_map;

        public EntryWheel(Letters[] map)
        {
            int requiredLetters = Enum.GetNames(typeof(Letters)).Length;

            if (map.Length != requiredLetters)
            {
                throw new Exception(string.Format("map is {0} but should be {1}", map.Length, requiredLetters));
            }

            for (int i = 0; i < map.Length; i++)
            {
                if (map.Count(l => l == map[i]) > 1)
                {
                    throw new Exception(string.Format("duplicate letter {0} in map", map[i]));
                }
            }

            m_map = map;
        }

        public Letters GetInput(Letters input)
        {
            return m_map[(int)input];
        }

        public Letters GetOutput(Letters input)
        {
            return (Letters)Array.IndexOf(m_map, input);
        }

        /// <summary>
        /// Enigma qwertz entrywheel
        /// </summary>
        /// <returns></returns>
        public static EntryWheel EntryWheelQwertz()
        {
            return new EntryWheel(LetterMapper.CreateLettersArray("QWERTZUIOASDFGHJKPYXCVBNML"));
        }

        /// <summary>
        /// Enigma direct entrywheel
        /// </summary>
        /// <returns></returns>
        public static EntryWheel EntryWheelDirect()
        {
            return new EntryWheel(LetterMapper.CreateLettersArray("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
        }
    }
}
