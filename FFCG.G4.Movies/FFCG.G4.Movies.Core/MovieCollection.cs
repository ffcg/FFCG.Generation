using System.Collections.Generic;

namespace FFCG.G4.Movies.Core
{
    public class MovieCollection
    {
        private readonly IStorage _storage;
        public IEnumerable<Movie> Movies => _storage.GetAll();

        public MovieCollection(IStorage storage)
        {
            _storage = storage;
        }

        public void AddMovie(Movie movie)
        {
            _storage.Add(movie);
        }
    }
}