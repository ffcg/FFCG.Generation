namespace FFCG.G4.Movies.Core
{
    public class Movie
    {
        public int Id { get; }
        public string Name { get; }

        public Movie(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}