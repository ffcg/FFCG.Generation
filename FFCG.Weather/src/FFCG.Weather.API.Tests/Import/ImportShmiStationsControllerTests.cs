using System;
using System.Threading.Tasks;
using FFCG.Weather.API.Data;
using FFCG.Weather.API.Import;
using FFCG.Weather.API.Import.Controllers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FFCG.Weather.API.Tests.Import
{
    public class ImportShmiStationsControllerTests
    {
        [Fact]
        public async Task Should_store_returned_stations_in_database()
        {
            var options = new DbContextOptionsBuilder<WeatherContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            
            using (var context = new WeatherContext(options))
            {
                var controller = new ImportSmhiStationsController(context, new DummyStationsDownloader());
                await controller.Post();
            }

            using (var context = new WeatherContext(options))
            {
                var first = await context.Stations.FirstAsync(x => x.Id == "1");
                var second = await context.Stations.FirstAsync(x => x.Id == "2");

                Assert.Equal("Jens mätstation", first.Name);
                Assert.Equal("En annan station", second.Name);
            }
        }
    }

    public class DummyStationsDownloader : IStationsDownloader
    {
        public Task<SmhiResponseObject> Download()
        {
            var response = new SmhiResponseObject();
            response.station = new[]
            {
                new Station{ id = 1, name = "Jens mätstation", height = 1, latitude = 2, longitude = 3},
                new Station{ id = 2, name = "En annan station", height = 1, latitude = 2, longitude = 3}
            };

            return Task.Run(() => response);
        }
    }
}