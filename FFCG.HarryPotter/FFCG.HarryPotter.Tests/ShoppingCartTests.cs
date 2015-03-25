using System.Collections.Generic;
using FFCG.HarryPotter.Domain;
using FFCG.HarryPotter.Domain.Discounts;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace FFCG.HarryPotter.Tests
{
    [TestFixture]
    public class ShoppingCartTests
    {
        private ShoppingCart _shoppingCart;
        private Mock<ICalculateDiscountForBooks> _mock;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<ICalculateDiscountForBooks>();


            _shoppingCart = new ShoppingCart(new List<ICalculateDiscountForBooks> {_mock.Object});
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
            _mock.Setup(x => x.Calculate(It.IsAny<List<Book>>())).Returns(0);

            _shoppingCart.Add(new Book("id", "name", 100));
            _shoppingCart.CalculateTotalPrice().Should().Be(100);
        }

        [Test]
        public void Total_price_should_be_correct_if_cart_use_any_discount_rules()
        {
            _mock.Setup(x => x.Calculate(It.IsAny<List<Book>>())).Returns(10);

            _shoppingCart.Add(new Book("id", "name", 100));
            _shoppingCart.CalculateTotalPrice().Should().Be(90);
        }
    }
}