namespace BJ
{
    public class BJDealerPlayerStrategy : PlayerStrategy
    {
        private const uint BLACK_JACK = 21;
        public BJDealerPlayerStrategy()
        {
        }

        public bool IsWaitingForCard(Hand ownHand, Hand opponentHand)
        {
            return ownHand.GetHandValue() <= opponentHand.GetHandValue()
                && ownHand.GetHandValue() < BLACK_JACK;
        }
    }
}
