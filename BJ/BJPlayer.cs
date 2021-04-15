using System.Collections.Generic;

namespace BJ
{
    public class BJPlayer : Player
    {
        private readonly string name;
        private readonly Hand hand;
        private readonly PlayerStrategy strategy;

        public BJPlayer(string _name, PlayerStrategy _strategy)
        {
            name = _name;
            strategy = _strategy;
            hand = new BJHand();
        }

        public void TakeCard(Card card)
        {
            hand.TakeCard(card);
        }

        public Hand GetHand()
        {
            return hand;
        }

        public string GetName()
        {
            return name;
        }

        public bool IsWaitingForCard(List<Hand> opponentsHands)
        {
            return strategy.IsWaitingForCard(hand, opponentsHands);
        }
        public override string ToString()
        {
            return name + " | " + hand.GetHandValue().ToString() + " | "+ hand.ToString();
        }
    }
}
