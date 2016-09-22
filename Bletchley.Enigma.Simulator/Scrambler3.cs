namespace Bletchley.Enigma.Simulator
{
    /// <summary>
    /// A three rotor scrambler that accepts three standard rotors and a standard reflector
    /// </summary>
    public class Scrambler3 : Scrambler
    {
        public Scrambler3(Reflector reflector, Rotor rotorL, Rotor rotorM, Rotor rotorR)
            : base(reflector, Rotor.RotorPassThrough(), rotorL, rotorM, rotorR, EntryWheel.EntryWheelDirect())
        {
        }
    }
}
