using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FFCG.G6.Temperatures
{
    public static class CsvFileParser
    {
        public static IEnumerable<DateTempEntry> ParseFile(string filePath)
        {
            var lines = File.ReadAllLines(@"C:\Users\jens.pettersson\Dropbox\Jobb\Education\temps.csv").Skip(1).ToList();
            var entries = new List<DateTempEntry>();
            foreach (var line in lines)
            {
                var strings = line.Split(';').Select(x => x.Trim('"')).ToArray();
                long secondsFromEpoch = long.Parse(strings[0]);
                decimal temperature = decimal.Parse(strings[1].Replace('.', ','));

                var dateTempEntry = new DateTempEntry(secondsFromEpoch, temperature);
                entries.Add(dateTempEntry);
            }

            return entries;
        }
    }
}
