namespace FFCG.G5.FizzBuzzer
{
    public class GenericDivisbleRule : IRule
    {
        private readonly int _divisbleBy;

        public GenericDivisbleRule(int divisbleBy, string result)
        {
            _divisbleBy = divisbleBy;
            Result = result;
        }

        public string Result { get; }
        public bool Matches(int number)
        {
            return number%_divisbleBy == 0;
        }
    }
}