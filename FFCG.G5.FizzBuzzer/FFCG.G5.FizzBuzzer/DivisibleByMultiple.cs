using System.Linq;

namespace FFCG.G5.FizzBuzzer
{
    public class DivisibleByMultiple : IRule
    {
        private readonly IRule[] _rules;

        public DivisibleByMultiple(IRule[] rules)
        {
            _rules = rules;
        }

        public string Result { get { return string.Join("", _rules.Select(r => r.Result)); } }

        public bool Matches(int number)
        {
            if (_rules.All(rule => rule.Matches(number)))
            {
                return true;
            }

            return false;
        }
    }
}