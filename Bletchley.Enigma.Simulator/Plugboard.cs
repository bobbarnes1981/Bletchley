using System;
using System.Collections.Generic;
using System.Linq;

namespace Bletchley.Enigma.Simulator
{
    public class Plugboard
    {
        private Dictionary<Letters, Letters> m_map;

        public Plugboard(Dictionary<Letters, Letters> map)
        {
            foreach (KeyValuePair<Letters, Letters> pair in map)
            {
                if (pair.Key == pair.Value)
                {
                    throw new Exception(string.Format("direct mapping for {0}", pair.Key));
                }

                if (map.Values.Count(v => v == pair.Value) > 1)
                {
                    throw new Exception(string.Format("duplicate mapping to {0}", pair.Value));
                }

                if (map.Values.Count(v => v == pair.Key) > 0)
                {
                    throw new Exception(string.Format("matching key and value {0}", pair.Key));
                }
            }

            m_map = map;
        }

        public Letters GetOutput(Letters input)
        {
            if (m_map.ContainsKey(input))
            {
                return m_map[input];
            }

            if (m_map.ContainsValue(input))
            {
                return m_map.First(p => p.Value == input).Key;
            }

            return input;
        }
    }
}
