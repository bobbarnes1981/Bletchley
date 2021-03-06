﻿using System;
using System.Linq;

namespace Bletchley.Enigma.Simulator
{
    /// <summary>
    /// A standard reflector
    /// </summary>
    public class Reflector : IReflector
    {
        private readonly Letters[] m_map;

        public Reflector(Letters[] map)
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
        }

        public Letters GetOutput(Letters input)
        {
            return m_map[(int)input];
        }

        public static Reflector ReflectorA()
        {
            return new Reflector(LetterMapper.CreateLettersArray("EJMZALYXVBWFCRQUONTSPIKHGD"));
        }

        public static Reflector ReflectorB()
        {
            return new Reflector(LetterMapper.CreateLettersArray("YRUHQSLDPXNGOKMIEBFZCWVJAT"));
        }

        public static Reflector ReflectorThinB()
        {
            return new Reflector(LetterMapper.CreateLettersArray("ENKQAUYWJICOPBLMDXZVFTHRGS"));
        }
    }
}
