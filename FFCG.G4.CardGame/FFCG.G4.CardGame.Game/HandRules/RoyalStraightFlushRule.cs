using System.Linq;

namespace FFCG.G4.CardGame.Game.HandRules
{
    public class RoyalStraightFlushRule : IHandRule
    {
        public string Name => "Royal Straight Flush!";

        public bool CheckIfTheHandMeetsTheRequirements(Hand hand)
        {
            foreach (var suite in hand.Cards().GroupBy(x => x.Suit))
            {
                if (suite.Count(x => x.Value > 9) == 5)
                    return true;
            }
            return false;
        }
    }
}