using FFCG.G4.Movies.Core;

namespace FFCG.G4.Movies.Api.Controllers
{
    public static class Storage
    {
        public static MovieCollection Collection = new MovieCollection();

        static Storage()
        {
            Collection.AddMovie(new Movie(1, "I'm batman"));
            Collection.AddMovie(new Movie(2, "Star Wars IV"));
        }
    }
}