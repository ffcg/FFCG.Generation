namespace FFCG.FizzBuzz.Rules
{
    public class DivisibleByThree : IDivisbleRule
    {
        public bool Matches(int number)
        {
            return number % 3 == 0;
        }

        public string Word { get { return "fizz"; } }
    }
}