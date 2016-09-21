namespace Bletchley.Enigma.Simulator
{
    public interface IReflector
    {
        Letters GetOutput(Letters input);
    }
}