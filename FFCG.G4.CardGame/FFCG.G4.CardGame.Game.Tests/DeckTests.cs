using System.Collections.Generic;
using System.Linq;
using FFCG.G4.CardGame.Game.Shuffler;
using FFCG.G4.CardGame.Game.TypeOfDeckBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.CardGame.Game.Tests
{
    [TestFixture]
    public class DeckTests
    {
        private ICreateASetOfCards _setOfCards;
        private IShuffelCards _shuffelCards;
        private Deck _deck;

        [SetUp]
        public void SetUp()
        {
            _setOfCards = new ANormalDeck();
            _shuffelCards = new TestShuffler();
            _deck = new Deck(_shuffelCards, _setOfCards);
        }

        [Test]
        public void Deck_should_contains_correct_number_of_cards()
        {
            _deck.NumberOfCards.Should().Be(52);
        }

        [Test]
        public void Should_be_able_to_reset_deck()
        {
            _deck.TakeOneHand();
            _deck.Reset();
            _deck.NumberOfCards.Should().Be(52);
        }

        [Test]
        public void Shuld_be_able_to_shuffle_deck()
        {
            _deck.Shuffle();
            var hand = _deck.TakeOneHand();
            var showCard = hand.Cards();
            showCard.First().Value.Should().Be(14);
        }

        [Test]
        public void Cards_should_be_removed_from_deck_after_a_hand_is_taken()
        {
            _deck.TakeOneHand();
            _deck.NumberOfCards.Should().Be(47);
        }

        [Test]
        public void A_hand_from_deck_should_contains_5_cards()
        {
            var hand = _deck.TakeOneHand();
            hand.Cards().Should().HaveCount(5);
        }

        public class TestShuffler : IShuffelCards
        {
            public List<Card> Shuffle(IEnumerable<Card> cards)
            {
                return cards.OrderBy(x => x.Value).ThenBy(x => x.Suit).ToList();
            }
        }
    }
}
