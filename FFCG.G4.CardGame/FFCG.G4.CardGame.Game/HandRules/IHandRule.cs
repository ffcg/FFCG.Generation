namespace FFCG.G4.CardGame.Game.HandRules
{
    public interface IHandRule
    {
        string Name { get; }
        bool CheckIfTheHandMeetsTheRequirements(Hand hand);
    }
}