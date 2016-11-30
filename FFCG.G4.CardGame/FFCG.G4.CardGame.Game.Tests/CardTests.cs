using System;
using System.Collections.Generic;
using FFCG.G4.CardGame.Game.HandRules;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.CardGame.Game.Tests
{
    [TestFixture]
    public class JudgeRoslinTests
    {
        [Test]
        public void Should_return_first_satisfied_rule_name()
        {
            var judgeRoslin = new JudgeRoslin(new List<IHandRule> { new FakeRule(false, "false"), new FakeRule(true, "TrueRule") });

            var ruleName = judgeRoslin.Check(new Hand());

            ruleName.Should().Be("TrueRule");
        }
        

        public class FakeRule : IHandRule
        {
            private readonly bool _result;
            private string _name;

            public FakeRule(bool result, string name)
            {
                _name = name;
                _result = result;
            }
            public string Name
            {
                get { return _name; }
            }

            public bool CheckIfTheHandMeetsTheRequirements(Hand hand)
            {
                return _result;
            }
        }
    }

    [TestFixture]
    public class CardTests
    {
        private Card _card;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _card = new Card(Suit.Heart, CardNames.Ace, 13);
        }

        [Test]
        public void Value_should_be_set()
        {
            _card.Value.Should().Be(13);
        }

        [Test]
        public void Suit_should_be_set()
        {
            _card.Suit.Should().Be(Suit.Heart);
        }

        [Test]
        public void Name_should_be_set()
        {
            _card.Name.Should().Be(CardNames.Ace);
        }

        [Test]
        public void ToString_should_have_correct_format()
        {
            _card.ToString().Should().Be("Heart - Ace - 13");
        }
    }
}