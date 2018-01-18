using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using FFCG.Weather.Models;
using Newtonsoft.Json;

namespace FFCG.Weather.Importer
{
    class Program
    {
        static void Main(string[] args)
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

            var json = JsonConvert.SerializeObject(weatherStations);

            File.WriteAllText(@"C:\dev\Education\FFCG.Weather\weather.data\stations", json);
        }
    }


    public class SmhiResponseObject
    {
        public Station[] station { get; set; }
    }

    public class Station
    {
        public string name { get; set; }
        public int id { get; set; }
        public float height { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
}
