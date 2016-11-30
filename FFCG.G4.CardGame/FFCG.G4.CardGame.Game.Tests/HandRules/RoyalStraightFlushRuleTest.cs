using FFCG.G4.CardGame.Game.HandRules;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.CardGame.Game.Tests.HandRules
{
    [TestFixture]
    public class RoyalStraightFlushRuleTest
    {
        [Test]
        public void Should_be_satisfied_if_hand_has_a_royal_straight_flush()
        {
            var rule = new RoyalStraightFlushRule();
            var hand = new Hand();
            hand.TakeCard(new Card(Suit.Club, CardNames.Ten, 10));
            hand.TakeCard(new Card(Suit.Club, CardNames.Jack, 11));
            hand.TakeCard(new Card(Suit.Club, CardNames.Queen, 12));
            hand.TakeCard(new Card(Suit.Club, CardNames.King, 13));
            hand.TakeCard(new Card(Suit.Club, CardNames.Ace, 14));
            var result = rule.CheckIfTheHandMeetsTheRequirements(hand);

            result.Should().BeTrue();
        }

        [Test]
        public void Should_not_be_satisfied()
        {
            var rule = new RoyalStraightFlushRule();
            var hand = new Hand();
            hand.TakeCard(new Card(Suit.Diamond, CardNames.Ten, 10));
            hand.TakeCard(new Card(Suit.Club, CardNames.Jack, 11));
            hand.TakeCard(new Card(Suit.Club, CardNames.Queen, 12));
            hand.TakeCard(new Card(Suit.Club, CardNames.King, 13));
            hand.TakeCard(new Card(Suit.Club, CardNames.Ace, 14));
            var result = rule.CheckIfTheHandMeetsTheRequirements(hand);

            result.Should().BeFalse();
        }
    }
}