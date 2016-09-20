namespace Bletchley.Enigma.Simulator
{
    public class Scrambler
    {
        private readonly Reflector m_reflector;

        private readonly Rotor m_rotorL;

        private readonly Rotor m_rotorM;

        private readonly Rotor m_rotorR;

        public Scrambler(Reflector reflector, Rotor rotorL, Rotor rotorM, Rotor rotorR)
        {
            m_reflector = reflector;
            m_rotorL = rotorL;
            m_rotorM = rotorM;
            m_rotorR = rotorR;
        }

        public Letters GetOutput(Letters input)
        {
            // rotate if required

            bool stepM = m_rotorR.InNotch;
            bool stepML = m_rotorM.InNotch;

            // left rotor always moves one step
            m_rotorR.Rotate();

            // moving from left notch moves middle rotor on a step
            if (stepM)
            {
                m_rotorM.Rotate();
            }

            // moving from middle notch moves middle and left rotor on a step (middle does a double step) 
            if (stepML)
            {
                // double step middle rotor
                m_rotorM.Rotate();
                m_rotorL.Rotate();
            }

            // right to left

            Letters rotorRleft = m_rotorR.GetLeft(input);

            Letters rotorMLeft = m_rotorM.GetLeft(rotorRleft);

            Letters rotorLLeft = m_rotorL.GetLeft(rotorMLeft);

            // reflector

            rotorLLeft = m_reflector.GetOutput(rotorLLeft);

            // left to right

            rotorMLeft = m_rotorL.GetRight(rotorLLeft);

            rotorRleft = m_rotorM.GetRight(rotorMLeft);

            Letters output = m_rotorR.GetRight(rotorRleft);

            return output;
        }
    }
}
