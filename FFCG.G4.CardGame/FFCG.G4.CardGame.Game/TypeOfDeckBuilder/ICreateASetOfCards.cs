using System.Collections.Generic;

namespace FFCG.G4.CardGame.Game.TypeOfDeckBuilder
{
    public interface ICreateASetOfCards
    {
        IEnumerable<Card> CreateAllAvailableCardsInADeck();
    }
}