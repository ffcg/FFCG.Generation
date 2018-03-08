using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FFCG.Weather.API.Data;
using FFCG.Weather.Models;
using Microsoft.AspNetCore.Mvc;

namespace FFCG.Weather.API.Import.Controllers
{
    [Route("api/import/smhi/stations")]
    public class ImportSmhiStationsController : ControllerBase
    {
        private readonly WeatherContext _db;
        private readonly IStationsDownloader _stationsDownloader;
        
        public ImportSmhiStationsController(WeatherContext db, IStationsDownloader stationsDownloader)
        {
            _db = db;
            _stationsDownloader = stationsDownloader;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var root = await _stationsDownloader.Download();
            
            var weatherStations = new List<WeatherStation>();

            foreach (var station in root.station)
            {
                var weatherStation = new WeatherStation
                {
                    Id = station.id.ToString(),
                    Name = station.name,
                    Altitude = station.height,
                    Latitude = station.latitude,
                    Longitude = station.longitude
                };

                weatherStations.Add(weatherStation);
            }
            
            _db.AddRange(weatherStations);
            _db.SaveChanges();

            return Ok("Import completed!");
        }
    }

    [Route("api/import/smhi/stations")]
    public class ImportSmhiReadingsContainer : ControllerBase
    {
        private readonly WeatherContext _context;

        public ImportSmhiReadingsContainer(WeatherContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("{id}/readings")]
        public async Task<IActionResult> Post(string id)
        {
            var station = await _context.Stations.FindAsync(id);

            if (station == null)
                return BadRequest($"No station found with id: {id}");

            string url = $"https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1/station/{id}/period/corrected-archive/data.csv";

            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);

            var readings = response.Split('\n').Skip(10).Where(line => line.Length > 0).Select(line =>
            {
                var row = line.Split(';');
               
                var date = row[0];
                var time = row[1];
                var temperature = row[2];

                var couldParse = DateTime.TryParse(date + " " + time, out var dateTime);
                if (!couldParse)
                    return null;

                var temperatureValue = double.Parse(temperature.Replace('.', ','));

                return new TemperatureReading
                {
                    Station = station,
                    Date = dateTime,
                    Temperature = temperatureValue
                };
            }).ToList();
            
            await _context.TemperatureReadings.AddRangeAsync(readings.Where(x => x != null));
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}