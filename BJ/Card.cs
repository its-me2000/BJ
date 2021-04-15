using System.Collections.Generic;

namespace BJ
{

    public class Card
    {
        private readonly CardSuit suit;
        private readonly CardValue value;
        private static readonly Dictionary<CardValue, string> CardValueStrings = new Dictionary<CardValue, string>()
        {
            { CardValue.TWO, "2" }, { CardValue.THREE, "3" }, { CardValue.FOUR,  "4" }, { CardValue.FIVE, "5" },
            { CardValue.SIX, "6" }, { CardValue.SEVEN, "7" }, { CardValue.EIGHT, "8" }, { CardValue.NINE, "9" },
            { CardValue.TEN, "10"}, { CardValue.JACK,  "J" }, { CardValue.QUEEN, "Q" }, { CardValue.KING, "K" },
            { CardValue.ACE, "A" }
        };
        private static readonly Dictionary<CardSuit, string> CardSuitStrings = new Dictionary<CardSuit, string>()
        {
            { CardSuit.CLUBS, "C" }, { CardSuit.DIAMONDS, "D" }, { CardSuit.HEARTS, "H" }, {CardSuit.SPADES, "S"} 
        };

        public Card(CardSuit _suit, CardValue _value)
        {
            suit = _suit;
            value = _value;
        }

        public CardSuit Suit() => suit;

        public CardValue Value() => value;

        public override string ToString()
        {
            return CardSuitStrings[suit] + CardValueStrings[value];
        }

        public string ToRuneString()
        {
            return new System.Text.Rune(((uint)suit) | ((uint)value)).ToString();
        }
    }
}
