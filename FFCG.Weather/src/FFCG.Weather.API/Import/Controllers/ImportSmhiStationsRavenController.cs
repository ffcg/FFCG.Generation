using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FFCG.Weather.API.Data;
using FFCG.Weather.Models;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace FFCG.Weather.API.Import.Controllers
{
    [Route("api/import_raven/smhi/stations")]
    public class ImportSmhiStationsRavenController : ControllerBase
    {
        private readonly IDocumentStore _store;
        private readonly IStationsDownloader _stationsDownloader;

        public ImportSmhiStationsRavenController(IDocumentStore store, IStationsDownloader stationsDownloader)
        {
            _store = store;
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

            var stopwatch = Stopwatch.StartNew();
            using (var session = _store.OpenAsyncSession())
            {
                foreach (var weatherStation in weatherStations)
                {
                    await session.StoreAsync(weatherStation);
                }

                await session.SaveChangesAsync();
            }

            stopwatch.Stop();

            return Ok($"Import completed - Took: {stopwatch.Elapsed}");
        }
    }

    [Route("api/import_raven/smhi/stations")]
    public class ImportSmhiReadingsRavenContainer : ControllerBase
    {
        private readonly IDocumentStore _store;

        public ImportSmhiReadingsRavenContainer(IDocumentStore store)
        {
            _store = store;
        }

        [HttpPost]
        [Route("{id}/readings")]
        public async Task<IActionResult> Post(string id)
        {
            WeatherStation station;
            using (var session = _store.OpenAsyncSession())
            {
                station = await session.LoadAsync<WeatherStation>(id);

                if (station == null)
                    return BadRequest($"No station found with id: {id}");
            }


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

                return new TemperatureReadingRaven
                {
                    StationId = station.Id,
                    Date = dateTime,
                    Temperature = temperatureValue
                };
            }).ToList();

            var stopwatch = Stopwatch.StartNew();

            using (var session = _store.BulkInsert())
            {
                foreach (var temperatureReading in readings)
                {
                    await session.StoreAsync(temperatureReading);
                }
            }
            
            stopwatch.Stop();
            return Ok($"Import complete - Took: {stopwatch.Elapsed}");
        }

    }
}

public class TemperatureReadingRaven
{
    public string Id { get; set; }
    public string StationId { get; set; }
    public DateTime Date { get; set; }
    public double Temperature { get; set; }
}
