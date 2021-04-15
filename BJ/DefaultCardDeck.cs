using System;
using System.Collections.Generic;

namespace BJ
{
    public class DefaultCardDeck : CardDeck
    {
        private readonly Queue<Card> deck;
        private static List<Card> defaultDeck = new List<Card>
        {
        new Card(CardSuit.HEARTS, CardValue.TWO),
        new Card(CardSuit.HEARTS, CardValue.THREE),
        new Card(CardSuit.HEARTS, CardValue.FOUR),
        new Card(CardSuit.HEARTS, CardValue.FIVE),
        new Card(CardSuit.HEARTS, CardValue.SIX),
        new Card(CardSuit.HEARTS, CardValue.SEVEN),
        new Card(CardSuit.HEARTS, CardValue.EIGHT),
        new Card(CardSuit.HEARTS, CardValue.NINE),
        new Card(CardSuit.HEARTS, CardValue.TEN),
        new Card(CardSuit.HEARTS, CardValue.JACK),
        new Card(CardSuit.HEARTS, CardValue.QUEEN),
        new Card(CardSuit.HEARTS, CardValue.KING),
        new Card(CardSuit.HEARTS, CardValue.ACE),
        new Card(CardSuit.DIAMONDS, CardValue.TWO),
        new Card(CardSuit.DIAMONDS, CardValue.THREE),
        new Card(CardSuit.DIAMONDS, CardValue.FOUR),
        new Card(CardSuit.DIAMONDS, CardValue.FIVE),
        new Card(CardSuit.DIAMONDS, CardValue.SIX),
        new Card(CardSuit.DIAMONDS, CardValue.SEVEN),
        new Card(CardSuit.DIAMONDS, CardValue.EIGHT),
        new Card(CardSuit.DIAMONDS, CardValue.NINE),
        new Card(CardSuit.DIAMONDS, CardValue.TEN),
        new Card(CardSuit.DIAMONDS, CardValue.JACK),
        new Card(CardSuit.DIAMONDS, CardValue.QUEEN),
        new Card(CardSuit.DIAMONDS, CardValue.KING),
        new Card(CardSuit.DIAMONDS, CardValue.ACE),
        new Card(CardSuit.CLUBS, CardValue.TWO),
        new Card(CardSuit.CLUBS, CardValue.THREE),
        new Card(CardSuit.CLUBS, CardValue.FOUR),
        new Card(CardSuit.CLUBS, CardValue.FIVE),
        new Card(CardSuit.CLUBS, CardValue.SIX),
        new Card(CardSuit.CLUBS, CardValue.SEVEN),
        new Card(CardSuit.CLUBS, CardValue.EIGHT),
        new Card(CardSuit.CLUBS, CardValue.NINE),
        new Card(CardSuit.CLUBS, CardValue.TEN),
        new Card(CardSuit.CLUBS, CardValue.JACK),
        new Card(CardSuit.CLUBS, CardValue.QUEEN),
        new Card(CardSuit.CLUBS, CardValue.KING),
        new Card(CardSuit.CLUBS, CardValue.ACE),
        new Card(CardSuit.SPADES, CardValue.TWO),
        new Card(CardSuit.SPADES, CardValue.THREE),
        new Card(CardSuit.SPADES, CardValue.FOUR),
        new Card(CardSuit.SPADES, CardValue.FIVE),
        new Card(CardSuit.SPADES, CardValue.SIX),
        new Card(CardSuit.SPADES, CardValue.SEVEN),
        new Card(CardSuit.SPADES, CardValue.EIGHT),
        new Card(CardSuit.SPADES, CardValue.NINE),
        new Card(CardSuit.SPADES, CardValue.TEN),
        new Card(CardSuit.SPADES, CardValue.JACK),
        new Card(CardSuit.SPADES, CardValue.QUEEN),
        new Card(CardSuit.SPADES, CardValue.KING),
        new Card(CardSuit.SPADES, CardValue.ACE)
        };

        public DefaultCardDeck(bool shuffled)
        {
            if (shuffled)
            {
                deck = new Queue<Card>();
                Random random = new Random();
                List<Card> tempDeck = new List<Card>(defaultDeck);
                while(tempDeck.Count > 0)
                {
                    int r = random.Next(tempDeck.Count - 1);
                    deck.Enqueue(tempDeck[r]);
                    tempDeck.RemoveAt(r);
                }
            }
            else
            {
                deck = new Queue<Card>(defaultDeck);
            }
        }

        public Card GetCard()
        {
            return deck.Dequeue();
        }

        public override string ToString()
        {
            string returnString = "";

            foreach (Card card in deck)
            {
                returnString += (" " + card.ToString());
            }

            return returnString;
        }
    }
}
