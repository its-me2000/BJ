using System;
namespace BJ
{
    public interface Player
    {
        void TakeCard(Card card);
        Hand GetHand();
        string GetName();
        bool IsWaitingForCard(Hand opponentHand);
    }
}
