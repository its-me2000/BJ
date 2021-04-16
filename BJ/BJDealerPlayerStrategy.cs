/*
 * ....begynner Marit å trekke kort
 * Marit slutter å trekke kort når poengsummen hennes er høyere enn din poengsum
 * Marit taper spillet dersom poengsummen er høyere enn 21
 * 
 * Remark:
 * Om dine poengsum er 20 eller 21 og Marits poengsum er 20 eller 21
 * det er ingen vits å trekke en kort til for henne.
 */

using System.Collections.Generic;

namespace BJ
{
    public class BJDealerPlayerStrategy : PlayerStrategy
    {
        private const uint BLACK_JACK = 21;

        public BJDealerPlayerStrategy()
        {
        }

        public bool IsWaitingForCard(Player selfPlayer, Table table)
        {
            uint bestOpponentsHandValue = 0;
            table.GetPlayers().ForEach( (player) => {
            if (player != selfPlayer
                && player.GetHand().GetHandValue() > bestOpponentsHandValue
                && player.GetHand().GetHandValue() <= BLACK_JACK)
                {
                    bestOpponentsHandValue = player.GetHand().GetHandValue();
                }
            });

            /*
             * Marit slutter å trekke kort når poengsummen hennes er høyere enn din poengsum
             */
            //return selfPlayer.GetHand().GetHandValue() <= bestOpponentsHandValue;

            /*
             * Marit slutter å trekke kort når hun vinner eller mistet mulighet til å vinne.
             */
            bool ownValueLessOrEqThanOpponents = selfPlayer.GetHand().GetHandValue() <= bestOpponentsHandValue;
            bool ownValueLessThanTwenty = selfPlayer.GetHand().GetHandValue() < BLACK_JACK - 1;
            return ownValueLessOrEqThanOpponents && ownValueLessThanTwenty;          
        }
    }
}
