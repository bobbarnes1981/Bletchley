using System;
using System.Linq;

namespace Bletchley.Enigma.Simulator
{
    public class ReflectorK : IReflector
    {
        private readonly Letters[] m_map;

        private readonly Letters m_ring;

        private readonly Letters m_position;

        public ReflectorK(Letters[] map, Letters ring, Letters position)
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

                if (map[i] == (Letters)i)
                {
                    throw new Exception(string.Format("reflector contains direct map for {0}", map[i]));
                }
            }

            m_map = map;
            m_ring = ring;
            m_position = position;
        }

        public Letters GetOutput(Letters input)
        {
            // offset ring
            input -= (int)m_ring;
            if (input < 0)
            {
                input += Enum.GetNames(typeof(Letters)).Length;
            }

            // offset position
            Letters offsetInput = (Letters)((int)input + (int)m_position);
            if ((int)offsetInput >= Enum.GetNames(typeof(Letters)).Length)
            {
                offsetInput -= Enum.GetNames(typeof(Letters)).Length;
            }

            // map to letter
            Letters output = (Letters)Array.IndexOf(m_map, offsetInput);

            // offset position
            Letters offsetOutput = (Letters)((int)output - (int)m_position);
            if (offsetOutput < 0)
            {
                offsetOutput += Enum.GetNames(typeof(Letters)).Length;
            }

            // offset ring
            offsetOutput += (int)m_ring;
            if ((int)offsetOutput >= Enum.GetNames(typeof(Letters)).Length)
            {
                offsetOutput -= Enum.GetNames(typeof(Letters)).Length;
            }

            return offsetOutput;
        }

        /// <summary>
        /// Enigma K Railway Reflector
        /// </summary>
        /// <param name="ring"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static ReflectorK Reflector(Letters ring, Letters position)
        {
            return new ReflectorK(LetterMapper.CreateLettersArray("QYHOGNECVPUZTFDJAXWMKISRBL"), ring, position);
        }
    }
}
