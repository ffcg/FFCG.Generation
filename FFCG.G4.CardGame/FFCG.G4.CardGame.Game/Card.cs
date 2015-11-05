namespace FFCG.G4.CardGame.Game
{
    public class Card
    {
        public Suit Suit { get; set; }
        public CardNames Name { get; set; }
        public int Value { get; set; }

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