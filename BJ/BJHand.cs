using System;
using System.Collections.Generic;

namespace BJ
{
    public class BJHand : Hand
    {
        private readonly List<Card> hand = new List<Card>();

        public BJHand()
        {
        }

        public uint GetHandValue()
        {
            /*
             * Regn ut den samlede poengsummen til <hver> spiller
             * Nummererte kort har poeng som angitt på kortet
             * Knekt(J), Dronning(Q) og Konge(K) teller som 10 poeng
             * Ess(A) teller som 11 poeng
             */
            uint handValue=0;
            foreach (Card card in hand)
            {
                switch (card.Value())
                {
                    case CardValue.TWO: handValue += 2; break;
                    case CardValue.THREE: handValue += 3; break;
                    case CardValue.FOUR: handValue += 4; break;
                    case CardValue.FIVE: handValue += 5; break;
                    case CardValue.SIX: handValue += 6; break;
                    case CardValue.SEVEN: handValue += 7; break;
                    case CardValue.EIGHT: handValue += 8; break;
                    case CardValue.NINE: handValue += 9; break;
                    case CardValue.TEN:
                    case CardValue.JACK:
                    case CardValue.QUEEN:
                    case CardValue.KING: handValue += 10; break;
                    case CardValue.ACE: handValue += 11; break;
                    default:
                        throw new System.ArgumentException("Bad card value");
                }
            }
            return handValue;
         }

        public void TakeCard(Card card)
        {
            hand.Add(card);
        }

        public Card ThrowCard(uint index)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string returnString = "";

            foreach(Card card in hand)
            {
                returnString += (" " + card.ToString());
            }

            return returnString;
        }

        public void ResetHand()
        {
            hand.Clear();
        }

    }
}