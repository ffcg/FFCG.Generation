using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FFCG.G4.Movies.Core;
using Newtonsoft.Json;

namespace FFCG.G4.Movies.ApiConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "https://api.themoviedb.org/3/movie/popular/?api_key=APIKEYHERE!";
            string baseImageUrl = "https://image.tmdb.org/t/p/w370";
            var storage = new FileStorage(@"c:\temp\Movies.API");

            using (var webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var completeUrl = baseUrl + "&page=1";

                var resultString = webClient.DownloadString(completeUrl);

                var movieResults = JsonConvert.DeserializeObject<MovieResults>(resultString);

                foreach (var movieResult in movieResults.results)
                {
                    var movie = new Movie(movieResult.id, movieResult.title)
                    {
                        Overview = movieResult.overview,
                        Popularity = movieResult.popularity,
                        PosterPath = baseImageUrl + movieResult.poster_path
                    };
                    storage.Store(movie);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Stored movies! WE GOT EM!");
                Console.ResetColor();
            }
        }
    }

    public class MovieResults
    {
        public int page { get; set; }
        public int total_pages { get; set; }
        public List<MovieResult> results { get; set; }
    }

    public class MovieResult
    {
        public int id { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public decimal popularity { get; set; }
        public string poster_path { get; set; }
    }
}
