using System.Collections.Generic;

namespace FFCG.G4.Movies.Core
{
    public interface IStorage
    {
        IEnumerable<Movie> GetAll();
        void Add(Movie movie);
    }
}
