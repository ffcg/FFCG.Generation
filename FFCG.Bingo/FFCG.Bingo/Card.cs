using System;
using System.Collections.Generic;
using System.Linq;

namespace FFCG.Bingo
{
    public class Card
    {
        private readonly int _rows;
        private readonly Square[,] _card;

        public Card(int rows)
        {
            _rows = rows;
            _card = new Square[rows, 5];

            int currentStart = 1;
            for (int col = 0; col < 5; col++)
            {
                var randomise = Randomizer.Randomise(currentStart, currentStart + rows - 1);

                for (int row = 0; row < rows; row++)
                    _card[row, col] = new Square(randomise[row]);

                currentStart = currentStart + rows;
            }
        }

        public bool IsBingo()
        {
            return GetAllRows().Any(x => x.HasBingo());
        }

        public IEnumerable<Row> GetAllRows()
        {
            var rows = new List<Row>();

            for (int row = 0; row < _rows; row++)
            {
                var row1 = new Row();
                for (int col = 0; col < 5; col++)
                {
                    row1.AddSquare(_card[row, col]);
                }
                rows.Add(row1);
            }

            return rows;
        }

        private void OnEachSquare(Action<int, int> act)
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    act(row, col);
                }
            }
        }

        public void Check(int number)
        {
            OnEachSquare((row, col) =>
                {
                    if (_card[row, col].Number == number)
                        _card[row, col].Check();
                });
        }
    }
}