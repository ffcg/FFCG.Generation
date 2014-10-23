using FluentAssertions;
using NUnit.Framework;

namespace FFCG.Bingo.Tests
{
    [TestFixture]
    public class RowTests
    {
        [Test]
        public void Row_with_all_square_checked_should_be_bingo()
        {
            var square1 = new Square(1);
            var square2 = new Square(2);
            var square3 = new Square(3);
            square1.Check();
            square2.Check();
            square3.Check();

            var row = new Row();
            row.AddSquare(square1);
            row.AddSquare(square2);
            row.AddSquare(square3);

            row.HasBingo().Should().BeTrue();
        }
    }
}
