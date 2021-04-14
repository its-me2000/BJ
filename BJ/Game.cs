using System.Collections.Generic;

namespace BJ
{
    public interface Game
    {
        public List<Player> GetWinners();
        public Table GetTable();
        public CardDeck GetDeck();
    }
}
