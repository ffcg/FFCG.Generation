using System.Collections.Generic;
using FFCG.HarryPotter.Domain;
using FFCG.HarryPotter.Domain.Discounts;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.HarryPotter.Tests.Discounts
{
    [TestFixture]
    public class FiveBooksDiscountTest
    {
        [Test]
        public void Should_calculate_10_percentage_discount_if_number_of_books_are_three()
        {
            var rule = new CalculateDiscountForFiveBooks();
            var result =
                rule.Calculate(new List<Book>
                {
                    new Book("id1", "name", 100),
                    new Book("id2", "name", 100),
                    new Book("id3", "name", 100),
                    new Book("id4", "name", 100),
                    new Book("id5", "name", 100)
                });

            result.Should().Be(125);
        }
    }
}