using System.Collections.Generic;

namespace BJ
{
    public interface Player
    {
        void TakeCard(Card card);
        Hand GetHand();
        string GetName();
        bool IsWaitingForCard(List<Hand> opponentsHands);
    }
}
