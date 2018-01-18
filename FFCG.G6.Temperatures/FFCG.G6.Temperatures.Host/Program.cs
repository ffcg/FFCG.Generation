using System;
using System.Linq;

namespace FFCG.G6.Temperatures.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = CsvFileParser.ParseFile(@"D:\temp\temperatures.csv").ToList();
            Console.WriteLine($"Total number of entries: {entries.Count}");

            var analyzer = new TemperatureAnalyzer(entries);

            var firstEntryBelowZero = analyzer.FirstEntryBelowZero();
            var coldest = analyzer.ColdestEntry();
            var warmest = analyzer.WarmestEntry();

            Console.WriteLine($"First entry below zero: {firstEntryBelowZero}");
            Console.WriteLine($"Coldest: {coldest}");
            Console.WriteLine($"Warmest: {warmest}");

            var averages = analyzer.AveragePerDay();

            foreach (var averageTemp in averages)
            {
                Console.WriteLine($"{averageTemp.Date.ToShortDateString()}: {Math.Round(averageTemp.Average, 1)}");
            }
        }
    }
}
