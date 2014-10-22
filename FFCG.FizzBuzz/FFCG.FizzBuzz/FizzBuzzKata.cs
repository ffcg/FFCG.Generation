using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FFCG.FizzBuzz.Rules;

namespace FFCG.FizzBuzz
{
    public class FizzBuzzKata : IFizzBuzzKata
    {
        private readonly IEnumerable<IDivisbleRule> _rules;

        public FizzBuzzKata(IEnumerable<IDivisbleRule> rules)
        {
            _rules = rules;
        }

        public string Answer(int number)
        {
            var words = _rules
                            .Where(rule => rule.Matches(number))
                            .Select(rule => rule.Word)
                            .ToList();

            if (words.Any())
                return string.Join("", words);

            return number.ToString();
        }
    }
}