using System;
using System.Collections.Generic;
using System.Linq;

namespace Forefront.CardGame.Game
{
    public class Deck
    {
        private readonly Stack<Card> _cards;
        public int NumberOfCards {  get { return _cards.Count(); }}

        private readonly List<Suit> _allSuits;
        private readonly List<CardName> _allCardNames;

        public Deck()
        {
            _cards = new Stack<Card>();
            _allCardNames = Enum.GetValues(typeof(CardName)).Cast<CardName>().ToList();
            _allSuits = Enum.GetValues(typeof (Suit)).Cast<Suit>().ToList();
            
            Reset();
        }

        public void Reset()
        {
            _cards.Clear();
           
            foreach (var suit in _allSuits)
            {
                var counter = 2;
                foreach (var cardName in _allCardNames)
                {
                    _cards.Push(new Card(suit, cardName, counter));
                    counter++;
                }
            }
        }

        public void Shuffle()
        {
            var cards = _cards.OrderBy(x => Guid.NewGuid()).ToList();
            _cards.Clear();

            foreach (var card in cards)
                _cards.Push(card);
        }

        public void AddCards(List<Card> cards)
        {
            foreach (var card in cards)
            {
                _cards.Push(card);
            }
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
