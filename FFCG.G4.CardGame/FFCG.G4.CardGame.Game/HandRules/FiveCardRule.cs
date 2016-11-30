namespace FFCG.G4.CardGame.Game.HandRules
{
    public class FiveCardRule : IHandRule
    {
        public string Name => "Five cards!";

        public bool CheckIfTheHandMeetsTheRequirements(Hand hand)
        {
            return hand.Cards().Count == 5;
        }
    }
}