namespace FFCG.G4.GameOfLife.Rules
{
    public interface ILifeRule
    {
        bool ShouldHandle(bool isAlive);
        bool ShouldLive(int numberOfNeighbors);
    }
}
