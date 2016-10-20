using System;
using FFCG.G5.FizzBuzzer;

namespace FFG.G5.FizzBuzzer.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            IRule[] rules = new IRule[]
            {
                new DivisibleByMultiple(new IRule[]
                {
                    new GenericDivisbleRule(2, "TWO"),
                    new GenericDivisbleRule(8, "FACE")
                }),
                new GenericDivisbleRule(3, "Fizz"),
                new GenericDivisbleRule(5, "Buzz")
            };

            var fizzBuzz = new FizzBuzz(rules);

            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(fizzBuzz.Execute(i));
            }
        }
    }
}
