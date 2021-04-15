using System.Collections.Generic;

namespace BJ
{
    public interface PlayerStrategy
    {
        bool IsWaitingForCard(Hand ownHand, List<Hand> opponentHand);
    }
}
