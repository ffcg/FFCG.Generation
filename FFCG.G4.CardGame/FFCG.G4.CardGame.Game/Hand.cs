using System.Collections.Generic;

namespace FFCG.G4.CardGame.Game
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

        public List<Card> Cards()
        {
            return _cards;
        }
    }
}