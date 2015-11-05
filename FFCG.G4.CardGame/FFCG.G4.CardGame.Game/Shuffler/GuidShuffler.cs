using System;
using System.Collections.Generic;
using System.Linq;

namespace FFCG.G4.CardGame.Game.Shuffler
{
    public class GuidShuffler : IShuffelCards
    {
        public List<Card> Shuffle(Stack<Card> cards)
        {
            return cards.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}