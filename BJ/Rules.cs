using System.Collections.Generic;

namespace BJ
{
    public interface Rules
    {
        public List<Player> GetWinners(Table table, CardDeck deck);
    }
}
