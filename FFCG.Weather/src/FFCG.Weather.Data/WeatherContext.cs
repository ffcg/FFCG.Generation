using System;
using FFCG.Weather.Models;
using Microsoft.EntityFrameworkCore;

namespace FFCG.Weather.Data
{
    public class WeatherContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=GenerationWeather.EF;Integrated Security=SSPI;Trusted_Connection=yes;");
        }

        public DbSet<WeatherStation> Stations { get; set; }
    }
}
