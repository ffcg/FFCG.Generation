using System;

namespace FFCG.Generation.Collector.Host.Presenters
{
    public class ConsolePresenter: IPresenter
    {
        public void Present(string name, int age)
        {
            if (age < 18)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green; 
            }
            Console.WriteLine($"{name} {age}");
            Console.ResetColor();
        }
    }
}