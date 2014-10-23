using System.Collections.Generic;

namespace Forefront.CardGame.Game
{
    public class Hand
    {
        private readonly List<Card> _cards;

        public Hand()
        {
            _cards = new List<Card>(5);
        }

        public void TakeCard(Card card)
        {
            _cards.Add(card);
        }

        public List<Card> ShowCard()
        {
            return _cards;
        }
    }
}