using System.Collections.Generic;

namespace BJ
{
    public class BJRules : Rules
    {
        private const uint BLACK_JACK = 21;
        public BJRules()
        {
        }

        public List<Player> GetWinners(Table table, CardDeck deck)
        {
            List<Player> WinnersList;
            /*
             * Hver spiller tar to kort hver fra toppen av en tilfeldig stokket kortstokk.
             * Du tar de to første kortene, Marit tar de to neste
             */
            FirstDeal(table, deck);
            /*
             * Regn ut om en av spillerene har 21 poeng - Blackjack - med deres 
             * initielle kort, og dermed vinner runden.
             */
            WinnersList = BlackJackWinners(table);
            if (WinnersList.Count != 0)
            {
                return WinnersList;
            }
            /*
             * Hvis ingen har 21 poeng, skal spillerne trekke kort fra toppen av kortstokken
             */
            DealRest(table, deck);
            WinnersList = EndGameWinners(table);
            return WinnersList;
        }

        private void FirstDeal(Table table, CardDeck deck)
        {
            foreach(Player player in table.GetPlayers())
            {
                player.TakeCard(deck.GetCard());
                player.TakeCard(deck.GetCard());
            }
        }

        private List<Player> BlackJackWinners(Table table)
        {
            /*
             * Regn ut om en av spillerene har 21 poeng - Blackjack - med deres 
             * initielle kort, og dermed vinner runden.
             */
            return CheckForWinners(table, BLACK_JACK);
        }

        private List<Player> EndGameWinners(Table table)
        {
            return CheckForWinners(table, GetBestHandValue(table));
        }

        private List<Player> CheckForWinners(Table table, uint bestHandValue)
        {
            List<Player> WinnersList = new List<Player>();
            foreach (Player player in table.GetPlayers())
            {
                if (player.GetHand().GetHandValue() == bestHandValue)
                {
                    WinnersList.Add(player);
                }
            }
            return WinnersList;
        }
        private void DealRest(Table table, CardDeck deck)
        {
            foreach (Player player in table.GetPlayers())
            {
                while (player.IsWaitingForCard(table))
                {
                    player.TakeCard(deck.GetCard());
                }
            }
        }

        private uint GetBestHandValue(Table table)
        {
            uint bestHandValue = 0;
            foreach (Player player in table.GetPlayers())
            {
                uint playerHandValue = player.GetHand().GetHandValue();
                if ((playerHandValue <= BLACK_JACK)
                    && (playerHandValue > bestHandValue))
                {
                    bestHandValue = playerHandValue;
                }
            }
            return bestHandValue;
        }
    }
}
