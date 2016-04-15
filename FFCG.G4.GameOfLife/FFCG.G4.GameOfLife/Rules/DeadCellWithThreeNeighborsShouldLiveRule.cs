namespace FFCG.G4.GameOfLife.Rules
{
    public class DeadCellWithThreeNeighborsShouldLiveRule : ILifeRule
    {
        public bool ShouldHandle(bool isAlive)
        {
            return isAlive == false;
        }

        public bool ShouldLive(int numberOfNeighbors)
        {
            return numberOfNeighbors == 3;
        }
    }
}
