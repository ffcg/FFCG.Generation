using System.Collections.Generic;
using System.Data.SqlClient;
using FFCG.Weather.Models;
using Microsoft.AspNetCore.Mvc;

namespace FFCG.Weather.API.Controllers
{
    [Route("api/[controller]")]
    public class StationsController : Controller
    {
        [HttpGet]
        public List<WeatherStation> Get()
        {
            //This is a prime candidate for refactoring later...
            var connectionString =
                "Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=GenerationWeather;Integrated Security=SSPI;Trusted_Connection=yes;";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Stations";
            var reader = command.ExecuteReader();

            var results = new List<WeatherStation>();
            while (reader.Read())
            {
                var weatherStation = MapToModel(reader);

                results.Add(weatherStation);
            }

            return results;
        }

        [HttpGet("{id}")]
        public WeatherStation Get(string id)
        {
            var connectionString =
                "Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=GenerationWeather;Integrated Security=SSPI;Trusted_Connection=yes;";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            // Absolutely not safe at all! This is here to show how nasty SQL Injection can be...
            command.CommandText = $"SELECT * FROM Stations WHERE id = '{id}'";
            
            var reader = command.ExecuteReader();

            if(!reader.HasRows)
                return new WeatherStation();

            reader.Read();
            var weatherStation = MapToModel(reader);

            return weatherStation;
        }

        private static WeatherStation MapToModel(SqlDataReader reader)
        {
            return new WeatherStation
            {
                Id = reader["id"].ToString(),
                Name = reader["name"].ToString(),
                Latitude = float.Parse(reader["latitude"].ToString()),
                Longitude = float.Parse(reader["longitude"].ToString()),
                Altitude = float.Parse(reader["altitude"].ToString()),
            };
        }
    }
}
