using System.Collections.Generic;
using System.Linq;
using FFCG.G4.CardGame.Game.TypeOfDeckBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.CardGame.Game.Tests
{
    [TestFixture]
    public class ANormalDeckTests
    {
        private IEnumerable<Card> _allAvailableCardsInADeck;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            var aNormalDeck = new ANormalDeck();
            _allAvailableCardsInADeck = aNormalDeck.CreateAllAvailableCardsInADeck();
        }

        [Test]
        public void Should_have_correct_number_of_cards()
        {
            _allAvailableCardsInADeck.Should().HaveCount(52);
        }

        [Test]
        public void Should_have_correct_number_of_suits()
        {
            _allAvailableCardsInADeck.GroupBy(x => x.Suit).Should().HaveCount(4);
        }

        [Test]
        public void Number_of_hearts_should_be_correct()
        {
            _allAvailableCardsInADeck.Where(x => x.Suit == Suit.Heart).Should().HaveCount(13);
        }

        [Test]
        public void Number_of_clubs_should_be_correct()
        {
            _allAvailableCardsInADeck.Where(x => x.Suit == Suit.Club).Should().HaveCount(13);
        }

        [Test]
        public void Number_of_diamonds_should_be_correct()
        {
            _allAvailableCardsInADeck.Where(x => x.Suit == Suit.Diamond).Should().HaveCount(13);
        }

        [Test]
        public void Number_of_spades_should_be_correct()
        {
            _allAvailableCardsInADeck.Where(x => x.Suit == Suit.Spades).Should().HaveCount(13);
        }
    }
}