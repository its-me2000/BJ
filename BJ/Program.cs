using System;

namespace BJ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(new Card(CardSuit.HEARTS, CardValue.ACE).ToString());

            Console.WriteLine(new NavCardDeck());

            Console.WriteLine(new DefaultCardDeck(false));

            Console.WriteLine(new DefaultCardDeck(true));
            Console.ReadKey(true);
        }
    }

}
