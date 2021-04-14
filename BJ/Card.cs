using System.Collections.Generic;

namespace BJ
{

    public class Card
    {
        private readonly CardSuit suit;
        private readonly CardValue value;
        private bool runesString;
        private Dictionary<CardValue, string> CardValueStrings;
        private Dictionary<CardSuit, string> CardSuitStrings;

        public Card(CardSuit _suit, CardValue _value)
        {
            suit = _suit;
            value = _value;
            runesString = false;
            CardValueStrings = new Dictionary<CardValue, string>(13);
            CardValueStrings.Add(CardValue.TWO,"2");
            CardValueStrings.Add(CardValue.THREE, "3");
            CardValueStrings.Add(CardValue.FOUR, "4");
            CardValueStrings.Add(CardValue.FIVE, "5");
            CardValueStrings.Add(CardValue.SIX, "6");
            CardValueStrings.Add(CardValue.SEVEN, "7");
            CardValueStrings.Add(CardValue.EIGHT, "8");
            CardValueStrings.Add(CardValue.NINE, "9");
            CardValueStrings.Add(CardValue.TEN, "10");
            CardValueStrings.Add(CardValue.JACK, "J");
            CardValueStrings.Add(CardValue.QUEEN, "Q");
            CardValueStrings.Add(CardValue.KING, "K");
            CardValueStrings.Add(CardValue.ACE, "A");
            CardSuitStrings = new Dictionary<CardSuit, string>(4);
            CardSuitStrings.Add(CardSuit.CLUBS, "C");
            CardSuitStrings.Add(CardSuit.DIAMONDS, "D");
            CardSuitStrings.Add(CardSuit.HEARTS, "H");
            CardSuitStrings.Add(CardSuit.SPADES, "S");
        }

        public void SetRunesString(bool _runesString) => runesString = _runesString;

        public bool IsRunesString() => runesString;

        public CardSuit Suit { get; }

        public CardValue Value { get; }

        public override string ToString()
        {
            if (runesString)
            {
                System.Text.Rune cardSymbol = new System.Text.Rune(((uint)suit) | ((uint)value));
                return cardSymbol.ToString();
            }
            else
            {
                return CardSuitStrings[suit] + CardValueStrings[value];
            }
        }
    }
}
