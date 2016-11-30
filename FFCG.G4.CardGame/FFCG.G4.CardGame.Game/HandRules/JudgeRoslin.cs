using System;
using System.Collections.Generic;

namespace FFCG.G4.CardGame.Game.HandRules
{
    public class JudgeRoslin : IJudge
    {
        private readonly List<IHandRule> _rules;

        public JudgeRoslin(List<IHandRule> rules)
        {
            _rules = rules;
        }

        public string Check(Hand hand)
        {
            foreach (var rule in _rules)
            {
                if (rule.CheckIfTheHandMeetsTheRequirements(hand))
                    return rule.Name;
            }

            throw new Exception("No match");
        }
    }
}