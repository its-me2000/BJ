using System;
using System.Collections.Generic;

namespace BJ
{
    public class BJManualPlayerStrategy : PlayerStrategy
    {
        private const uint BLACK_JACK = 21;
        private Func<string, string, bool> userInterface;
        public BJManualPlayerStrategy(Func<string, string, bool> _userInterface)
        {
            userInterface = _userInterface;
        }

        public bool IsWaitingForCard(Player selfPlayer, Table table)
        {
            if (selfPlayer.GetHand().GetHandValue() >= BLACK_JACK) return false;

            string opponentsData = "";
            string ownData = "";

            foreach (Player player in table.GetPlayers())
            {
                if (player != selfPlayer)
                {
                    opponentsData += player.ToString() + "\n";
                }
            }
            ownData = selfPlayer.ToString();

            return userInterface(ownData, opponentsData);
        }
    }
}
