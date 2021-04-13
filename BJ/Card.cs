using System;
namespace BJ
{
    
    public class Card
    {
        private CardSuit suit;
        private CardValue value;

        public Card(CardSuit _suit, CardValue _value)
        {
            suit = _suit;
            value = _value;
        }

        public CardSuit Suit { get; }

        public CardValue Value { get; }

        public override string ToString()
        {
            System.Text.Rune cardSymbol = new System.Text.Rune( ((uint)suit) | ((uint)value) );
            return cardSymbol.ToString() ;
        }
    }
}
