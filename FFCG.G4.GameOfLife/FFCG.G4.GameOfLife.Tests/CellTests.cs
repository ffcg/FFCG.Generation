using System.Collections.Generic;
using FFCG.G4.GameOfLife.Rules;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.GameOfLife.Tests
{
    [TestFixture]
    public class CellTests
    {
        [Test]
        [TestCase(true, 4, false)]
        [TestCase(true, 1, false)]
        [TestCase(true, 2, true)]
        [TestCase(false, 3, true)]
        public void Cell_Should_Abide_By_Life_Rules(
            bool isAliveFromStart, 
            int numberOfNeighbors,
            bool isAliveAfterSplit)
        {
            var lifeRules = new List<ILifeRule>()
            {
                new LiveCellWithMoreThanThreeNeighborsShouldDieRule(),
                new LiveCellWithFewerThanTwoNeighborsRule(),
                new LiveCellWithTwoOrThreeNeighborsShouldLiveRule(),
                new DeadCellWithThreeNeighborsShouldLiveRule()
            };

            var cell = new Cell(lifeRules, isAliveFromStart);

            var splitCell = cell.Split(numberOfNeighbors);

            splitCell.IsAlive.Should().Be(isAliveAfterSplit);
        }
    }
}
