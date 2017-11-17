using System;
using System.Linq;

namespace FFCG.G6.Dicer
{
    public class Dice : IDice
    {
        private readonly int _sides;

        public Dice(int sides)
        {
            _sides = sides;
        }

        public int Roll()
        {
            return Enumerable.Range(1, _sides).OrderBy(x => Guid.NewGuid()).First();
        }
    }
}