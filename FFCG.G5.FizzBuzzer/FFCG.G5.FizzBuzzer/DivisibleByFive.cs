namespace FFCG.G5.FizzBuzzer
{
    public class DivisibleByFive : IRule
    {
        public string Result { get { return "Buzz"; } }

        public bool Matches(int number)
        {
            if (number % 5 == 0)
                return true;

            return false;
        }
    }
}