using System.Collections.Generic;
using FFCG.Weather.Models;

namespace FFCG.Weather.API.Repositories
{
    public class DummyStationRepository : IWeatherStationRepository
    {
        public WeatherStation Load(string id)
        {
            throw new System.NotImplementedException();
        }

        public WeatherStation Save(WeatherStation station)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<WeatherStation> All()
        {
            return new List<WeatherStation>
            {
                new WeatherStation
                {
                    Id = "1234",
                    Name = "Jens coola weather station"
                }
            };
        }

        public IEnumerable<TemperatureReading> GetReadingsByStationId(string id, int page = 1, int pageSize = 50)
        {
            throw new System.NotImplementedException();
        }
    }
}