namespace Bletchley.Enigma.Simulator
{
    public class Scrambler3 : Scrambler
    {
        public Scrambler3(Reflector reflector, Rotor rotorL, Rotor rotorM, Rotor rotorR)
            : base(reflector, rotorL, rotorM, rotorR, EntryWheel.EntryWheelDirect())
        {
        }
    }
}
