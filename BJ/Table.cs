using System.Collections.Generic;

namespace BJ
{
    public interface Table
    {
        public List<Player> GetPlayers();
        public void ResetHands();
    }
}
