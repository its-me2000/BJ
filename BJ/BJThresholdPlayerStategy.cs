using System.Collections.Generic;

namespace BJ
{
    public class BJThresholdPlayerStrategy : PlayerStrategy
    {
        private readonly uint threshold;
        public BJThresholdPlayerStrategy(uint _threshold)
        {
            threshold = _threshold;
        }

        public bool IsWaitingForCard(Hand ownHand, List<Hand> opponentsHands)
        {
            return ownHand.GetHandValue() < threshold;
        }
    }
}
