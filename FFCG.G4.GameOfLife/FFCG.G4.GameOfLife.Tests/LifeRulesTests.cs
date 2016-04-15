using FFCG.G4.GameOfLife.Rules;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.GameOfLife.Tests
{
    [TestFixture]
    public class LifeRulesTests
    {
        [Test]
        public void Live_Cell_With_Fewer_Than_Two_Neighbors_Should_Die()
        {
            var rule = new LiveCellWithFewerThanTwoNeighborsRule();
            rule.ShouldLive(1).Should().BeFalse();
        }

        [Test]
        public void Live_Cell_With_More_Than_Three_Neighbors_Should_Die()
        {
            var rule = new LiveCellWithMoreThanThreeNeighborsShouldDieRule();
            rule.ShouldLive(4).Should().BeFalse();
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public void Live_Cell_With_Two_Or_Three_Neighbors_Should_Live(int numberOfNeighbors)
        {
            var rule = new LiveCellWithTwoOrThreeNeighborsShouldLiveRule();
            rule.ShouldLive(numberOfNeighbors).Should().BeTrue();
        }

        [Test]
        public void Dead_Cell_With_Three_Neighbors_Should_Live()
        {
            var rule = new DeadCellWithThreeNeighborsShouldLiveRule();
            rule.ShouldLive(3).Should().BeTrue();
        }
    }
}
