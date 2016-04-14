namespace FFCG.G4.Movies.Core
{
    public class Movie
    {
        public int Id { get; }
        public string Name { get; }
        public string Overview { get; set; }
        public decimal Popularity { get; set; }
        public string PosterPath { get; set; }

        public Movie(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool Equals(object o)
        {
            return o is Movie && ((Movie)o).Id == Id;
        }
    }
}