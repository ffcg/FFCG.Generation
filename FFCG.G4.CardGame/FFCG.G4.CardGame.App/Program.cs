using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FFCG.G4.CardGame.Game;
using FFCG.G4.CardGame.Game.Shuffler;
using FFCG.G4.CardGame.Game.TypeOfDeckBuilder;

namespace FFCG.G4.CardGame.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleCardPrinter = new ConsoleCardPrinter();
            bool isStillRunning = true;
            int numberOfHands = 0;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("SLOW...");
            numberOfHands = Slow(consoleCardPrinter);
            stopwatch.Stop();
            Console.WriteLine("DONE in {0} - {1}", stopwatch.Elapsed, numberOfHands);
            
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("FAST...");
            numberOfHands = Fast(consoleCardPrinter);
            stopwatch.Stop();

            Console.WriteLine("DONE in {0} - {1}", stopwatch.Elapsed, numberOfHands);
            Console.ReadLine();
        }

        private static int Slow(ConsoleCardPrinter consoleCardPrinter)
        {
            bool isStillRunning = true;
            int numberOfHands = 0;
            var deck = new Deck(new GuidShuffler(), new ANormalDeck());
            do
            {
                deck.Shuffle();
                var hand = deck.TakeOneHand();

                if (CheckIfHandHoldFourAces(hand))
                {
                    var cards = hand.Cards();
                    consoleCardPrinter.Print(cards);
                    isStillRunning = false;
                }

                deck.Reset();

                numberOfHands++;
            } while (isStillRunning);

            return numberOfHands;
        }

        private static int Fast(ConsoleCardPrinter consoleCardPrinter)
        {
            int numberOfHands = 0;
            bool isStillRunning = true;
            While(new ParallelOptions {MaxDegreeOfParallelism = 5}, () => { return isStillRunning; }, state =>
            {
                var deck = new Deck(new GuidShuffler(), new ANormalDeck());
                deck.Shuffle();
                var hand = deck.TakeOneHand();

                if (CheckIfHandHoldFourAces(hand))
                {
                    var cards = hand.Cards();
                    consoleCardPrinter.Print(cards);
                    isStillRunning = false;
                }

                deck.Reset();

                numberOfHands++;
            });

            return numberOfHands;
        }

        public static void While(ParallelOptions parallelOptions, Func<bool> condition, Action<ParallelLoopState> body)
        {
            Parallel.ForEach(Infinite(), parallelOptions, (ignored, loopState) =>
            {
                if (condition()) body(loopState);
                else loopState.Stop();
            });
        }

        private static IEnumerable<bool> Infinite()
        {
            while (true) yield return true;
        }

        private static bool CheckIfHandHoldFourAces(Hand currentHand)
        {
            foreach (var suite in currentHand.Cards().GroupBy(x => x.Suit))
            {
                if (suite.Count(x => x.Value > 9) == 5)
                    return true;
            }
            return false;
            //return currentHand.Cards().Count(x => x.Name == CardNames.Ace) == 4;
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
