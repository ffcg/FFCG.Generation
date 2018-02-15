using System.Collections.Generic;
using System.Net.Http;
using FFCG.Weather.API.Data;
using FFCG.Weather.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FFCG.Weather.API.Import.Controllers
{
   
    [Route("api/import/smhi/stations")]
    public class ImportSmhiStationsController : ControllerBase
    {
        private readonly DbContextOptions<WeatherContext> _options;

        public ImportSmhiStationsController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherContext>();
            optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=GenerationWeather.EF;Integrated Security=SSPI;Trusted_Connection=yes;");
            _options = optionsBuilder.Options;
        }

        public IActionResult Post()
        {
            var httpClient = new HttpClient();

            var response = httpClient.GetStringAsync("https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1.json").Result;

            var root = JsonConvert.DeserializeObject<SmhiResponseObject>(response);

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

            using (var db = new WeatherContext(_options))
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Stations]");
                db.AddRange(weatherStations);
                db.SaveChanges();
            }

            return Ok("Import completed!");
        }
    }
}