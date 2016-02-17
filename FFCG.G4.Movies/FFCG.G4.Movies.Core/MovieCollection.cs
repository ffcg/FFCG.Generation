using System.Collections.Generic;

namespace FFCG.G4.Movies.Core
{
    public class MovieCollection
    {
        private readonly IStorage _storage;
        public IEnumerable<Movie> Movies { get { return _storage.All<Movie>(); } }

        public MovieCollection(IStorage storage)
        {
            _storage = storage;
        }

        public void AddMovie(Movie movie)
        {
            _storage.Store(movie);
        }
    }
}