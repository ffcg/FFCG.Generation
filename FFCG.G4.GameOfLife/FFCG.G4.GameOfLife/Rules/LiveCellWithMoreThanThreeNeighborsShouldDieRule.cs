namespace FFCG.G4.GameOfLife.Rules
{
    public class LiveCellWithMoreThanThreeNeighborsShouldDieRule : ILifeRule
    {
        public bool ShouldHandle(bool isAlive)
        {
            return isAlive;
        }

        public bool ShouldLive(int numberOfNeighbors)
        {
            return numberOfNeighbors < 4;
        }
    }
}
