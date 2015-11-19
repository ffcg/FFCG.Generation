using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.CardGame.Game.Tests
{
    [TestFixture]
    public class CardTests
    {
        private Card _card;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
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