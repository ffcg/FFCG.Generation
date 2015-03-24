using FFCG.HarryPotter.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.HarryPotter.Tests
{
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
}
