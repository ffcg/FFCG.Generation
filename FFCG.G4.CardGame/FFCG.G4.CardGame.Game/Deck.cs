using System.Collections.Generic;
using System.Linq;
using FFCG.G4.CardGame.Game.Shuffler;
using FFCG.G4.CardGame.Game.TypeOfDeckBuilder;

namespace FFCG.G4.CardGame.Game
{
    public class Deck
    {
        private readonly IShuffelCards _cardShuffler;
        private readonly ICreateASetOfCards _setOfCards;
        private readonly Stack<Card> _cards;
        public int NumberOfCards { get { return _cards.Count(); } }

        public Deck(IShuffelCards cardShuffler, ICreateASetOfCards setOfCards)
        {
            _cardShuffler = cardShuffler;
            _setOfCards = setOfCards;
            _cards = new Stack<Card>();

            Reset();
        }

        public void Reset()
        {
            var allCards = _setOfCards.CreateAllAvailableCardsInADeck().ToList();

            _cards.Clear();
            allCards.ForEach(_cards.Push);
        }

        public void Shuffle()
        {
            var cards = _cardShuffler.Shuffle(_cards).ToList();
            _cards.Clear();

            foreach (var card in cards)
                _cards.Push(card);
        }

        public Hand TakeOneHand()
        {
            var hand = new Hand();
            for (var i = 0; i < 5; i++)
                hand.TakeCard(_cards.Pop());

            return hand;
        }
    }
}
