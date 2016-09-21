using System.Collections.Generic;

namespace Bletchley.Enigma.Simulator
{
    public class EnigmaK : Enigma
    {
        /// <summary>
        /// Enigma K Railway
        /// </summary>
        /// <param name="scrambler"></param>
        public EnigmaK(ScramblerK scrambler)
            : base(scrambler, new Plugboard(new Dictionary<Letters, Letters>()))
        {
        }
    }
}
