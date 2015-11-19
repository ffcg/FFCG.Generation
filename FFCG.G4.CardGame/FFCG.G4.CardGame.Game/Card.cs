namespace FFCG.G4.CardGame.Game
{
    public class Card
    {
        public Suit Suit { get; private set; }
        public CardNames Name { get; private set; }
        public int Value { get; private set; }

        public Card(Suit suit, CardNames name, int value)
        {
            Suit = suit;
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", Suit, Name, Value);
        }
    }
}