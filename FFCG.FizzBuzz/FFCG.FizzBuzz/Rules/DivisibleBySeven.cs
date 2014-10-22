namespace FFCG.FizzBuzz.Rules
{
    public class DivisibleBySeven : IDivisbleRule
    {
        public bool Matches(int number)
        {
            return number % 7 == 0;
        }

        public string Word { get { return "dizz"; } }
    }
}