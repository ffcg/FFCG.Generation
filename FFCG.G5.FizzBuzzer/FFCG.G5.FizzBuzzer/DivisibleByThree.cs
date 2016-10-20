namespace FFCG.G5.FizzBuzzer
{
    public class DivisibleByThree : IRule
    {
        public string Result { get { return "Fizz"; } }

        public bool Matches(int number)
        {
            if (number % 3 == 0)
                return true;

            return false;
        }
    }
}