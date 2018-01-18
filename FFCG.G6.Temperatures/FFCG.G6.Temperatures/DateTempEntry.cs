using System;

namespace FFCG.G6.Temperatures
{
    public class DateTempEntry
    {
        private readonly long _seconds;
        public DateTime When => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(_seconds);
        public decimal Temperature { get; }

        public DateTempEntry(long seconds, decimal temperature)
        {
            _seconds = seconds;
            Temperature = temperature;
        }

        public override string ToString()
        {
            return $"{When}: {Temperature}";
        }
    }
}