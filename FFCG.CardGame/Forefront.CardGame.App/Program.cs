using System;
using System.Linq;
using System.Numerics;
using Forefront.CardGame.Game;

namespace Forefront.CardGame.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var deck = new Deck();
            bool isStillRunning = true;
            ICardPrinter cardPrinter = new ConsoleCardPrinter();

            do
            {
                switch (ShowMenu())
                {
                    case 1:
                        {
                            PrintNumberOfCards(deck);
                            break;
                        }
                    case 2:
                        {
                            Shuffle(deck);
                            break;
                        }
                    case 3:
                        {
                            ShowOneHand(deck, cardPrinter);
                            break;
                        }
                    case 4:
                        {
                            deck.Reset();
                            break;
                        }
                    case 5:
                        {
                            GiveMeTheBestHand(deck, cardPrinter);
                            break;
                        }
                    case 6:
                        {
                            isStillRunning = CheckIfTheUserWantsToCloseTheApplication();
                            break;
                        }
                }

            } while (isStillRunning);
        }

        private static void PrintNumberOfCards(Deck deck)
        {
            Console.WriteLine("Deck has {0} cards", deck.NumberOfCards);
        }

        private static void Shuffle(Deck deck)
        {
            deck.Shuffle();
            Console.WriteLine("Your deck is shuffled");
        }

        private static void ShowOneHand(Deck deck, ICardPrinter cardPrinter)
        {
            Hand hand = deck.TakeOneHand();
            cardPrinter.Print(hand.ShowCard());
        }

        private static void GiveMeTheBestHand(Deck deck, ICardPrinter cardPrinter)
        {
            BigInteger counter = 0;
            Hand currentHand;

            deck.Reset();
            deck.Shuffle();

            do
            {
                counter++;
                if (deck.NumberOfCards < 5)
                {
                    deck.Reset();
                    deck.Shuffle();
                }
                
                currentHand = deck.TakeOneHand();
                //Console.WriteLine(deck.NumberOfCards);
                if (counter%1000 == 0)
                    Console.WriteLine(counter);
            } while (!CheckIfIsTargetHand(currentHand));

            Console.WriteLine("I needed {0} times", counter);
            cardPrinter.Print(currentHand.ShowCard());
        }

        private static bool CheckIfTheUserWantsToCloseTheApplication()
        {
            Console.Write("Are you sure you want to exit? (Y/N): ");
            var yesOrNo = Console.ReadLine();
            return yesOrNo.ToLower() != "y";
        }

        private static int ShowMenu()
        {
            Console.WriteLine("**** Welcome to my card game ****");
            Console.WriteLine("*  1\tNumber of cards \t*");
            Console.WriteLine("*  2\tShuffle \t\t*");
            Console.WriteLine("*  3\tGive me my hand\t\t*");
            Console.WriteLine("*  4\tReset deck\t\t*");
            Console.WriteLine("*  5\tGive me a good hand\t*");
            Console.WriteLine("*  6\tExit\t\t\t*");
            Console.WriteLine("*********************************");

            string readLine = Console.ReadLine();

            return Convert.ToInt32(readLine);
        }

        private static bool CheckIfIsTargetHand(Hand currentHand)
        {
            return currentHand.ShowCard().GroupBy(x => x.Value).Select(grouping => grouping.Count() == 4).FirstOrDefault();
        }
    }
}

