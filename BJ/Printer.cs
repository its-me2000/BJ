/*
 * Skriv ut hvem som vinner spillet
 * Skriv ut poengsum og kortene til hver spiller ved spillets slutt.
 * Et kort angis ved å konkatenere suit og value:
 * suit -> [H|D|S|C]
 * value -> [2|3|4|5|6|7|8|9|10|J|Q|K|A]
 * Eksempel på output:
 *
 *
 * Vinner: Truls
 *
 * Marit | 27 | S7,S10,CJ
 * Truls  | 19 | D2,H2,C6,H9
 * 
 */

using System;
using System.Collections.Generic;

namespace BJ
{
    public class Printer
    {
        Game game;
        public Printer(Game _game)
        {
            game = _game;
        }
        public void Print()
        {
            List<Player> Winners = game.GetWinners();

            string winnersString;
            if (Winners.Count == 0)
            {
                winnersString = "\nIngen vinner.";
            }
            else
            {
                winnersString = Winners[0].GetName();
                if(Winners.Count == 1)
                {
                    winnersString = "\nVinner: " + winnersString;
                }
                else
                {
                    winnersString = "\nVinnere: " + winnersString;
                    foreach(Player player in Winners.GetRange(1, Winners.Count - 1))
                    {
                        winnersString += ", "+player.GetName();
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
