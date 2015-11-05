using System.Collections.Generic;

namespace FFCG.G4.CardGame.Game
{
    public interface ICardPrinter
    {
        void Print(List<Card> cards);
    }
}