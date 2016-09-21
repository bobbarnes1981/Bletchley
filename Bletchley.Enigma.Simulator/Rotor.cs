using System;
using System.Linq;

namespace Bletchley.Enigma.Simulator
{
    public class Rotor
    {
        private readonly Letters[] m_map;

        private readonly Letters m_notch;

        private readonly Letters m_ring;

        private Letters m_position;

        public Rotor(Letters[] map, Letters notch, Letters ring, Letters position)
        {
            int requiredLetters = Enum.GetNames(typeof (Letters)).Length;

            if (map.Length != requiredLetters)
            {
                throw new Exception(string.Format("map is {0} but should be {1}", map.Length, requiredLetters));
            }

            for (int i =0; i < map.Length; i++)
            {
                if (map.Count(l => l == map[i]) > 1)
                {
                    throw new Exception(string.Format("duplicate letter {0} in map", map[i]));
                }
            }

            m_map = map;
            m_notch = notch;
            m_ring = ring;
            m_position = position;
        }

        public Letters GetLeft(Letters right)
        {
            // offset ring
            right -= (int)m_ring;
            if (right < 0)
            {
                right += Enum.GetNames(typeof(Letters)).Length;
            }

            // offset position
            Letters offsetRight = (Letters)((int)right + (int)m_position);
            if ((int)offsetRight >= Enum.GetNames(typeof(Letters)).Length)
            {
                offsetRight -= Enum.GetNames(typeof(Letters)).Length;
            }

            // map to letter
            Letters left = m_map[(int)offsetRight];
            Letters offsetLeft = (Letters)((int)left - (int)m_position);
            if (offsetLeft < 0)
            {
                offsetLeft += Enum.GetNames(typeof(Letters)).Length;
            }

            // offset ring
            offsetLeft += (int)m_ring;
            if ((int)offsetLeft >= Enum.GetNames(typeof(Letters)).Length)
            {
                offsetLeft -= Enum.GetNames(typeof(Letters)).Length;
            }

            return offsetLeft;
        }

        public Letters GetRight(Letters offsetLeft)
        {
            // offset ring
            offsetLeft -= (int)m_ring;
            if (offsetLeft < 0)
            {
                offsetLeft += Enum.GetNames(typeof(Letters)).Length;
            }

            // offset position
            Letters left = (Letters)((int)offsetLeft + (int)m_position);
            if ((int)left >= Enum.GetNames(typeof(Letters)).Length)
            {
                left -= Enum.GetNames(typeof(Letters)).Length;
            }

            // map to letter
            Letters offsetRight = (Letters)Array.IndexOf(m_map, left);

            // offset position
            Letters right = (Letters)((int)offsetRight - (int)m_position);
            if (right < 0)
            {
                right += Enum.GetNames(typeof(Letters)).Length;
            }

            // offset ring
            right += (int)m_ring;
            if ((int)right >= Enum.GetNames(typeof(Letters)).Length)
            {
                right -= Enum.GetNames(typeof(Letters)).Length;
            }

            return right;
        }
        
        public void Rotate()
        {
            m_position++;
            if ((int)m_position == Enum.GetNames(typeof(Letters)).Length)
            {
                m_position = 0;
            }
        }

        public bool InNotch
        {
            get { return m_notch == m_position; }
        }

        public static Rotor RotorI(Letters ring, Letters position)
        {
            return new Rotor(LetterMapper.CreateLettersArray("EKMFLGDQVZNTOWYHXUSPAIBRCJ"), Letters.Q, ring, position);
        }

        public static Rotor RotorII(Letters ring, Letters position)
        {
            return new Rotor(LetterMapper.CreateLettersArray("AJDKSIRUXBLHWTMCQGZNPYFVOE"), Letters.E, ring, position);
        }

        public static Rotor RotorIII(Letters ring, Letters position)
        {
            return new Rotor(LetterMapper.CreateLettersArray("BDFHJLCPRTXVZNYEIWGAKMUSQO"), Letters.V, ring, position);
        }

        public static Rotor RotorIV(Letters ring, Letters position)
        {
            return new Rotor(LetterMapper.CreateLettersArray("ESOVPZJAYQUIRHXLNFTGKDCMWB"), Letters.J, ring, position);
        }

        public static Rotor RotorV(Letters ring, Letters position)
        {
            return new Rotor(LetterMapper.CreateLettersArray("VZBRGITYUPSDNHLXAWMJQOFECK"), Letters.Z, ring, position);
        }

        /// <summary>
        /// Enigma K Railway rotor I
        /// </summary>
        /// <param name="ring"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Rotor RotorKI(Letters ring, Letters position)
        {
            return new Rotor(LetterMapper.CreateLettersArray("JGDQOXUSCAMIFRVTPNEWKBLZYH"), Letters.N, ring, position);
        }

        /// <summary>
        /// Enigma K Railway rotor II
        /// </summary>
        /// <param name="ring"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Rotor RotorKII(Letters ring, Letters position)
        {
            return new Rotor(LetterMapper.CreateLettersArray("NTZPSFBOKMWRCJDIVLAEYUXHGQ"), Letters.E, ring, position);
        }

        /// <summary>
        /// Enigma K Railway rotor III
        /// </summary>
        /// <param name="ring"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Rotor RotorKIII(Letters ring, Letters position)
        {
            return new Rotor(LetterMapper.CreateLettersArray("JVIUBHTCDYAKEQZPOSGXNRMWFL"), Letters.Y, ring, position);
        }
    }
}
