using System;
using System.Collections.Generic;

namespace BJ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleKey commandKey;
            Console.WriteLine("\nVelkomment til BLACK JACK spill!");
            do {
                Console.WriteLine("\n (1) - Kjør demo. (Enter) - Spill. (Esc) - Slutt.");
                commandKey = Console.ReadKey(true).Key;

                switch (commandKey)
                {
                    case ConsoleKey.D1:
                        RunDemo();
                        break;
                    case ConsoleKey.Enter:
                        RunGame();
                        break;
                    default:
                        break;
                       
                }
            } while (commandKey != ConsoleKey.Escape) ;
            Console.WriteLine("\nBye-Bye!");
            Console.ReadKey(true);
        }

        private static void RunDemo()
        {
            string demoPlayerName = "Truls";
            string demoDealerName = "Marit";
            Printer GameResultsPrinter = new Printer(
                new BJGame(
                    new BJTable(
                        new BJPlayer(demoPlayerName, new BJThresholdPlayerStrategy()),
                        new BJPlayer(demoDealerName, new BJDealerPlayerStrategy())
                    ),
                    new NavCardDeck(),
                    new BJRules()
                )
            );
            GameResultsPrinter.Print();
        }

        private static void RunGame()
        {
            uint numberOfPlayers;
            Console.WriteLine("\nHvor mange spillere? ( standard: 1 ) :");

            string inputString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputString))
            {
                //Default Value
                numberOfPlayers = 1;
            }
            else if (!uint.TryParse(inputString, out numberOfPlayers) || numberOfPlayers < 1)
            {
                Console.WriteLine("\nFeil verdi.");
                Console.ReadKey(true);
                return;
            }

            List<Player> players = new List<Player>();
            for(int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine("Skriv navn til Spiller nr {0} eller la tomt og trykk (Enter) for KI:",i+1);
                inputString = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputString))
                {
                    players.Add(new BJPlayer("KI" + (i + 1).ToString(), new BJThresholdPlayerStrategy()));
                }
                else
                {
                    players.Add(new BJPlayer(inputString, new BJManualPlayerStrategy(PlayerUserInterface)));
                }
            }

            Table table = new BJTable(players, new BJPlayer("Dealer", new BJDealerPlayerStrategy()));
            CardDeck deck;
            NewDeck:
            Console.WriteLine("Velg kortstokken:\n(Enter) - NAVIKT. (Space) - Lokal.");
            ConsoleKey commandKey = Console.ReadKey(true).Key;
            if(commandKey == ConsoleKey.Enter)
            {
                try
                {
                    deck = new NavCardDeck();
                }
                catch(Exception e)
                {
                    Console.WriteLine("\nDet oppstått en feil med lasting kortstokken fra NAVIKT.");

                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);

                    Console.WriteLine("\nLokal kortstokken brukes.");
                    Console.ReadKey(true);
                    deck = new DefaultCardDeck(true);
               }
            }
            else
            {
                deck = new DefaultCardDeck(true);
            }
            
            Printer GameResultsPrinter = new Printer(new BJGame(table, deck, new BJRules()));
            NextGame:
            GameResultsPrinter.Print();
            Console.WriteLine("En gang til?\n (Enter) - Ja. (Space) - Ja med ny kortstokken. (Esc) - Nei.");
            commandKey = Console.ReadKey(true).Key;
            switch (commandKey)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.J:
                    goto NextGame;
                case ConsoleKey.Spacebar:
                    goto NewDeck;
                case ConsoleKey.Escape:
                case ConsoleKey.N:
                default:
                    break;
            }
        }

        private static bool PlayerUserInterface(string ownData, string opponentsData)
        {
            Console.Clear();
            Console.WriteLine("\nMotspilleres kort:");
            Console.WriteLine(opponentsData);
            Console.WriteLine("\nDine kort:");
            Console.WriteLine(ownData);

            Console.WriteLine("\nEtt kort til? \n(Enter) - Ja. (Esc) - Nei.");
            ConsoleKey commandKey = Console.ReadKey(true).Key;
            switch (commandKey)
            {
                case ConsoleKey.J:
                case ConsoleKey.Y:
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    return true;
                default:
                    break;
            }
            return false;
        }
    }

}
