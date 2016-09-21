namespace Bletchley.Enigma.Simulator
{
    public interface IEnigma
    {
        string GetOutput(string text);
        Letters GetOutput(Letters input);
    }
}