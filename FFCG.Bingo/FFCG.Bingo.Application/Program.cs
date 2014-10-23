using System;
using System.Collections.Generic;

namespace FFCG.Bingo.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = 15;
            var card = new Card(rows);

            var numbers = Randomizer.Randomize(1, rows*5);
            var stack = new Stack<int>(numbers);
            int currentNumber = 0;
            while (true)
            {
                PrintCard(card);
                if(currentNumber != 0)
                    Console.WriteLine("Current number: {0}", currentNumber);

                Console.Write("Press any key to draw new number");
                Console.ReadKey();

                currentNumber = stack.Pop();
                card.Check(currentNumber);

                if (card.IsBingo())
                {
                    PrintCard(card);
                    var originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("BINGO!");
                    Console.ForegroundColor = originalColor;
                    break;
                }
            }

            while (true)
            {
                
            }
            
        }

        private static void PrintCard(Card card)
        {
            Console.Clear();

            Console.WriteLine("B\tI\tN\tG\tO");
            Console.WriteLine("----------------------------------");
            foreach (var row in card.GetAllRows())
            {
                foreach (var square in row.Squares)
                {
                    if(square.Checked)
                    {
                        var originalColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(square + "\t");
                        Console.ForegroundColor = originalColor;
                        
                    }
                    else
                    {
                        Console.Write(square + "\t");    
                    }
                    
                }
                Console.Write("\n");
            }
            Console.WriteLine("----------------------------------");
        }
    }
}
