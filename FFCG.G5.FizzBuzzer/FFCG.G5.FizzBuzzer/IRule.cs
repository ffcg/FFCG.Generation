namespace FFCG.G5.FizzBuzzer
{
    public interface IRule
    {
        string Result { get; }
        bool Matches(int number);
    }
}