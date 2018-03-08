using FFCG.Weather.API.Import.Controllers;
using FFCG.Weather.Models;
using Microsoft.EntityFrameworkCore;

namespace FFCG.Weather.API.Data
{
    public class WeatherContext : DbContext
    {
        public DbSet<WeatherStation> Stations { get; set; }
        public DbSet<TemperatureReading> TemperatureReadings { get; set; }

        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TemperatureReading>()
                .HasOne(x => x.Station);
        }
    }
}
