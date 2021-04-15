using System.Collections.Generic;

namespace BJ
{
    public class BJDealerPlayerStrategy : PlayerStrategy
    {
        private const uint BLACK_JACK = 21;
        public BJDealerPlayerStrategy()
        {
        }

        public bool IsWaitingForCard(Hand ownHand, List<Hand> opponentsHands)
        {
            uint bestOpponentsHandValue = 0;
            opponentsHands.ForEach( (hand) => {
                if (hand.GetHandValue() > bestOpponentsHandValue && hand.GetHandValue() <= BLACK_JACK)
                    bestOpponentsHandValue = hand.GetHandValue();
            });

            return ownHand.GetHandValue() <= bestOpponentsHandValue
                && ownHand.GetHandValue() < BLACK_JACK;
        }
    }
}
