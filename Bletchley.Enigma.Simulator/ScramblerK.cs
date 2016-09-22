namespace Bletchley.Enigma.Simulator
{
    /// <summary>
    /// A three rotor scrambler that accepts three standard rotors and a settable reflector
    /// </summary>
    public class ScramblerK : Scrambler
    {
        public ScramblerK(ReflectorK reflector, Rotor rotorL, Rotor rotorM, Rotor rotorR, EntryWheel entryWheel)
            : base(reflector, Rotor.RotorPassThrough(), rotorL, rotorM, rotorR, entryWheel)
        {
        }
    }
}
