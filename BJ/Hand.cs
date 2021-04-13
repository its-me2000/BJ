using System;
namespace BJ
{
    public interface Hand
    {
        uint GetHandValue();
        void TakeCard(Card card);
        Card ThrowCard(uint index);
    }
}
