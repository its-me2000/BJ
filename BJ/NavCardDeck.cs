using System.Collections.Generic;

namespace BJ
{
    public class NavCardDeck : CardDeck
    {
        private readonly Queue<Card> deck;

        public NavCardDeck()
        {
        }

        public Card GetCard()
        {
            //return deck.Dequeue();
            return new Card(CardSuit.HEARTS, CardValue.ACE);
        }
        public override string ToString()
        {
            string returnString = "";

            foreach (Card card in deck)
            {
                returnString += card.ToString();
            }

            return returnString;
        }
    }
}
