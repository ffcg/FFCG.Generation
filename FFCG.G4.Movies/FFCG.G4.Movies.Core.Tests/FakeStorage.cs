using System.Collections.Generic;

namespace FFCG.G4.Movies.Core.Tests
{
    public class FakeStorage : IStorage
    {
        public FakeStorage()
        {
            _movies = new List<Movie>();
        }

        private readonly List<Movie> _movies;

        public IEnumerable<Movie> GetAll() => _movies;

        public void Add(Movie movie)
        {
            if (!_movies.Contains(movie))
                _movies.Add(movie);
        }
    }
}
