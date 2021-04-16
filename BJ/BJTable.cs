using System.Collections.Generic;

namespace BJ
{
    public class BJTable : Table
    {
        private readonly List<Player> players;
        public BJTable(List<Player> _players, Player dealer)
        {
            players = _players;
            players.Add(dealer);
            //TODO: chek player count. should be two or more. upper limit?
        }
        public BJTable(Player player, Player dealer)
        {
            players = new List<Player>
            {
                player,
                dealer
            };
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        public void ResetHands()
        {
            GetPlayers().ForEach((player) => player.GetHand().ResetHand()); ;
        }
    }
}
