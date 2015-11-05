using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.CardGame.Game.Tests
{
    [TestFixture]
    public class HandTests
    {
        [Test]
        public void Should_be_able_to_take_one_card()
        {
            var hand = new Hand();
            hand.TakeCard(new Card(Suit.Heart, CardNames.Ace, 14));
            var cards = hand.Cards();
            cards.Should().HaveCount(1);
        }

        [Test]
        public void Should_be_able_to_show_correct_cards()
        {
            var card = new Card(Suit.Heart, CardNames.Ace, 14);
            var hand = new Hand();
            hand.TakeCard(card);
            var cards = hand.Cards();
            cards[0].ShouldBeEquivalentTo(card);
        }
    }
}