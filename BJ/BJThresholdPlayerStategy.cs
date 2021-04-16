/*
 * Du skal stoppe å trekke kort når poengsummen blir 17 eller høyere
 */

using System.Collections.Generic;

namespace BJ
{
    public class BJThresholdPlayerStrategy : PlayerStrategy
    {
        private const uint DEFAULT_THRESHOLD = 17;
        private readonly uint threshold = DEFAULT_THRESHOLD;

        public BJThresholdPlayerStrategy(uint _threshold)
        {
            threshold = _threshold;
        }

        public BJThresholdPlayerStrategy() { }

        public bool IsWaitingForCard(Player selfPlayer, Table table)
        {
            return selfPlayer.GetHand().GetHandValue() < threshold;
        }
    }
}
