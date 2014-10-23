using FluentAssertions;
using Forefront.CardGame.Game;
using NUnit.Framework;

namespace Forefront.CardGame.Tests
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Deck_should_contains_correct_number_of_cards()
        {
            var deck = new Deck();
            deck.NumberOfCards.Should().Be(52);
        }

        [Test]
        public void Should_be_able_to_reset_deck()
        {
            var deck = new Deck();
            deck.TakeOneHand();
            deck.Reset();
            deck.NumberOfCards.Should().Be(52);
        }

        [Test]
        public void Cards_should_be_removed_from_deck_after_a_hand_is_taken()
        {
            var deck = new Deck();
            deck.TakeOneHand();
            deck.NumberOfCards.Should().Be(47);
        }

        [Test]
        public void A_hand_from_deck_should_contains_5_cards()
        {
            var deck = new Deck();
            var hand = deck.TakeOneHand();
            hand.ShowCard().Should().HaveCount(5);
        }
    }
}
