using System;
using System.Collections.Generic;
using System.Linq;

namespace FFCG.G4.CardGame.Game.TypeOfDeckBuilder
{
    public class ANormalDeck : ICreateASetOfCards
    {
        public IEnumerable<Card> CreateAllAvailableCardsInADeck()
        {
            var allCardNames = Enum.GetValues(typeof(CardNames)).Cast<CardNames>().ToList();
            var allSuits = Enum.GetValues(typeof(Suit)).Cast<Suit>().ToList();

            foreach (var suit in allSuits)
            {
                var counter = 1;
                foreach (var cardName in allCardNames)
                {
                    counter++;
                    yield return new Card(suit, cardName, counter);
                }
            }
        }
    }
}