using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.GameOfLife.Tests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        private GameOfLife _gameOfLife;

        [SetUp]
        public void SetUp()
        {
            _gameOfLife = new GameOfLife(4, 8);
        }

        [Test]
        public void Should_Be_Able_To_Set_Living_Cell()
        {
            _gameOfLife.SetLivingCell(1, 2);
            _gameOfLife.Cells[1, 2].IsAlive.Should().BeTrue();
        }

        [Test]
        public void Should_Count_Living_Neighbors()
        {
            _gameOfLife.SetLivingCell(2, 3);
            _gameOfLife.SetLivingCell(2, 4);
            _gameOfLife.SetLivingCell(1, 2);
            _gameOfLife.SetLivingCell(1, 3);

            _gameOfLife.CountLivingNeighbors(2, 3).Should().Be(3);
        }

        [Test]
        public void Should_Correctly_Count_Living_Neighbors_For_Corner_Cells()
        {
            _gameOfLife.SetLivingCell(0, 0);
            _gameOfLife.SetLivingCell(0, 1);
            _gameOfLife.SetLivingCell(1, 1);

            _gameOfLife.CountLivingNeighbors(0, 0).Should().Be(2);
        }

        [Test]
        public void Test_Generation_Should_Get_Expected_Result()
        {
            _gameOfLife.SetLivingCell(1, 4);
            _gameOfLife.SetLivingCell(2, 3);
            _gameOfLife.SetLivingCell(2, 4);

            _gameOfLife.ComputeNextGeneration();

            _gameOfLife.Cells[1, 3].IsAlive.Should().BeTrue();
            _gameOfLife.Cells[1, 4].IsAlive.Should().BeTrue();
            _gameOfLife.Cells[2, 3].IsAlive.Should().BeTrue();
            _gameOfLife.Cells[2, 4].IsAlive.Should().BeTrue();
        }
    }
}