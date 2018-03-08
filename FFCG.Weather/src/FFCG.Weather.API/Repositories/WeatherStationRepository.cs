using System.Collections.Generic;
using System.Linq;
using FFCG.Weather.API.Data;
using FFCG.Weather.Models;
using Microsoft.EntityFrameworkCore;

namespace FFCG.Weather.API.Repositories
{
    public class WeatherStationRepository : IWeatherStationRepository
    {
        private readonly WeatherContext _db;

        public WeatherStationRepository(WeatherContext db)
        {
            _db = db;
        }

        public WeatherStation Load(string id)
        {
            return _db.Stations.FirstOrDefault(x => x.Id == id);
        }

        public WeatherStation Save(WeatherStation station)
        {
            _db.Stations.Add(station);
            _db.SaveChanges();

            return station;
        }

        public IEnumerable<WeatherStation> All()
        {
            return _db.Stations.ToList();
        }

        public IEnumerable<TemperatureReading> GetReadingsByStationId(string id, int page = 1, int pageSize = 50)
        {
            return _db.TemperatureReadings
                .Where(x => x.Station.Id == id)
                .OrderByDescending(x => x.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}