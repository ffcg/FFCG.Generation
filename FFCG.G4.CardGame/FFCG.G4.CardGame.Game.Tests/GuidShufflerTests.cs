using System.Collections.Generic;
using System.Linq;
using FFCG.G4.CardGame.Game.Shuffler;
using NUnit.Framework;

namespace FFCG.G4.CardGame.Game.Tests
{
    [TestFixture]
    public class GuidShufflerTests
    {
        [Test]
        public void Should_be_able_to_shuffle()
        {
            var stackOfCards = new Stack<Card>();
            stackOfCards.Push(new Card(Suit.Heart, CardNames.Ace, 14));
            stackOfCards.Push(new Card(Suit.Heart, CardNames.King, 13));

            var guidShuffler = new GuidShuffler();
            var shuffle = guidShuffler.Shuffle(stackOfCards);
            var firstValue = shuffle.First().Value;
            
            Assert.That(firstValue == 13 || firstValue == 14);
        }
    }
}