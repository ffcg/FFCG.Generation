using System.Collections.Generic;
using System.Linq;
using FFCG.G4.GameOfLife.Rules;

namespace FFCG.G4.GameOfLife
{
    public class Cell
    {
        private readonly IEnumerable<ILifeRule> _lifeRules;

        public Cell(IEnumerable<ILifeRule> lifeRules, bool shouldStartOutAlive = false)
        {
            _lifeRules = lifeRules;
            IsAlive = shouldStartOutAlive;
        }

        public bool IsAlive { get; set; }

        public Cell Split(int amountOfNeighbors)
        {
            var shouldLive = _lifeRules.Where(x => x.ShouldHandle(IsAlive)).All(x => x.ShouldLive(amountOfNeighbors));
            return new Cell(_lifeRules, shouldLive);
        }
    }
}