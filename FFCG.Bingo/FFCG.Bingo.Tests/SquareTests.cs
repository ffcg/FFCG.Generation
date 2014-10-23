using FluentAssertions;
using NUnit.Framework;

namespace FFCG.Bingo.Tests
{
    [TestFixture]
    public class SquareTests
    {
        [Test]
        public void Check_should_mark_square_as_checked()
        {
            var square = new Square(1);
            square.Check();
            square.Checked.Should().BeTrue();
        }

        [Test]
        public void Unchecked_square_should_not_be_marked_as_checked()
        {
            var square = new Square(1);
            square.Checked.Should().BeFalse();
        }
    }
}