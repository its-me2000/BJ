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
                while (player.IsWaitingForCard(GetOpponentsHands(table,player)))
                {
                    player.TakeCard(deck.GetCard());
                    //TODO: empty deck case
                }
            }
        }

        private List<Hand> GetOpponentsHands(Table table, Player selfPlayer)
        {
            List<Hand> opponentsHands = new List<Hand>();
            foreach (Player player in table.GetPlayers())
            { 
                if(player != selfPlayer)
                {
                    opponentsHands.Add(player.GetHand());
                }
            }
            return opponentsHands;
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
