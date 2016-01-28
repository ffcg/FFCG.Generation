using System.Collections.Generic;

namespace FFCG.G4.Movies.Core
{
    public class MovieCollection
    {
        private readonly List<Movie> _movies;
        public IEnumerable<Movie> Movies { get { return _movies; } }

        public MovieCollection()
        {
            _movies = new List<Movie>();
        }

        public void AddMovie(Movie movie)
        {
            if(!_movies.Contains(movie))
            {
                _movies.Add(movie);
            }
        }
    }
}