using System.Collections.Generic;
using System.Linq;

namespace FFCG.G6.Temperatures
{
    public class TemperatureAnalyzer
    {
        private readonly IEnumerable<DateTempEntry> _entries;

        public TemperatureAnalyzer(IEnumerable<DateTempEntry> entries)
        {
            _entries = entries;
        }

        public DateTempEntry FirstEntryBelowZero()
        {
            return _entries.OrderBy(x => x.When).FirstOrDefault(x => x.Temperature < 0);
        }

        public DateTempEntry ColdestEntry()
        {
            return _entries.OrderBy(x => x.Temperature).FirstOrDefault();
        }

        public DateTempEntry WarmestEntry()
        {
            return _entries.OrderByDescending(x => x.Temperature).FirstOrDefault();
        }

        public IEnumerable<AverageTemp> AveragePerDay()
        {
            return _entries.GroupBy(x => x.When.Date)
                .Select(a => new AverageTemp { Date = a.Key, Average = a.Average(entry => entry.Temperature) })
                .OrderBy(x => x.Date);
        }
    }
}