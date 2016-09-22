namespace Bletchley.Enigma.Simulator
{
    /// <summary>
    /// A four rotor scrambler that accepts three standard rotors, a thin additional rotor and a thin reflector
    /// </summary>
    public class Scrambler4 : Scrambler
    {
        public Scrambler4(Reflector reflector, Rotor additionalRotor, Rotor rotorL, Rotor rotorM, Rotor rotorR)
            : base(reflector, additionalRotor, rotorL, rotorM, rotorR, EntryWheel.EntryWheelDirect())
        {
        }
    }
}
