using System.Collections.Generic;
using System.Linq;
using FFCG.HarryPotter.Domain.Discounts;

namespace FFCG.HarryPotter.Domain
{
    public class ShoppingCart
    {
        private readonly List<ICalculateDiscountForBooks> _discountRules;
        private readonly List<List<Book>> _items;

        public IReadOnlyCollection<Book> Items
        {
            get
            {
                return _items.SelectMany(x => x).ToList();
            }
        }

        private int MaxNumberOfBooksOfOneKind
        {
            get {
                return _items.Max(x => x.Count);
            }
        }

        public decimal CalculateTotalPrice()
        {
            decimal total = 0;

            for (var i = 0; MaxNumberOfBooksOfOneKind > i; i++)
            {
                var books = GetCurrentSerieOfBooks(i);

                var totalPriceForCurrentSerie = books.Sum(x => x.Price);

                foreach (var rule in _discountRules)
                {
                    totalPriceForCurrentSerie = totalPriceForCurrentSerie - rule.Calculate(books);
                }

                total += totalPriceForCurrentSerie;
            }

            return total;
        }

        private List<Book> GetCurrentSerieOfBooks(int i)
        {
            return (from item in _items 
                where i < item.Count 
                select item[i]).ToList();
        }

        public ShoppingCart(List<ICalculateDiscountForBooks> discountRules)
        {
            _discountRules = discountRules;

            _items = new List<List<Book>>();
        }

        public void Add(Book book)
        {
            if (BookIsAdded(book))
            {
                foreach (var item in FindCollectionForThisKindOfBook(book))
                    item.Add(book);
            }
            else
            {
                var books = new List<Book> { book };
                _items.Add(books);
            }
        }

        private IEnumerable<List<Book>> FindCollectionForThisKindOfBook(Book book)
        {
            return _items.Where(item => item.Any(x => x.Id == book.Id));
        }

        private bool BookIsAdded(Book book)
        {
            return Items.Any(x => x.Id == book.Id);
        }
    }
}