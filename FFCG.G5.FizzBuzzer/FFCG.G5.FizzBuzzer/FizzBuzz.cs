using System.Linq;

namespace FFCG.G5.FizzBuzzer
{
    public class FizzBuzz
    {
        private readonly IRule[] _rules;

        public FizzBuzz(IRule[] rules)
        {
            _rules = rules;
        }

        public string Execute(int number)
        {
            var matchingRule = _rules.FirstOrDefault(x => x.Matches(number));

            if (matchingRule == null)
                return number.ToString();

            return matchingRule.Result;
        }
    }
}