using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FFCG.G4.CardGame.Game;
using FFCG.G4.CardGame.Game.HandRules;
using FFCG.G4.CardGame.Game.Shuffler;
using FFCG.G4.CardGame.Game.TypeOfDeckBuilder;

namespace FFCG.G4.CardGame.App
{
    class Program
    {
        private static readonly JudgeRoslin JudgeRoslin = new JudgeRoslin(new List<IHandRule> {new RoyalStraightFlushRule(), new FiveCardRule(), new NothingRule()});

        static void Main(string[] args)
        {

            var deck = new Deck(new GuidShuffler(), new ANormalDeck());
            deck.Shuffle();
            var hand = deck.TakeOneHand();
            var check = JudgeRoslin.Check(hand);
            Console.WriteLine(check);


            //var consoleCardPrinter = new ConsoleCardPrinter();

            //var stopwatch = new Stopwatch();
            //stopwatch.Start();
            //Console.WriteLine("SLOW...");
            //var numberOfHands = Slow(consoleCardPrinter);
            //stopwatch.Stop();
            //Console.WriteLine("DONE in {0} - {1}", stopwatch.Elapsed, numberOfHands);

            //stopwatch.Reset();
            //stopwatch.Start();
            //Console.WriteLine("FAST...");
            //numberOfHands = Fast(consoleCardPrinter);
            //stopwatch.Stop();

            //Console.WriteLine("DONE in {0} - {1}", stopwatch.Elapsed, numberOfHands);
            //Console.ReadLine();
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

                if (IsRoyalStraightFlush(hand))
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

        private static bool IsRoyalStraightFlush(Hand hand)
        {
            return JudgeRoslin.Check(hand) == "Royal Straight Flush!";
        }

        private static int Fast(ConsoleCardPrinter consoleCardPrinter)
        {
            int numberOfHands = 0;
            bool isStillRunning = true;
            While(new ParallelOptions {MaxDegreeOfParallelism = 5}, () => isStillRunning, state =>
            {
                var deck = new Deck(new GuidShuffler(), new ANormalDeck());
                deck.Shuffle();
                var hand = deck.TakeOneHand();

                if (IsRoyalStraightFlush(hand))
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
