using FFCG.HarryPotter.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.HarryPotter.Tests
{
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
            _shoppingCart.Items.Should().HaveCount(2);
        }

        [Test]
        public void Total_price_should_be_correct_if_cart_contains_one_book()
        {
            _shoppingCart.Add(new Book("id", "name", 100));
            _shoppingCart.CalculateTotalPrice().Should().Be(100);
        }

        [Test]
        public void Total_price_should_be_correct_of_cart_contains_two_unique_books()
        {
            _shoppingCart.Add(new Book("id1", "name", 100));
            _shoppingCart.Add(new Book("id2", "name", 100));
            _shoppingCart.CalculateTotalPrice().Should().Be(190);
        }

        [Test]
        public void Should_be_able_to_calculate_price()
        {
            _shoppingCart.Add(new Book("id1", "name", 100));
            _shoppingCart.Add(new Book("id1", "name", 100));
            _shoppingCart.CalculateTotalPrice().Should().Be(200);
        }

        [Test]
        public void Should_be_able_to_calculate_price_with_many_books()
        {
            _shoppingCart.Add(new Book("id1", "name", 8));
            _shoppingCart.Add(new Book("id1", "name", 8));
            _shoppingCart.Add(new Book("id2", "name", 8));
            _shoppingCart.Add(new Book("id2", "name", 8));
            _shoppingCart.Add(new Book("id3", "name", 8));
            _shoppingCart.Add(new Book("id3", "name", 8));
            _shoppingCart.Add(new Book("id4", "name", 8));
            _shoppingCart.Add(new Book("id5", "name", 8));

            _shoppingCart.CalculateTotalPrice().Should().Be(51.6m);
        }
    }
}