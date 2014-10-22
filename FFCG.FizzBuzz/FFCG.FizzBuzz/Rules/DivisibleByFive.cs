namespace FFCG.FizzBuzz.Rules
{
    public class DivisibleByFive : IDivisbleRule
    {
        public bool Matches(int number)
        {
            return number % 5 == 0;
        }

        public string Word { get { return "buzz"; } }
    }
}