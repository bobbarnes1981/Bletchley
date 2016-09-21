namespace Bletchley.Enigma.Simulator
{
    public class ScramblerK : Scrambler
    {
        private EntryWheel m_entryWheel;

        public ScramblerK(ReflectorK reflector, Rotor rotorL, Rotor rotorM, Rotor rotorR, EntryWheel entryWheel)
            : base(reflector, rotorL, rotorM, rotorR)
        {
            m_entryWheel = entryWheel;
        }

        public virtual Letters GetOutput(Letters input)
        {
            input = m_entryWheel.GetInput(input);

            Letters output = base.GetOutput(input);

            output = m_entryWheel.GetOutput(output);

            return output;
        }
    }
}
