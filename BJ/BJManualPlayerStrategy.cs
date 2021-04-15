using System;
using System.Collections.Generic;

namespace BJ
{
    public class BJManualPlayerStrategy : PlayerStrategy
    {
        private const uint BLACK_JACK = 21;
        public BJManualPlayerStrategy()
        {
        }

        public bool IsWaitingForCard(Hand ownHand, List<Hand> opponentsHands)
        {
            if (ownHand.GetHandValue() >= BLACK_JACK) return false;

            Console.WriteLine("\nMotspilleres kort:");
            foreach (Hand hand in opponentsHands)
            {
                Console.WriteLine("{0} | {1}",hand.GetHandValue(),hand.ToString());
            }
            Console.WriteLine("\nDine kort");
            Console.WriteLine("{0} | {1}", ownHand.GetHandValue(), ownHand.ToString());
            Console.WriteLine("\nEtt kort til? j/n");
            ConsoleKey commandKey = Console.ReadKey(true).Key;
            if( commandKey == ConsoleKey.J)
            {
                return true;
            }
            return false;
        }
    }
}
