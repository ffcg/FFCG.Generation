using System.Collections.Generic;
using System.Linq;
using FFCG.Weather.API.Data;
using FFCG.Weather.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FFCG.Weather.API.Controllers
{
    [Route("api/[controller]")]
    public class StationsController : Controller
    {
        private readonly DbContextOptions<WeatherContext> _options;

        public StationsController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherContext>();
            optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=GenerationWeather.EF;Integrated Security=SSPI;Trusted_Connection=yes;");
            _options = optionsBuilder.Options;
        }

        [HttpGet]
        public List<WeatherStation> Get()
        {
            using (var db = new WeatherContext(_options))
            {
                return db.Stations.OrderBy(x => x.Name).ToList();
            }
        }

        [HttpGet("{id}")]
        public WeatherStation Get(string id)
        { 
            using (var db = new WeatherContext(_options))
            {
                return db.Stations.FirstOrDefault(x => x.Id == id); 
            }    
        }
    }
}
