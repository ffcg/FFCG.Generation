using System;
using System.Collections.Generic;
using System.Linq;
using FFCG.G4.CardGame.Game;
using FFCG.G4.CardGame.Game.Shuffler;
using FFCG.G4.CardGame.Game.TypeOfDeckBuilder;

namespace FFCG.G4.CardGame.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck(new GuidShuffler(), new ANormalDeck());
            bool isStillRunning = true;
            int numberOfHands = 0;
            var consoleCardPrinter = new ConsoleCardPrinter();

            do
            {
                deck.Shuffle();
                var hand = deck.TakeOneHand();
              
                if (CheckIfHandHoldForAces(hand))
                {
                    var showCard = hand.Cards();
                    consoleCardPrinter.Print(showCard);
                    isStillRunning = false;
                }

                deck.Reset();
                deck.Shuffle();

                numberOfHands++;

            } while (isStillRunning);

            Console.WriteLine("DONE in {0}", numberOfHands);
            Console.ReadLine();
        }

        private static bool CheckIfHandHoldForAces(Hand currentHand)
        {
            return currentHand.Cards().Count(x => x.Name == CardNames.Ace) >= 4;
        }
    }

    public class ConsoleCardPrinter
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
