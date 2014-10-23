using System.Collections.Generic;

namespace Forefront.CardGame.Game
{
    public interface ICardPrinter
    {
        void Print(List<Card> cards);
    }
}