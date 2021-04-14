namespace BJ
{

    public class Card
    {
        private readonly CardSuit suit;
        private readonly CardValue value;

        public Card(CardSuit _suit, CardValue _value)
        {
            suit = _suit;
            value = _value;
        }

        public CardSuit Suit { get; }

        public CardValue Value { get; }

        public override string ToString()
        {
            System.Text.Rune cardSymbol = new( ((uint)suit) | ((uint)value) );
            return cardSymbol.ToString() ;
        }
    }
}
