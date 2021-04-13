using System;
namespace BJ
{
    public interface PlayerStrategy
    {
        bool IsWaitingForCard(Hand ownHand, Hand opponentHand);
    }
}
