namespace FFCG.HarryPotter.Domain
{
    public class Book
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Book(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}