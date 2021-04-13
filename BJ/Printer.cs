using System;
using System.Collections.Generic;

namespace BJ
{
    public class Printer
    {
        public Printer(Game game)
        {
            Console.WriteLine("!!!BLACK JACK!!!");
            List<Player> Winners = game.GetWinners();

            string winnersString;
            if (Winners.Count == 0)
            {
                winnersString = "Ingen vinner.";
            }
            else
            {
                winnersString = Winners[0].GetName();
                if(Winners.Count == 1)
                {
                    winnersString = "Vinner: " + winnersString;
                }
                else
                {
                    winnersString = "Vinnere: " + winnersString;
                    foreach(Player player in Winners.GetRange(1, Winners.Count - 1))
                    {
                        winnersString = winnersString + player.GetName();
                    }
                }
            }
            Console.WriteLine(winnersString);

            foreach(Player player in game.GetTable().GetPlayers())
            {
                Console.WriteLine(player.ToString());
            }
        }
    }
}
