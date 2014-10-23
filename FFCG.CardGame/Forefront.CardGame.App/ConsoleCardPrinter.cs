using System;
using System.Collections.Generic;
using Forefront.CardGame.Game;

namespace Forefront.CardGame.App
{
    public class ConsoleCardPrinter : ICardPrinter
    {
        public void Print(List<Card> cards)
        {
            Console.WriteLine("-----------------");
            foreach (var card in cards)
            {
                Console.WriteLine("{0} - {1}", card.Suit, card.Name);
                Console.WriteLine("-----------------");
            }

        }
    }
}