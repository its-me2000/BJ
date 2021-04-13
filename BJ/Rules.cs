using System;
using System.Collections.Generic;

namespace BJ
{
    public interface Rules
    {
        List<Player> GetWinners(Table table, CardDeck deck);
    }
}
