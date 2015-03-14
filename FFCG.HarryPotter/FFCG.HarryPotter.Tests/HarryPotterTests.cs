using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.HarryPotter.Tests
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

    [TestFixture]
    public class ShoppingCartTests
    {
        private ShoppingCart _shoppingCart;

        [SetUp]
        public void SetUp()
        {
            _shoppingCart = new ShoppingCart();
        }

        [Test]
        public void Items_should_be_empty()
        {
            _shoppingCart.Items.Should().HaveCount(0);
        }

        [Test]
        public void Should_be_able_to_add_item()
        {
            _shoppingCart.Add(new Book("id", "name", 100));
            _shoppingCart.Items.Should().HaveCount(1);
        }

        [Test]
        public void Should_be_able_to_add_the_same_items_twice()
        {
            var book = new Book("id", "name", 100);
            _shoppingCart.Add(book);
            _shoppingCart.Add(book);
            _shoppingCart.Items.Should().HaveCount(1);
        }

        [Test]
        public void Total_price_should_be_correct_if_cart_contains_one_book()
        {
            _shoppingCart.Add(new Book("id", "name", 100));
            _shoppingCart.Total.Should().Be(100);
        }

        [Test]
        public void Total_price_should_be_correct_of_cart_contains_two_unique_books()
        {
            _shoppingCart.Add(new Book("id1", "name", 100));
            _shoppingCart.Add(new Book("id2", "name", 100));
            _shoppingCart.Total.Should().Be(190);
        }

        [Test]
        public void Should_be_able_to_calculate_price()
        {
  
        }
    }

    public class ShoppingCart
    {
        private readonly List<Stack<Book>> _items;
        public IReadOnlyCollection<Book> Items { get { return _items.Select(x => x.Peek()).ToList(); } }

        public decimal Total
        {
            get
            {
                var books = new List<Book>();
                foreach (var item in _items)
                {
                    var book = item.Pop();
                    books.Add(book);
                }

                var sum = books.Sum(x => x.Price);
                if (books.Count == 2)
                {
                    sum = sum - (sum*0.05m);
                }

                return sum;
            }
        }

        public ShoppingCart()
        {
            _items = new List<Stack<Book>>();
        }

        public void Add(Book book)
        {
            if (Items.Any(x => x.Id == book.Id))
            {
                var single = _items.Single(x => x.Peek().Id == book.Id);
                single.Push(book);
            }
            else
            {
                var books = new Stack<Book>();
                books.Push(book);
                _items.Add(books);    
            }
        }
    }

    [TestFixture]
    public class BookTests
    {
        private Book _book;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _book = new Book("id", "Harry Potter 1", 8);
        }

        [Test]
        public void Id_should_be_set()
        {
            _book.Id.Should().Be("id");
        }

        [Test]
        public void Name_should_be_set()
        {
            _book.Name.Should().Be("Harry Potter 1");
        }

        [Test]
        public void Price_should_be_set()
        {
            _book.Price.Should().Be(8);
        }
    }

    [TestFixture]
    public class HarryPotterTests
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            
        }
    }
}
