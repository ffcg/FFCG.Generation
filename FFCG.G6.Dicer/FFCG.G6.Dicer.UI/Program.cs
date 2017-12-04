using System;

namespace FFCG.G6.Dicer.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dice with death!");

            var sides = 666;
            var game = new Game(new Dice(sides));

            Console.WriteLine($"Let's start playing - The dice has {sides} sides!");
            
            game.Start();

            while (game.IsPlaying)
            {
                Console.WriteLine("-----------------------------");
                PrintCurrentGameState(game);

                var guess = GetUserGuess();

                switch (guess)
                {
                    case ConsoleKey.UpArrow:
                        Console.WriteLine($"You guessed HIGHER than {game.LatestRoll}");
                        game.GuessHigher();
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine($"You guessed LOWER than {game.LatestRoll}");
                        game.GuessLower();
                        break;
                }
            }
            PrintCurrentGameState(game);

            Console.WriteLine($"\nGame over - Your score was {game.Score}");


        }

        private static ConsoleKey GetUserGuess()
        {
            Console.WriteLine("Press UP ARROW to guess higher and DOWN ARROW to guess lower");
            while (true)
            {
                var consoleKeyInfo = Console.ReadKey();
                Console.Write("\r");
                if (consoleKeyInfo.Key == ConsoleKey.UpArrow || consoleKeyInfo.Key == ConsoleKey.DownArrow)
                    return consoleKeyInfo.Key;
            }            
        }

        private static void PrintCurrentGameState(Game game)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Latest roll:{game.LatestRoll}");
            Console.ResetColor();
            Console.WriteLine($"Your score is: {game.Score}");
            
        }
    }
}
