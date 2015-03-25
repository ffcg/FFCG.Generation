using System.Collections.Generic;
using FFCG.HarryPotter.Domain;
using FFCG.HarryPotter.Domain.Discounts;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.HarryPotter.Tests
{
    [TestFixture]
    public class ShoppingHarryPotterBooksIntegrationTests
    {
        [Test]
        public void Should_calculate_correct_price()
        {
            var shoppingCart = new ShoppingCart(new List<ICalculateDiscountForBooks>
            {
                new CalculateDiscountForTwoBooks(),
                new CalculateDiscountForThreeBooks(),
                new CalculateDiscountForFourBooks(),
                new CalculateDiscountForFiveBooks()
            });

            shoppingCart.Add(new Book("id1", "name", 8));
            shoppingCart.Add(new Book("id1", "name", 8));
            shoppingCart.Add(new Book("id2", "name", 8));
            shoppingCart.Add(new Book("id2", "name", 8));
            shoppingCart.Add(new Book("id3", "name", 8));
            shoppingCart.Add(new Book("id3", "name", 8));
            shoppingCart.Add(new Book("id4", "name", 8));
            shoppingCart.Add(new Book("id5", "name", 8));

            shoppingCart.CalculateTotalPrice().Should().Be(51.6m);
        }
    }
}