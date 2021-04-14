namespace BJ
{
    public class BJThresholdPlayerStategy : PlayerStrategy
    {
        private readonly uint threshold;
        public BJThresholdPlayerStategy(uint _threshold)
        {
            threshold = _threshold;
        }

        public bool IsWaitingForCard(Hand ownHand, Hand opponentHand)
        {
            return ownHand.GetHandValue() < threshold;
        }
    }
}
