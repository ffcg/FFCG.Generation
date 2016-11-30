using FFCG.G4.CardGame.Game.HandRules;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.CardGame.Game.Tests.HandRules
{
    [TestFixture]
    public class FiveCardRuleTests
    {
        [Test]
        public void Should_be_satisfied_if_hand_contains_five_cards()
        {
            var fiveCardRule = new FiveCardRule();
            var hand = new Hand();
            hand.TakeCard(new Card(Suit.Club, CardNames.Ace, 1));
            hand.TakeCard(new Card(Suit.Club, CardNames.Ace, 1));
            hand.TakeCard(new Card(Suit.Club, CardNames.Ace, 1));
            hand.TakeCard(new Card(Suit.Club, CardNames.Ace, 1));
            hand.TakeCard(new Card(Suit.Club, CardNames.Ace, 1));
            var result = fiveCardRule.CheckIfTheHandMeetsTheRequirements(hand);

            result.Should().BeTrue();
        }

        [Test]
        public void Should_not_be_satisfied()
        {
            var fiveCardRule = new FiveCardRule();
            var hand = new Hand();
            hand.TakeCard(new Card(Suit.Club, CardNames.Ace, 1));
            hand.TakeCard(new Card(Suit.Club, CardNames.Ace, 1));
            hand.TakeCard(new Card(Suit.Club, CardNames.Ace, 1));
            hand.TakeCard(new Card(Suit.Club, CardNames.Ace, 1));
            var result = fiveCardRule.CheckIfTheHandMeetsTheRequirements(hand);

            result.Should().BeFalse();
        }
    }
}