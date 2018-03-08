using System;

namespace FFCG.Weather.Models
{
    public class TemperatureReading
    {
        public int Id { get; set; }
        public WeatherStation Station {get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
    }
}