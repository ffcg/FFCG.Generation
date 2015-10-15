using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFCG.G4.FizzBuzzKata.Gui
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzz = new FizzBuzz();
            for (int i = 1; i <= 100; i++)
            {
                var result = fizzBuzz.GetResult(i);
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
