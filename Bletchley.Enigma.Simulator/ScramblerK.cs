namespace Bletchley.Enigma.Simulator
{
    public class ScramblerK : Scrambler
    {
        public ScramblerK(ReflectorK reflector, Rotor rotorL, Rotor rotorM, Rotor rotorR, EntryWheel entryWheel)
            : base(reflector, rotorL, rotorM, rotorR, entryWheel)
        {
        }
    }
}
