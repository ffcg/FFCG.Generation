using System;
using System.Collections.Generic;
using FFCG.Generation.Collector.Host.Presenters;

namespace FFCG.Generation.Collector.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var collector = new DataCollector();

            var consolePresenter = new ConsolePresenter();
            var filePresenter = new FilePresenter(@"d:\temp\persons.txt");
            var shoutingConsolePresenter = new ShoutingConsolePresenter();

            var multiplePresenter = new MultiplePresenter(new List<IPresenter>{ shoutingConsolePresenter, consolePresenter, filePresenter});
            
            while (true)
            {
                Console.Write("Enter your name: ");
                var name = Console.ReadLine();

                Console.Write("Enter your age: ");
                var age = int.Parse(Console.ReadLine());
                
                collector.CollectData(name, age);

                Console.Write("Add more? (y/n) ");
                var answer = Console.ReadKey();
                Console.WriteLine();

                if (answer.Key == ConsoleKey.N)
                {
                    break;
                }
            }
            collector.PresentData(multiplePresenter);

            Console.ReadLine();
        }
    }
}
