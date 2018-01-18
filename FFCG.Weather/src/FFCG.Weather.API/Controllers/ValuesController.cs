using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FFCG.Weather.API.Controllers
{
    public class WeatherStationViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public float Altitude { get; set; }
    }

    [Route("api/[controller]")]
    public class StationsController : Controller
    {
        [HttpGet]
        public List<WeatherStationViewModel> Get()
        {
            string path = @"C:\dev\Education\FFCG.Weather\weather.data\stations";

            var json = System.IO.File.ReadAllText(path);

            var stations = JsonConvert.DeserializeObject<List<WeatherStationViewModel>>(json);

            return stations;
        }

        [HttpGet("{id}")]
        public WeatherStationViewModel Get(string id)
        {
            string path = @"C:\dev\Education\FFCG.Weather\weather.data\stations";

            var json = System.IO.File.ReadAllText(path);

            var stations = JsonConvert.DeserializeObject<List<WeatherStationViewModel>>(json);

            return stations.FirstOrDefault(x => x.Id == id);
        }
    }

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
