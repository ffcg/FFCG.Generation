namespace FFCG.G4.CardGame.Game.HandRules
{
    public class NothingRule : IHandRule
    {
        public string Name => "Nothing!";

        public bool CheckIfTheHandMeetsTheRequirements(Hand hand)
        {
            return true;
        }
    }
}