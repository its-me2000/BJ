using System.Collections.Generic;

namespace BJ
{
    public interface PlayerStrategy
    {
        bool IsWaitingForCard(Player selfPlayer, Table table);
    }
}
