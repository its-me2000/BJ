using System;

namespace BJ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(new Card(CardSuit.HEARTS, CardValue.ACE).ToString());

            Console.WriteLine("\n");
//            Console.WriteLine(new NavCardDeck());

            Console.WriteLine("\n");

            Console.WriteLine(new DefaultCardDeck(false));
            Console.WriteLine("\n");

            Console.WriteLine(new DefaultCardDeck(true));
            Console.WriteLine("\n");

            const uint threshold = 17;

            new Printer(
                new BJGame(
                    new BJTable(
                        new BJPlayer("Eugenijus", new BJThresholdPlayerStategy(threshold)),
                        new BJPlayer("NAV", new BJDealerPlayerStrategy())
                    ),
                    new NavCardDeck(),
                    new BJRules()
                )
            );

            //Hand hand = new BJHand();
            //hand.TakeCard(new Card(CardSuit.CLUBS, CardValue.ACE));
            //hand.TakeCard(new Card(CardSuit.DIAMONDS, CardValue.EIGHT));
            //Console.WriteLine(hand.GetHandValue());

            Console.ReadKey(true);
        }
    }

}
