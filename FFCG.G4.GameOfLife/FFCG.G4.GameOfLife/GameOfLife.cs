using System;
using System.Collections.Generic;
using FFCG.G4.GameOfLife.Rules;

namespace FFCG.G4.GameOfLife
{
    public class GameOfLife
    {
        private readonly int _rowCount;
        private readonly int _columnCount;

        public GameOfLife(int rowCount, int columnCount)
        {
            _rowCount = rowCount;
            _columnCount = columnCount;

            CreateCells();
        }

        public Cell[,] Cells { get; private set; }

        private void CreateCells()
        {
            Cells = new Cell[_rowCount, _columnCount];

            var lifeRules = new List<ILifeRule>()
            {
                new LiveCellWithMoreThanThreeNeighborsShouldDieRule(),
                new LiveCellWithFewerThanTwoNeighborsRule(),
                new LiveCellWithTwoOrThreeNeighborsShouldLiveRule(),
                new DeadCellWithThreeNeighborsShouldLiveRule()
            };

            for (var x = 0; x < _rowCount; x++)
                for (var y = 0; y < _columnCount; y++)
                    Cells[x, y] = new Cell(lifeRules);
        }

        public void SetLivingCell(int row, int column)
        {
            Cells[row, column].IsAlive = true;
        }

        public void ComputeNextGeneration()
        {
            var nextGeneration = new Cell[_rowCount, _columnCount];

            for (var x = 0; x < _rowCount; x++)
                for (var y = 0; y < _columnCount; y++)
                    nextGeneration[x, y] = Cells[x, y].Split(CountLivingNeighbors(x, y));

            Cells = nextGeneration;
        }

        public int CountLivingNeighbors(int row, int column)
        {
            var surroundingCellPositions = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(row-1, column-1),
                new Tuple<int, int>(row-1, column),
                new Tuple<int, int>(row-1, column+1),
                new Tuple<int, int>(row, column+1),
                new Tuple<int, int>(row+1, column+1),
                new Tuple<int, int>(row+1, column),
                new Tuple<int, int>(row+1, column-1),
                new Tuple<int, int>(row, column-1)
            };

            var livingNeighbors = 0;

            foreach (var position in surroundingCellPositions)
                if (IsInTheGrid(position.Item1, position.Item2) && Cells[position.Item1, position.Item2].IsAlive)
                    livingNeighbors++;

            return livingNeighbors;
        }

        private bool IsInTheGrid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < _rowCount && col < _columnCount;
        }
    }
}
