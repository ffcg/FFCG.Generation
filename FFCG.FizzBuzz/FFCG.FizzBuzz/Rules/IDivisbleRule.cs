namespace FFCG.FizzBuzz.Rules
{
    public interface IDivisbleRule
    {
        bool Matches(int number);
        string Word { get; }
    }
}