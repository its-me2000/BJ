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
            FirstDeal(table, deck);
            WinnersList = BlackJackWinners(table);
            if (WinnersList.Count != 0)
            {
                return WinnersList;
            }
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
                //TODO: empty deck case
            }
        }

        private List<Player> BlackJackWinners(Table table)
        {
            List<Player> WinnersList = new();
            foreach (Player player in table.GetPlayers())
            {
                if (player.GetHand().GetHandValue() == BLACK_JACK)
                {
                    WinnersList.Add(player);
                }
            }
            return WinnersList;
        }
        private List<Player> EndGameWinners(Table table)
        {
            List<Player> WinnersList = new();
            uint bestHandValue = GetBestHandValue(table);
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
                while (player.IsWaitingForCard(GetBestOtherPlayersHand(table,player)))
                {
                    player.TakeCard(deck.GetCard());
                    //TODO: empty deck case
                }
            }
        }

        private Hand GetBestOtherPlayersHand(Table table, Player selfPlayer)
        {
            Hand bestHand = new BJHand();
            uint bestHandValue = 0;
            foreach (Player player in table.GetPlayers())
            {
                uint playerHandValue = player.GetHand().GetHandValue();
                if((player != selfPlayer)
                    && (playerHandValue <= 21)
                    && (playerHandValue > bestHandValue))
                {
                    bestHandValue = playerHandValue;
                    bestHand = player.GetHand();
                }
            }
            return bestHand;
        }
        private uint GetBestHandValue(Table table)
        {
            uint bestHandValue = 0;
            foreach (Player player in table.GetPlayers())
            {
                uint playerHandValue = player.GetHand().GetHandValue();
                if ((playerHandValue <= 21)
                    && (playerHandValue > bestHandValue))
                {
                    bestHandValue = playerHandValue;
                }
            }
            return bestHandValue;
        }
    }
}
